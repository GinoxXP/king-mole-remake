using System;

public interface IVictoryCondition
{
    public event Action<IVictoryCondition> ConditionMet;
}
