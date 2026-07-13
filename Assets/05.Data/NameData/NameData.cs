using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NameInfo
{
    public string name;


}
[CreateAssetMenu(fileName = "Name", menuName = "Data/Name")]
public class NameData : ScriptableObject
{
    public List<NameInfo> names = new List<NameInfo>();

}
