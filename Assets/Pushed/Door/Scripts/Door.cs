using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour, IPushed
{
    [SerializeField]
    private GameObject door;
    private new BoxCollider2D collider;

    private bool isOpen;

    public void ChangeState(bool? state = null)
    {
        if (state.HasValue)
            isOpen = state.Value;
        else
            isOpen = !isOpen;

        door.SetActive(isOpen);
        collider.enabled = isOpen;
    }

    public void Push(Player player, Vector2 direction, Action strokeCompleateAction = null)
    {
        strokeCompleateAction?.Invoke();
    }

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }
}
