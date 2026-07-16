using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Skill
{
    public int id;
    public string name;
    public int damage;
}
[CreateAssetMenu(fileName = "Skill", menuName = "Data/Skill")]
public class SkillData : ScriptableObject
{
    public List<Skill> skills = new List<Skill>();
}
