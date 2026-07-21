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

        if(skill.atkType == AttackType.Attack)
        {
            int dmg = TotalDamage(caster, skill);
            target.TakeDamage(dmg);
        }
        //공격도트윈으로 모션만들어서 넣기
        machin.ChangeState(machin.endState);
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
