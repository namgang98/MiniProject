using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Monster
{
    public int id;
    public string name;
    public float maxHp;
    public int str;
    public int intel;
    public int dex;

    [SerializeField] public BattleMonster prefab; 
    public List<int> skillID;
}
[CreateAssetMenu(fileName = "Monster", menuName = "Data/Monster")]
public class MonsterData : ScriptableObject
{
    public SkillData skillData;
    public List<Monster> monsterList = new();
}
