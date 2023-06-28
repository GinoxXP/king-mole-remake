using UnityEngine;

public class Knight : AEnemy
{
    private bool isDefence;

    public void ChangeDefence(bool? state = null)
    {
        if (state.HasValue)
            isDefence = state.Value;
        else
            isDefence = !isDefence;
    }

    protected override void CantMove()
    {
        if (isDefence)
            return;

        base.CantMove();
    }

    protected override void Move(Vector2 direction)
    {
        if (isDefence)
            return;

        base.Move(direction);
    }
}