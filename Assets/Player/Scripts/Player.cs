using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveDuration;

    public bool IsCanMove { get; set; } = true;

    public event Action StrokeCompleated;

    public void OnMove(CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started ||
            !IsCanMove)
            return;

        var moveDirection = context.ReadValue<Vector2>().normalized;

        var hits = Physics2D.RaycastAll(transform.position, moveDirection, 1);
        Debug.DrawRay(transform.position, moveDirection, Color.white, 0.2f);

        foreach (var hit in hits)
        {
            if (hit.transform == transform ||
                hit.collider == null)
                continue;

            if (hit.collider.tag == "Wall")
                return;

            if (hit.collider.TryGetComponent<IPushed>(out var iPushed))
            {
                iPushed.Push(this, moveDirection, () => StrokeCompleated?.Invoke());
                return;
            }
        }

        Move(moveDirection);
    }

    private void Move(Vector2 moveDirection)
    {
        IsCanMove = false;
        var targetPosition = transform.position + (Vector3)moveDirection;
        transform
            .DOMove(targetPosition, moveDuration)
            .OnKill(() =>
            {
                IsCanMove = true;
                StrokeCompleated?.Invoke();
            });
    }
}
