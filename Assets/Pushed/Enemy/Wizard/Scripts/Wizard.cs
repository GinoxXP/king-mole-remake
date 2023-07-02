using System;
using UnityEngine;

public class Wizard : AEnemy
{
    private static readonly int MAX_SHIELD_STATUS = 2;

    private bool isCanUseShield = true;
    private int shieldStatus;

    protected override void CantMove()
    {
        if (!CanInteract())
            return;

        base.CantMove();
    }

    protected override void Move(Vector2 direction, Action strokeCompleateAction)
    {
        if (!CanInteract())
            return;

        base.Move(direction, strokeCompleateAction);
    }

    private bool CanInteract()
    {
        if (isCanUseShield)
        {
            isCanUseShield = false;
            shieldStatus = MAX_SHIELD_STATUS;
            return false;
        }

        if (shieldStatus != 0)
            return false;

        return true;
    }
}
