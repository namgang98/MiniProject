using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    public BattleStateMachin stateMachin;
    public Skill currentSkill;
    public BattleUnit currentTarget;
    public List<BattleUnit> currentTargets;

    [SerializeField] BattleMercenary battleMerPrefab;
    [SerializeField] Transform[] partyPos;
    List<BattleMercenary> partys = new();

    [SerializeField] MonsterData monsterData;
    [SerializeField] BattleMonster battleMonsterPrefab;
    [SerializeField] Transform[] monsPos;
    [SerializeField] List<int> spawnMonsterID; 
    List<BattleMonster> mons = new();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        stateMachin = new BattleStateMachin(this);
    }

    private void Start()
    {
        SpawnParty();
        SpawnMonster();

        TurnManager.instance.SetTurn(GetBattleUnit());

        stateMachin.ChangeState(stateMachin.startState);
    }
    private void Update()
    {
        stateMachin?.Update();
    }
    #region 용병관련
    void SpawnParty()
    {
        for(int i = 0; i < MercenaryManager.instance.party.Length; i++)
        {
            Mercenary mer = MercenaryManager.instance.party[i];

            if(mer == null)
                continue;

            BattleMercenary battlemer = Instantiate(battleMerPrefab, partyPos[i]);

            battlemer.SetData(mer);

            partys.Add(battlemer);
        }
    }

    public void DieMercenary(BattleMercenary battlemer)
    {
        Mercenary mer = battlemer.Data;

        MercenaryManager.instance.ReMoveMercenary(mer);
        MercenaryManager.instance.isReMoveParty(mer);
        TurnManager.instance.RemoveUnit(battlemer);
        partys.Remove(battlemer);
        Destroy(battlemer.gameObject);

        if (partys.Count == 0)
            GameOver();
    }
    void GameOver()
    {
        //전멸ui팝업띄우기
        SceneChanger.Instance.Town();
    }
    #endregion

    public void SpawnMonster()
    {
        for(int i = 0; i < monsPos.Length; i++)
        {
            Monster data = monsterData.monsterList.Find(x => x.id == spawnMonsterID[i]);

            BattleMonster mon = Instantiate(battleMonsterPrefab, monsPos[i]);

            mon.SetData(data);

            mons.Add(mon);
        }
    }
    public void DieMonster(BattleMonster mon)
    {
        TurnManager.instance.RemoveUnit(mon);
        mons.Remove(mon);
        Destroy(mon.gameObject);

        if(mons.Count == 0)
            Win();
    }
    void Win()
    {
        //몬스터포스2에 드랍아이템 들어 있는 상자스폰  
    }

    public List<BattleUnit> GetBattleUnit()
    {
        List<BattleUnit> units = new();

        units.AddRange(partys);
        units.AddRange(mons);

        return units;
    }
    public void ChangeState(IState state)
    {
        stateMachin.ChangeState(state);
    }
    public int GetUnitIndex(BattleUnit unit)
    {
        if(unit.UnitType == UnitType.Mercenary)
        {
            return partys.IndexOf((BattleMercenary)unit);
        }
        else
            return mons.IndexOf((BattleMonster)unit);
    }
    public List<BattleUnit> GetUnitsByType(UnitType type)
    {
        List<BattleUnit> units = new();

        if (type == UnitType.Mercenary)
        { 
            units.AddRange(partys);
        }
        else if (type == UnitType.Monster)
        {

            units.AddRange(mons);
        }

        return units;
    }
}
