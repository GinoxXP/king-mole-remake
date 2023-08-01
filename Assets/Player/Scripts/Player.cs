using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour, ISpikesStep
{
    [SerializeField]
    private float moveDuration;

    public bool IsCanMove { get; set; } = true;

    public event Action StrokeStarted;

    public event Action StrokeCompleated;

    public event Action PlayerDead;

    public void OnMove(CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started ||
            !IsCanMove)
            return;

        var moveDirection = context.ReadValue<Vector2>().normalized;

        SetMoveDirection(moveDirection);
    }

    public void SetMoveDirection(Vector2 direction)
    {
        var hits = Physics2D.RaycastAll(transform.position, direction, 1);
        Debug.DrawRay(transform.position, direction, Color.white, 0.2f);

        foreach (var hit in hits)
        {
            if (hit.transform == transform ||
                hit.collider == null)
                continue;

            if (hit.collider.tag == "Wall")
                return;

            if (hit.collider.TryGetComponent<IPushed>(out var iPushed))
            {
                StrokeStarted?.Invoke();

                iPushed.Push(this, direction, () => StrokeCompleated?.Invoke());
                return;
            }
        }

        Move(direction);
    }

    public void StepOnSpike()
    {
        PlayerDead?.Invoke();
    }

    private void Move(Vector2 moveDirection)
    {
        StrokeStarted?.Invoke();

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
