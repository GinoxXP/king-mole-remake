using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour, IPushed
{
    private new BoxCollider2D collider;
    private Animator animator;

    [SerializeField]
    private int id;

    private bool isOpen;

    public int ID => id;

    public void ChangeState(bool? state = null)
    {
        if (state.HasValue)
            isOpen = state.Value;
        else
            isOpen = !isOpen;

        animator.Play(isOpen ? "Open" : "Close");
        collider.enabled = !isOpen;
    }

    public void Push(Player player, Vector2 direction, Action strokeCompleateAction = null)
    {
        strokeCompleateAction?.Invoke();
    }

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponentInChildren<Animator>();
    }
}
