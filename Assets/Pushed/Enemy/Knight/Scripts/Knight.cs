using UnityEngine;
using Zenject;

public class Knight : AEnemy
{
    private ClassicMode classicMode;

    [SerializeField]
    private GameObject shield;

    private bool isDefence;

    public void ChangeDefence(bool? state = null)
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

    private void OnStrokeCompleated()
    {
        ChangeDefence();
    }

    private void OnDestroy()
    {
        classicMode.OnStroke -= OnStrokeCompleated;
    }

    private void Start()
    {
        shield.SetActive(isDefence);
    }

    [Inject]
    private void Init(ClassicMode classicMode)
    {
        this.classicMode = classicMode;
        classicMode.OnStroke += OnStrokeCompleated;
    }
}
