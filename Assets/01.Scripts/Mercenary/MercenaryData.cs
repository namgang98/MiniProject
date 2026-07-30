using System;

[Serializable]
public class Mercenary
{
    public int UniqueID {  get; private set; }
    public string name;
    public int TotalStr => str + weapon.str;
    public int TotalInt => intel + weapon.intel;
    public int TotalDex => dex + weapon.dex;

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
        this.UniqueID = uniqueID;
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
