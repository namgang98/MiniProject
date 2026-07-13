using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HairData
{
    public GameObject hairID;
    public Vector2 offset;

}
[CreateAssetMenu(fileName = "CustomData", menuName = "Data/Custom")]
public class CustomData : ScriptableObject
{
    public List<HairData> hairs = new List<HairData>();

    public Color[] hairColors;

}
