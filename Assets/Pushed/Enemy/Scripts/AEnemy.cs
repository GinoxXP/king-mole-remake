
using UnityEngine;

public abstract class AEnemy : MonoBehaviour, IPushed
{
    public abstract void Push(Player player, Vector2 direction);

    public abstract void Death();
}
