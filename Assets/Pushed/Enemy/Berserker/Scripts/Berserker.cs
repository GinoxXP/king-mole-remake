using UnityEngine;

public class Berserker : AEnemy
{
    private bool isWeak;

    protected override void CantMove()
    {
        if (!CanInteract())
            return;

        base.CantMove();
    }
    protected override void Move(Vector2 direction)
    {
        if (!CanInteract())
            return;

        base.Move(direction);
        isWeak = false;
    }

    private bool CanInteract()
    {
        if (!isWeak)
        {
            isWeak = true;
            return false;
        }
        else
            return true;
    }
}
