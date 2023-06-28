using DG.Tweening;
using UnityEngine;

public abstract class AEnemy : AMoved
{
    protected abstract void Death();

    protected override void Move(Vector2 direction)
    {
        var targetPosition = transform.position + (Vector3)direction;
        transform
            .DOMove(targetPosition, moveDuration)
            .OnKill(() => isCanMove = true);
    }
}
