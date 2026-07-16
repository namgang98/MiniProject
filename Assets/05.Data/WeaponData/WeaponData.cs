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
    public SkillData skills;
    public GradeData grade;

    public Weapon(weapons weapons, SkillData skills, GradeData grade)
    {
        this.weapons = weapons;
        this.skills = skills;
        this.grade = grade;
    }
}
[CreateAssetMenu(fileName = "Weapon", menuName = "Data/Weapon")]
public class WeaponData : ScriptableObject
{
    public List<Weapon> weapons = new List<Weapon>();
}
