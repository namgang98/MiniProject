using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Portait
{
    public GameObject portait;
    public Vector2 offset;
}
[CreateAssetMenu(fileName = "PortaitData", menuName = "Data/Portait")]
public class PortaitData : ScriptableObject
{
    public List<Portait> Portaits = new List<Portait>();
}
