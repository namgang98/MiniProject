using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public int gold;
    public List<int> items = new();
    public List<HaveWeapon> weapons = new();
    public List<Mercenary> mercenaries = new();
}
