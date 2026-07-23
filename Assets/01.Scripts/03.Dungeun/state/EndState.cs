using UnityEngine;

public class EndState : BaseState
{
    public EndState(BattleStateMachin machine, BattleManager manager) : base(machine, manager)
    {
    }
    public override void Enter()
    {
        BattleUnit unit = TurnManager.instance.GetCurrentUnits();
        unit.SetTurnMark(false);

        if (BattleUnitManager.instance.partys.Count > 0 && BattleUnitManager.instance.monsters.Count > 0)
        {
            TurnManager.instance.NextTurn();
            machin.ChangeState(machin.startState);
        }
    }
    public override void Exit()
    {
        
    }
    public override void Update()
    {

    }
}
