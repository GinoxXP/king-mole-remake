using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Chest : MonoBehaviour, IPushed
{
    [SerializeField]
    private float moveDuration;

    private bool isCanMove = true;

    public void Push(Player player, Vector2 direction)
    {
        if (!isCanMove)
            return;

        var hits = Physics2D.RaycastAll(transform.position, direction, 1);
        Debug.DrawRay(transform.position, direction, Color.cyan, 0.2f);

        foreach (var hit in hits)
        {
            if (hit.transform == transform ||
                hit.collider == null)
                continue;

            return;
        }

        var targetPosition = transform.position + (Vector3)direction;
        transform
            .DOMove(targetPosition, moveDuration)
            .OnKill(() => isCanMove = true);
    }
}
