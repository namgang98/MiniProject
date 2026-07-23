using UnityEngine;

public class DungeunPanel : MonoBehaviour
{
    [SerializeField] GameObject merSlot;
    [SerializeField] Transform listContent;

    [SerializeField] DungeunPartySlot[] partySlot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        MercenaryManager.instance.ClearParty();

        Refresh();
    }

    public void Refresh()
    {
        RefreshMerList();
        RefreshParty();
    }

    public void RefreshMerList()
    {
       foreach(Transform child in listContent)
        {
            Destroy(child.gameObject);
        }

       foreach(Mercenary mer in MercenaryManager.instance.haveMerList)
        {
            GameObject slot = Instantiate(merSlot,listContent);
            slot.GetComponent<DungeunMerSlot>().SetData(mer, this);
        }
    }

    public void RefreshParty()
   {
        for(int i = 0; i < partySlot.Length; i++)
        {
            if (MercenaryManager.instance.party[i] != null)
            {
                partySlot[i].SetData(MercenaryManager.instance.party[i], this);
            }
            else
            {
                partySlot[i].Clear();
            }
        }        
    }

    public void AddParty(Mercenary mer)
    {
        if (MercenaryManager.instance.IsAddParty(mer))
        {
            Refresh();
        }

    }
    public void RemoveParty(Mercenary mer)
    {
        if(MercenaryManager.instance.IsReMoveParty(mer))
        Refresh();
    }
}
