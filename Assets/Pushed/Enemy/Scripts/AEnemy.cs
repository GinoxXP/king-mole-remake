using DG.Tweening;
using UnityEngine;

public abstract class AEnemy : AMoved
{
    protected virtual void Death()
    {
        Destroy(gameObject);
    }

    protected override void Move(Vector2 direction)
    {
        var targetPosition = transform.position + (Vector3)direction;
        transform
            .DOMove(targetPosition, moveDuration)
            .OnKill(() => isCanMove = true);
    }

    protected override void CantMove()
    {
        Death();
    }
}
