using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Chest
{
    public int id;
    public ChestB chest;
    public List<int> rewardids = new();

}
[CreateAssetMenu( fileName ="Chest", menuName ="Data/Chest")]
public class ChestData : ScriptableObject
{
  public List<Chest> chests = new();
}
