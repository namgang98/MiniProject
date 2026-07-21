using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Stage
{
    public int stageID;
    public List<int> monsterIDs = new();
    public int chestid;


}
[CreateAssetMenu(fileName = "Stage", menuName = "Data/Stage")]
public class StageData : ScriptableObject
{
    public List<Stage> stages = new();
}
