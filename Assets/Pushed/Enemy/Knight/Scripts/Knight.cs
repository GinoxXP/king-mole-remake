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

    protected override void Move(Vector2 direction)
    {
        if (isDefence)
            return;

        base.Move(direction);
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
