using System;
using System.Collections.Generic;
using UnityEngine;

public class MercenaryManager : MonoBehaviour
{
    public static MercenaryManager instance;

    public List<Mercenary> haveMerList = new List<Mercenary>();
    public Mercenary[] party = new Mercenary[4];


    private void Awake()
    {
        if(instance==null)
            instance = this;
        else
            Destroy(instance);
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool AddMercenary(Mercenary mer)
    {
        if (haveMerList.Count >= 6)
            return false;
        else
            haveMerList.Add(mer);
            return true;
    }
    public void ReMoveMercenary(Mercenary mer)
    {
        haveMerList.Remove(mer);
    }

    public void AddParty(Mercenary mer)
    {
        for(int i = 0; i < party.Length; i++)
        {
            if (party[i] == null)
            {
                party[i] = mer;
            }
        }
    }








    public void ClearMercenaryList()
    {
        haveMerList.Clear();
    }
}
