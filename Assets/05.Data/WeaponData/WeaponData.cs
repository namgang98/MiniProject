using System;
using System.Collections.Generic;
using UnityEngine;

public enum weapons
{
    sword,
    bow,
    staff,
    dagger,
    mace
}
[Serializable]
public class Weapon
{
    public weapons weapons;
    public GradeData grade;
    public List<int> skillIID = new List<int>();
    public Weapon(weapons weapons, SkillData skills, GradeData grade)
    {
        this.weapons = weapons;
        this.grade = grade;
    }
}
[CreateAssetMenu(fileName = "Weapon", menuName = "Data/Weapon")]
public class WeaponData : ScriptableObject
{
    public SkillData skillData;
    public List<Weapon> weapons = new List<Weapon>();
}
