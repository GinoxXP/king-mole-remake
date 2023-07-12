using System;
using UnityEngine;

public abstract class AMoved : MonoBehaviour, IPushed
{
    [SerializeField]
    protected float moveDuration;

    protected bool isCanMove = true;

    public virtual void Push(Player player, Vector2 direction, Action action)
    {
        if (!isCanMove)
            return;

        var hits = Physics2D.RaycastAll(transform.position, direction, 1);
        Debug.DrawRay(transform.position, direction, Color.cyan, 0.2f);

        foreach (var hit in hits)
        {
            if (hit.transform == transform ||
                hit.collider == null)
                continue;

            if (hit.collider.tag == "Wall" || hit.collider.TryGetComponent<IPushed>(out var iPushed))
            {
                CantMove();
                action?.Invoke();
                return;
            }
        }

        Move(direction, action);
    }

    protected abstract void CantMove();

    protected virtual void Move(Vector2 direction, Action action)
    {
        action?.Invoke();
    }
}
