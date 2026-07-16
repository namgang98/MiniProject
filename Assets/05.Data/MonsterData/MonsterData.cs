using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Monster
{
    public int id;
    public string name;
    public int hp;
    public int gold;
    public int dex;

    public Monster(int id, string name, int hp, int gold, int dex)
    {
        this.id = id;
        this.name = name;
        this.hp = hp;
        this.gold = gold;
        this.dex = dex;
    }
}
[CreateAssetMenu(fileName = "Monster", menuName = "Data/Monster")]
public class MonsterData : ScriptableObject
{

    public List<Monster> monsterList = new List<Monster>();



}
