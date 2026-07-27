using System;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Gold,
    Consumable,
    Weapon,
    Equipment
}
public enum ItemDropType
{
    Dungeun,
    Shop,
    All
}

[Serializable]
public class Item
{
    public int id;
    public ItemType type;
    public ItemDropType dropType;
    public string name;
    public GameObject icon;
    public int price;
    public int amount;
    public int velue;

    public float spawnChance;
}

[CreateAssetMenu(fileName ="Item", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
   public List<Item> items = new();
}
