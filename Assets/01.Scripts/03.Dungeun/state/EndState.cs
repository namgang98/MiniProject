using UnityEngine;

public class EndState : BaseState
{
    public EndState(BattleStateMachin machine, BattleManager manager) : base(machine, manager)
    {
    }
    public override void Enter()
    {
        TurnManager.instance.NextTurn();
        machin.ChangeState(machin.startState);
    }
    public override void Exit()
    {
        
    }
    public override void Update()
    {

    }
}
