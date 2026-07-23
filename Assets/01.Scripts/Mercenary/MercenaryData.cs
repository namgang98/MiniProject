using System;
using UnityEngine;

[Serializable]
public class Mercenary
{
    public int uniqueID;
    public string name;
    public int totalStr => str + weapon.str;
    public int totalInt => intel + weapon.intel;
    public int totalDex => dex + weapon.dex;

    public int level;
    public int exp;
    public int maxexp;
    public int statpoint;

    public float hp;
    public float maxHp;

    public int str;
    public int intel;
    public int dex;

    public int hairNum;
    public int hairColorNum;

    public HaveWeapon weapon;

    public Mercenary(int uniqueID, string name, int str, int intel, int dex, int hairNum, int hairColorNum)
    {
        this.uniqueID = uniqueID;
        this.name = name;

        this.level = 1;
        this.exp = 0;
        this.maxexp = 100;
        this.statpoint = 0;
        this.maxHp = 100;
        this.hp = maxHp;


        this.str = str;
        this.intel = intel;
        this.dex = dex;

        this.hairNum = hairNum;
        this.hairColorNum = hairColorNum;
    }
    public void AddEXP(int exp)
    {
        this.exp += exp;
        while(this.exp >= maxexp)
        {
            this.exp -= maxexp;
            LevelUP();
        }
    }
    public void LevelUP()
    {
        level++;
        statpoint += 3;
    }
}
