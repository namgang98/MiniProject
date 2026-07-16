using System;
using System.Collections.Generic;
using UnityEngine;

public enum Grades
{
    Common,
    Rare,
    Epic,
    Legendary
}
[Serializable]
public class Grade
{
    public Grades grades;

    public int str;
    public int intel;
    public int dex;

    public int skillcount;
    public Grade(Grades grades, int str, int intel, int dex, int skillcount)
    {
        this.grades = grades;
        this.str = str;
        this.intel = intel;
        this.dex = dex;
        this.skillcount = skillcount;
    }
}
[CreateAssetMenu(fileName = "Grade", menuName = "Data/Grade")]
public class GradeData : ScriptableObject
{
    public List<Grade> grades = new();
}
