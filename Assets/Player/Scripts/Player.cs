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
    private LayerMask mask;

    public void OnMove(CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started ||
            !isCanMove)
            return;

        var moveDirection = context.ReadValue<Vector2>().normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 1, ~mask);
        if (hit.collider != null)
            return;

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

    private void Start()
    {
        mask = LayerMask.GetMask("Player");
    }
}
