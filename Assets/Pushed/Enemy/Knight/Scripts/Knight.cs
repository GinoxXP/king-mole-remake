using System;
using UnityEngine;

public class Knight : AEnemy, IStrokeReceive
{
    [SerializeField]
    private GameObject shield;

    private bool isDefence;

    public void ChangeState(bool? state = null)
    {
        if (state.HasValue)
            isDefence = state.Value;
        else
            isDefence = !isDefence;

        shield.SetActive(isDefence);
    }

    protected override void CantMove()
    {
        if (isDefence)
            return;

        base.CantMove();
    }

    protected override void Move(Vector2 direction, Action strokeCompleateAction)
    {
        if (isDefence)
        {
            strokeCompleateAction?.Invoke();
            return;
        }

        base.Move(direction, strokeCompleateAction);
    }

    private void Start()
    {
        shield.SetActive(isDefence);
    }

    public void OnStroke()
    {
        ChangeState();
    }
}
