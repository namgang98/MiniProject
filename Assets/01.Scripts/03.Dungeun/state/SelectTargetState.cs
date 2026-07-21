using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectTargetState : BaseState
{
    Skill selectSkill;
    BattleUnit caster;
    public SelectTargetState(BattleStateMachin machine, BattleManager manager) : base(machine, manager) { }
    
    public override void Enter()
    {
        caster = TurnManager.instance.GetCurrentUnits();
        selectSkill = BattleManager.instance.currentSkill;
    }
    public override void Exit()
    {

    }
    public override void Update()
    {
        if(Keyboard.current.escapeKey.isPressed)
        {
            if (caster is BattleMercenary mer)
            {
                DungeunUIManager.instance.CloseSkillPop();
                machin.ChangeState(machin.startState);
            }
        }
    }
    public void OnClickTarget(BattleUnit target)
    {
        if(IsTarget(target))
        {
            List<BattleUnit> lastTarget = GetLastTargets(target);

            BattleManager.instance.currentTarget = target;
            BattleManager.instance.currentTargets = lastTarget;
            DungeunUIManager.instance.CloseSkillPop();
            DungeunUIManager.instance.CloseStatPop();
            machin.ChangeState(machin.mercenaryAttackState);
        }
    }
    bool IsTarget(BattleUnit target)
    {
        bool issametarget = false;
        switch(selectSkill.targetType)
        {
            case TargetType.Self:
                issametarget = (target == caster);
                break; 
            case TargetType.Teamone:
            case TargetType.Teamall:
                issametarget = (target.UnitType == caster.UnitType);
                break;
            case TargetType.Enemyone:
            case TargetType.Enemyall:
               issametarget = (target.UnitType != caster.UnitType);
                break;
        }
        if(!issametarget)
            return false;
        return IsCorrectPos(target);
    }

    bool IsCorrectPos(BattleUnit target)
    {
        if(selectSkill.posType == TargetPosType.All)
            return true;
    
        if(selectSkill.posType == TargetPosType.Front)
        {
            int targetIndex = BattleUnitManager.instance.GetUnitIndex(target);
            if(targetIndex == 0 || targetIndex == 1)
                return true;

        }
        return false;
        
    }

    private List<BattleUnit> GetLastTargets(BattleUnit unit)
    {
        List<BattleUnit> targets = new();

        switch (selectSkill.targetType)
        {
            case TargetType.Self: 
            case TargetType.Teamone:
            case TargetType.Enemyone:
                targets.Add(unit);
                break;

            case TargetType.Teamall:
            case TargetType.Enemyall:
                targets.AddRange(BattleUnitManager.instance.GetUnitsByType(unit.UnitType));
                break;
        
        }
        return targets;
    }


}
