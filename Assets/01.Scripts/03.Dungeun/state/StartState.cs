using Unity.VisualScripting;
using UnityEngine;

public class StartState : BaseState
{
    public StartState(BattleStateMachin machine, BattleManager manager ) : base(machine, manager) {}
    public override void Enter()
    {
        BattleUnit unit = TurnManager.instance.GetCurrentUnits();
        unit.SetTurnMark(true);

        if (unit is BattleMonster)
        {
            machin.ChangeState(machin.monsterAttackState);
        }

           
    }
    public override void Exit()
    { 

    }
    public override void Update()
    {
    }
}
