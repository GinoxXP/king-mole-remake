using System;
using UnityEngine;

public interface IPushed
{
    public void RegisterPush(Vector2 direction, Action strokeCompleateAction = null);

    public void Push();

    public void ExecutePush();
}
