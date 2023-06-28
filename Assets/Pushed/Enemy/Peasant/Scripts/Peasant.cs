using DG.Tweening;
using UnityEngine;

public class Peasant : AEnemy
{
    public override void CantMove()
    {
        Death();
    }

    public override void Death()
    {
        Destroy(gameObject);
    }

    public override void Move(Vector2 direction)
    {
        var targetPosition = transform.position + (Vector3)direction;
        transform
            .DOMove(targetPosition, moveDuration)
            .OnKill(() => isCanMove = true);
    }
}
