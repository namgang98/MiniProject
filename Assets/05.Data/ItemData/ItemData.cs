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

[Serializable]
public class Item
{
    public int id;
    public ItemType type;
    public string name;
    public GameObject icon;
    public int price;
    public int amount;

    public float spawnChance;
}

[CreateAssetMenu(fileName ="Item", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
   public List<Item> items = new();
}
