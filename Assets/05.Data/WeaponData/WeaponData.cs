using System;
using System.Collections.Generic;
using UnityEngine;

public enum Weapons
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
    public int id;
    public string name;
    public Weapons weapons;
    public GradeData grade;
    public List<int> skillID = new();
    public Weapon(Weapons weapons,GradeData grade)
    {
        this.weapons = weapons;
        this.grade = grade;
    }
}
[CreateAssetMenu(fileName = "Weapon", menuName = "Data/Weapon")]
public class WeaponData : ScriptableObject
{
    public SkillData skillData;
    public List<Weapon> weapons = new();
}
