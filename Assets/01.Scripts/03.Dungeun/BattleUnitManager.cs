using System.Collections.Generic;
using UnityEngine;

public class BattleUnitManager : MonoBehaviour
{
    public static BattleUnitManager instance;

    public List<BattleMercenary> partys = new();
    public List<BattleMonster> monsters = new();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    #region 리스트 추가,제거
    public void AddMer(BattleMercenary mer)
    {
        partys.Add(mer);
    }
    public void AddMon(BattleMonster mon)
    {
        monsters.Add(mon);
    }
    public void RemoveMer(BattleMercenary mer)
    {
        partys.Remove(mer);
        Destroy(mer.gameObject);
    }
    public void RemoveMon(BattleMonster mon)
    { 
        monsters.Remove(mon);
        Destroy(mon.gameObject);
    }
    #endregion

    // 턴순서 만들기를 위한 한개의 리스트
    public List<BattleUnit> GetBattleUnit()
    {
        List<BattleUnit> units = new();

        units.AddRange(partys);
        units.AddRange(monsters);

        return units;
    }

    // 타겟 지정시 필요한 타입분리
    public List<BattleUnit> GetUnitsByType(UnitType type)
    {
        List<BattleUnit> units = new();

        if (type == UnitType.Mercenary)
        {
            units.AddRange(partys);
        }
        else if (type == UnitType.Monster)
        {

            units.AddRange(monsters);
        }

        return units;
    }

    // 유닛순서
    public int GetUnitIndex(BattleUnit unit)
    {
        if (unit == null)
            return -1;
        switch(unit.UnitType)
        {
            case UnitType.Mercenary:
            return partys.IndexOf((BattleMercenary)unit);
      
            case UnitType.Monster:
            return monsters.IndexOf((BattleMonster)unit);
        
            default:
                return -1;
        }
    }

    public bool IsPartysEmpty()
    {
        return partys.Count == 0;
    }
    public bool IsMonsterEmpty()
    {
        return monsters.Count == 0;
    }

    public void ExitFullHeal()
    {
        foreach(BattleMercenary mer in partys)
        {
            mer.FullHeal();
        }
    }

    public void OffTurnMask()
    {

        foreach (BattleMercenary mer in partys)
        {
            mer.SetTurnMark(false);
        }
        foreach(BattleMonster mon in monsters)
        {
            mon.SetTurnMark(false);
        }
    }
}
