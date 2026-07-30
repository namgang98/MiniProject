using System.Collections.Generic;
using UnityEngine;

public class MercenaryAttackState : BaseState
{
    public MercenaryAttackState(BattleStateMachin machine, BattleManager manager) : base(machine, manager) { }
    public override void Enter()
    {
        BattleUnit caster = TurnManager.instance.GetCurrentUnits();
        Skill skill = manager.currentSkill;
        BattleUnit target = manager.currentTarget;
        
        if(skill == null || target == null)
        {
            TurnManager.instance.NextTurn();
            return;
        }

        int dmg = TotalDamage(caster, skill);
        

        //공격도트윈으로 모션만들어서 넣기
        RectTransform attackerRect = caster.GetComponent<RectTransform>();
        List<BattleUnit> targetect = new() { target};
        DotWeenManager.instance.AttackMove(caster,targetect,skill.aniType,manager.dim,hit: () => { target.TakeDamage(dmg);}, complate: () => machin.ChangeState(machin.endState)
        );
    }
    public override void Exit()
    {

    }
    public override void Update()
    {

    }
    int TotalDamage(BattleUnit caster, Skill skill)
    {
        int statPLus = 0;
        switch(skill.statType)
        {
            case StatType.Str:
                statPLus = caster.STR;
                break;
            case StatType.Int:
                statPLus = caster.INT;
                break;
            case StatType.Dex:
                statPLus = caster.Dex;
                break;
        }
        return skill.damage + statPLus;
    }
}
