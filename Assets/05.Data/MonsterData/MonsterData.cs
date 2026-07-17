using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Monster
{
    public int id;
    public string name;
    public float maxHp;
    public int gold;
    public int str;
    public int intel;
    public int dex;

    public List<int> skillID;

    public Monster(int id, string name, int maxHp, int gold, int str, int intel, int dex)
    {
        this.id = id;
        this.name = name;
        this.maxHp = maxHp;
        this.gold = gold;
        this.str = str;
        this.intel = intel;
        this.dex = dex;

        skillID = new List<int>();
    }
}
[CreateAssetMenu(fileName = "Monster", menuName = "Data/Monster")]
public class MonsterData : ScriptableObject
{
    public SkillData skillData;
    public List<Monster> monsterList = new List<Monster>();
}
