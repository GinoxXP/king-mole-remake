using System;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class Chest : AMoved
{
    private Animator animator;

    public override void RegisterPush(Vector2 direction, Action action)
    {
        base.RegisterPush(direction, () =>
        {
            animator.Play("Push");
            action?.Invoke();
        });
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
