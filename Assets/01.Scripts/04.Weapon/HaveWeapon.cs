using System;
using UnityEngine;

[Serializable]
public class HaveWeapon
{
    public int uniqueID;
    public int weaponID;

    public Grade grade;

    public int str;
    public int intel;
    public int dex;

    public HaveWeapon(int uniqueID, int weaponID, Grade grade, int str, int intel, int dex)
    {
        this.uniqueID = uniqueID;
        this.weaponID = weaponID;
        this.grade = grade;
        this.str = str;
        this.intel = intel;
        this.dex = dex;
    }
}
