using System;
using UnityEngine;

public class Knight : AEnemy, IStrokeReceive
{
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private bool isDefense;

    public bool IsDefense => isDefense;

    public void ChangeState(bool? state = null)
    {
        if (state.HasValue)
            isDefense = state.Value;
        else
            isDefense = !isDefense;

        shield.SetActive(isDefense);
    }

    protected override void CantMove()
    {
        if (isDefense)
            return;

        base.CantMove();
    }

    protected override void Move(Vector2 direction, Action strokeCompleateAction)
    {
        if (isDefense)
        {
            strokeCompleateAction?.Invoke();
            return;
        }

        base.Move(direction, strokeCompleateAction);
    }

    private void Start()
    {
        shield.SetActive(isDefense);
    }

    public void OnStroke()
    {
        ChangeState();
    }
}
