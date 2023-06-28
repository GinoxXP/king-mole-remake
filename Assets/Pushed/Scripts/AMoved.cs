using UnityEngine;

public abstract class AMoved : MonoBehaviour, IPushed
{
    [SerializeField]
    protected float moveDuration;

    protected bool isCanMove = true;

    public void Push(Player player, Vector2 direction)
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

            CantMove();
            return;
        }

        Move(direction);
    }

    public abstract void CantMove();

    public abstract void Move(Vector2 direction);
}
