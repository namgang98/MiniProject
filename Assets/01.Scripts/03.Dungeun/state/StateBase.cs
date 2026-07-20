using UnityEngine;

public abstract class BaseState : IState
{
    protected BattleStateMachin machin;
    protected BattleManager manager;

    public BaseState(BattleStateMachin machin, BattleManager manager)
    {
        this.machin = machin;
        this.manager = manager;
    }

    public virtual void Enter()
    {

    }
    public virtual void Exit()
    {

    }
    public virtual void Update()
    {

    }
}
