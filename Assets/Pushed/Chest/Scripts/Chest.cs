using DG.Tweening;
using UnityEngine;

public class Chest : AMoved
{

    protected override void CantMove()
    {
    }

    protected override void Move(Vector2 direction)
    {
        var targetPosition = transform.position + (Vector3)direction;
        transform
            .DOMove(targetPosition, moveDuration)
            .OnKill(() => isCanMove = true);
    }
}
