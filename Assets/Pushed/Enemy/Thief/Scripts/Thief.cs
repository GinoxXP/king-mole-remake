using DG.Tweening;
using UnityEngine;

public class Thief : AEnemy
{
    private Vector3 targetPosition;

    public override void Push(Player player, Vector2 direction)
    {
        var hits = Physics2D.RaycastAll(transform.position, direction);
        Debug.DrawRay(transform.position, direction, Color.magenta, 0.2f);

        foreach (var hit in hits)
        {
            if (hit.transform == transform ||
                hit.collider == null)
                continue;

            targetPosition = RoundVector(hit.point, direction);
            break;
        }

        base.Push(player, direction);
    }

    protected override void Move(Vector2 direction)
    {
        transform
            .DOMove(targetPosition, moveDuration)
            .OnKill(() => isCanMove = true);
    }

    private Vector3 RoundVector(Vector3 point, Vector2 direction)
    {
        var roundedVector = new Vector3(
            direction.x > 0 ? Mathf.RoundToInt(point.x) : Mathf.CeilToInt(point.x),
            Mathf.RoundToInt(point.y),
            point.z);

        return roundedVector;
    }
}
