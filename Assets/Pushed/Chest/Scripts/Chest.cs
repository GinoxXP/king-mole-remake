using System;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class Chest : AMoved
{
    private Animator animator;

    public override void Push(Player player, Vector2 direction, Action action)
    {
        base.Push(player, direction, action);
        animator.Play("Push");
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
