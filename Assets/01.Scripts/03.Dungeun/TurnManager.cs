using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;

    public List<BattleUnit> turnList = new();

    int turnCount;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    public void SetTurn(List<BattleUnit> units)
    {
        turnList.Clear();

        turnList.AddRange(units);

        turnList.Sort((a, b) =>b.Dex.CompareTo(a.Dex));

        turnCount = 0;
    }

    public BattleUnit Getcurrentunits()
    {
        return turnList[turnCount];
    }
    public void NextTurn()
    {
        turnCount++;

        if(turnCount >= turnList.Count )
            turnCount = 0;
    }

    public void RemoveUnit(BattleUnit unit)
    {
        int index = turnList.IndexOf(unit);

        if(index == -1)
            return;
        if (index < turnCount)
            turnCount--;

        turnList.Remove(unit);

        if(turnCount >= turnList.Count)
            turnCount = 0;
    }    

}
