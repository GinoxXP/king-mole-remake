using UnityEngine;

public class Berserker : AEnemy
{
    private bool isWeak;

    protected override void Move(Vector2 direction)
    {
        if (!isWeak)
        {
            isWeak = true;
            return;
        }

        base.Move(direction);
        isWeak = false;
    }
}
