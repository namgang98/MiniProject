using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackState : BaseState
{
    private BattleMonster attacker;
    private BattleMercenary target;

    public MonsterAttackState(BattleStateMachin machine, BattleManager manager) : base(machine, manager) { }
    public override void Enter()
    {
        Debug.Log("monsterTurn");
        attacker = TurnManager.instance.Getcurrentunits() as BattleMonster;

        List<BattleUnit> mers = manager.GetUnitsByType(UnitType.Mercenary);

        if(attacker != null && mers != null && mers.Count > 0)
        {
            int random = Random.Range(0, mers.Count);
            target = mers[random] as BattleMercenary;

            if(target != null)
            {
            }
        }

    }
    public override void Exit()
    {
        machin.ChangeState(machin.endState);
    }
    public override void Update()
    {

    }
}
