using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateMachin : StateMachin
{
    public StartState startState;
    public SelectTargetState selectTargetState;
    public MercenaryAttackState mercenaryAttackState;
    public MonsterAttackState monsterAttackState;
    public EndState endState;
    
    public BattleStateMachin(BattleManager manager)
    {
        startState = new StartState(this, manager);
        selectTargetState = new SelectTargetState(this, manager);
        mercenaryAttackState = new MercenaryAttackState(this, manager);
        monsterAttackState = new MonsterAttackState(this, manager);
        endState = new EndState(this, manager);
    }
    

}
