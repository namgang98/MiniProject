using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackState : BaseState
{
    public MonsterAttackState(BattleStateMachin machine, BattleManager manager) : base(machine, manager) { }
    public override void Enter()
    {
        BattleMonster monster = (BattleMonster)TurnManager.instance.GetCurrentUnits();
        Skill skill = SelectSkill(monster);
       
        BattleUnit target = SelectTarget(skill);
        if (target == null)
        {
            machin.ChangeState(machin.endState);
            return;
        }
        List<BattleUnit> targets = GetTargets(skill, target);
        int dmg = skill.damage;

        foreach(BattleUnit unit in targets)
        {
            unit.TakeDamage(dmg);
        }

        machin.ChangeState(machin.endState);
    }
    public override void Exit()
    {
        
    }
    public override void Update()
    {

    }
    Skill SelectSkill(BattleMonster monster)
    {
        Monster data = monster.Data;
        int random = Random.Range(0, 100);
        int skillID;


        if (random < 80)
            skillID = data.skillID[0];
        else
            skillID = data.skillID[1];
        return SkillManager.instance.GetSkill(skillID);
    }
    BattleUnit SelectTarget(Skill skill)
    {
        List<BattleUnit> mers = BattleUnitManager.instance.GetUnitsByType(UnitType.Mercenary);
        int randomTalget = Random.Range(0, mers.Count);
        switch(skill.targetType)
        {
            case TargetType.Enemyone:
                return mers[randomTalget];
            case TargetType.Enemyall:
                return null;
        }
        return null;
    }
    List<BattleUnit> GetTargets(Skill skill, BattleUnit target)
    {
        List<BattleUnit> targets = new();

        switch (skill.targetType)
        {
            case TargetType.Enemyone:
                targets.Add(target);
                break;

            case TargetType.Enemyall:
                targets.AddRange(BattleUnitManager.instance.GetUnitsByType(UnitType.Mercenary));
                break;
        }

        return targets;
    }
}
