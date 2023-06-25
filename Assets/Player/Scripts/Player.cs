using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveDuration;

    private IEnumerator moveCoroutine;
    private bool isCanMove = true;

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

            return;

        }

        moveCoroutine = Move(moveDirection);
        StartCoroutine(moveCoroutine);
    }

    private IEnumerator Move(Vector2 moveDirection)
    {
        isCanMove = false;
        var targetPosition = transform.position + (Vector3)moveDirection;
        transform
            .DOMove(targetPosition, moveDuration)
            .OnKill(() => isCanMove = true);
        yield return null;
    }
}
