using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveDuration;

    private bool isCanMove = true;

    public event Action OnStroke;

    public void OnMove(CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started ||
            !isCanMove)
            return;

        var moveDirection = context.ReadValue<Vector2>().normalized;

        var hits = Physics2D.RaycastAll(transform.position, moveDirection, 1);
        Debug.DrawRay(transform.position, moveDirection, Color.white, 0.2f);

        foreach (var hit in hits)
        {
            if (hit.transform == transform ||
                hit.collider == null)
                continue;

            if (hit.collider.TryGetComponent<IPushed>(out var iPushed))
                iPushed.Push(this, moveDirection);

            OnStroke?.Invoke();
            return;

        }

        Move(moveDirection);

        OnStroke?.Invoke();
    }

    private void Move(Vector2 moveDirection)
    {
        isCanMove = false;
        var targetPosition = transform.position + (Vector3)moveDirection;
        transform
            .DOMove(targetPosition, moveDuration)
            .OnKill(() => isCanMove = true);
    }
}
