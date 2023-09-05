using UnityEngine;

[RequireComponent (typeof(Animator))]
public class Chest : AMoved
{
    private Animator animator;

    public override void Push()
    {
        animator.Play("Push");
        base.Push();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
