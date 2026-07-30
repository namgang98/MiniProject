using System;
using System.Collections.Generic;
using UnityEngine;
public enum AttackType
{
    Attack,
    Heal
}
public enum StatType
{
    Str,
    Int,
    Dex,
}
public enum EffectType
{
    None,
    Poison
}
public enum TargetType
{
    Self,
    Teamone,
    Teamall,
    Enemyone,
    Enemyall,
}
public enum TargetPosType
{
    Front,
    All
}
public enum AttackAniType
{
    attack,
    skill
}
[Serializable]
public class Skill
{
    public int id;
    public string name;
    public int damage;

    public AttackType atkType;
    public StatType statType;
    public EffectType effectType;
    public TargetType targetType;
    public TargetPosType posType;
    public AttackAniType aniType;
}
[CreateAssetMenu(fileName = "Skill", menuName = "Data/Skill")]
public class SkillData : ScriptableObject
{
    public List<Skill> skills = new();
}
