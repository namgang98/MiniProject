using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MercenaryManager : MonoBehaviour
{
    public static MercenaryManager instance;

    public List<Mercenary> haveMerList = new();
    public Mercenary[] party = new Mercenary[4];


    private void Awake()
    {
        if(instance==null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    #region 府胶飘包府
    public bool AddMercenary(Mercenary mer)
    {
        if (haveMerList.Count >= 6)
            return false;

        haveMerList.Add(mer);
        SaveLoadManager.instance.Save();
        return true;
    }
    public void ReMoveMercenary(Mercenary mer)
    {
        haveMerList.Remove(mer);
    }
    public void ClearMercenaryList()
    {
        haveMerList.Clear();

        for (int i = 0; i < party.Length; i++)
            party[i] = null;
    }
    #endregion

    #region 颇萍包府
    public bool IsAddParty(Mercenary mer)
    {
        if(IsInParty(mer))
            return false;

        for (int i = 0; i < party.Length; i++)
        {
            if (party[i] == null)
            {
                party[i] = mer;
                return true;
            }
        }
        return false;
    }
    public bool IsReMoveParty(Mercenary mer)
    {
        for(int i = 0; i < party.Length; i++)
        {
            if (party[i] == mer)
            {
                party[i] = null;
                return true;
            }                
        }
        return false;
    }
    public bool IsInParty(Mercenary mer)
    {
        for (int i = 0; i < party.Length; i++)
        {
            if (party[i] == mer)
                return true;
        }
        return false;
    }
    public void ClearParty()
    {
        for (int i = 0; i < party.Length; i++)
        {
            party[i] = null;
        }
    }
    public int PartyCount()
    {
        int count = 0;

        for(int i = 0; i < party.Length; i++)
        {
            if (party[i] != null)
                count++;
        }

        return count;
    }
    #endregion

}
