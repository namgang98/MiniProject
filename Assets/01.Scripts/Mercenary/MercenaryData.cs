using System;
using UnityEngine;

[Serializable]
public class Mercenary
{
    public int uniqueID;
    public string name;
    public int level;
    public int exp;
    public int hp;
    public int maxHp;
    public int str;
    public int intel;
    public int dex;

    public int hairNum;
    public int hairColorNum;

    public Mercenary(int uniqueID, string name, int str, int intel, int dex, int hairNum, int hairColorNum)
    {
        this.uniqueID = uniqueID;
        this.name = name;

        this.level = 1;
        this.exp = 0;
        this.maxHp = 100;
        this.hp = maxHp;


        this.str = str;
        this.intel = intel;
        this.dex = dex;

        this.hairNum = hairNum;
        this.hairColorNum = hairColorNum;
    }
}
