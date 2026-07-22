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

    [SerializeField] Transform[] partyPos;
    [SerializeField] Transform[] monsPos;

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
        StageManager.instance.LoadStage();

        SpawnParty();
        SpawnMonster();

        TurnManager.instance.SetTurn(BattleUnitManager.instance.GetBattleUnit());

        stateMachin.ChangeState(stateMachin.startState);
    }
    private void Update()
    {
        stateMachin?.Update();
    }
    public void Next()
    {
        StageManager.instance.NextStage();

        SpawnMonster();

        TurnManager.instance.SetTurn(BattleUnitManager.instance.GetBattleUnit());

        stateMachin.ChangeState(stateMachin.startState);
    }
    #region 스폰
    void SpawnParty()
    {
        for(int i = 0; i < MercenaryManager.instance.party.Length; i++)
        {
            Mercenary data = MercenaryManager.instance.party[i];

            if(data == null)
                continue;

            BattleMercenary mer = SpawnManager.instance.SpawnMercenary(partyPos[i],data);

            BattleUnitManager.instance.AddMer(mer);
        }
    }

    public void SpawnMonster()
    {
        Stage stage = StageManager.instance.Stage;
        for (int i = 0; i < stage.monsterIDs.Count; i++)
        {
            BattleMonster mon = SpawnManager.instance.SpawnMonster(monsPos[i], stage.monsterIDs[i]);
            BattleUnitManager.instance.AddMon(mon);
        }
    }

    #endregion
    #region 사망관련
    public void DieMercenary(BattleMercenary battlemer)
    {
        Mercenary mer = battlemer.Data;

        MercenaryManager.instance.ReMoveMercenary(mer);
        MercenaryManager.instance.IsReMoveParty(mer);
        TurnManager.instance.RemoveUnit(battlemer);
        BattleUnitManager.instance.RemoveMer(battlemer);

        if (BattleUnitManager.instance.IsPartysEmpty())
            GameOver();
    }
    void GameOver()
    {
        //전멸ui팝업띄우기
        SceneChanger.Instance.Town();
    }   
    public void DieMonster(BattleMonster mon)
    {
        AddExp(mon.Data.exp);
        TurnManager.instance.RemoveUnit(mon);
        BattleUnitManager.instance.RemoveMon(mon);
        if(BattleUnitManager.instance.IsMonsterEmpty())
            Win();
    }
    public void AddExp(int exp)
    {
        foreach (var mer in MercenaryManager.instance.party)
        {
            if (mer == null)
                continue;

            mer.exp += exp;
        }
    }
    void Win()
    {
        //몬스터포스2에 드랍아이템 들어 있는 상자스폰 
        SpawnChest();
    }
    #endregion
    public void SpawnChest()
    {
        Stage stage = StageManager.instance.Stage;

        SpawnManager.instance.SpawnChest(monsPos[1],stage.chestid);

    }
}
