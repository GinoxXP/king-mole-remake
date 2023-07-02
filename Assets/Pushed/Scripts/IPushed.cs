using System;
using UnityEngine;

public interface IPushed
{
    public void Push(Player player, Vector2 direction, Action strokeCompleateAction = null);
}
