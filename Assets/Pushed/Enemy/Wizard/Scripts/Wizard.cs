using System;
using UnityEngine;

public class Wizard : AEnemy, IStrokeReceive
{
    private static readonly int MAX_SHIELD_STATUS = 2;

    private bool isCanUseShield = true;
    private int shieldStatus;

    public void OnStroke()
    {
        if (!CanInteract())
            shieldStatus--;
    }

    protected override void CantMove()
    {
        if (TryActivateShield() || !CanInteract())
            return;

        base.CantMove();
    }

    protected override void Move(Vector2 direction, Action strokeCompleateAction)
    {
        if (TryActivateShield() || !CanInteract())
            return;

        base.Move(direction, strokeCompleateAction);
    }

    private bool TryActivateShield()
    {
        if (isCanUseShield)
        {
            isCanUseShield = false;
            shieldStatus = MAX_SHIELD_STATUS;
            return true;
        }

        return false;
    }

    private bool CanInteract()
    {
        if (shieldStatus != 0)
            return false;

        return true;
    }
}
