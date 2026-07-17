using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum stageType
{
    FirstFloor,
    Floor2th,
    Floor3th,
    Floor4th,
    Floor5th

}
public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    [SerializeField] BattleMercenary battleMerPrefab;
    [SerializeField] Transform[] partyPos;
    List<BattleMercenary> partys = new List<BattleMercenary>();

    [SerializeField] MonsterData monsterData;
    [SerializeField] BattleMonster battleMonsterPrefab;
    [SerializeField] Transform[] monsPos;
    [SerializeField] List<int> spawnMonsterID; 
    List<BattleMonster> mons = new List<BattleMonster>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    private void Start()
    {
        SpawnParty();
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
        Mercenary mer = battlemer.data;

        MercenaryManager.instance.ReMoveMercenary(mer);
        MercenaryManager.instance.isReMoveParty(mer);

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

    public void spawnMonster()
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
        mons.Remove(mon);
        Destroy(mon.gameObject);

        if(mons.Count == 0)
            Win();
    }
    void Win()
    {
        //몬스터포스2에 드랍아이템 들어 있는 상자스폰  
    }
}
