using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour, IPushed
{
    private new BoxCollider2D collider;

    [SerializeField]
    private GameObject door;
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

        door.SetActive(!isOpen);
        collider.enabled = !isOpen;
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
