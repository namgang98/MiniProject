using UnityEngine;
using UnityEngine.UI;

public class ChestPanel : MonoBehaviour
{
    [SerializeField] Button closeBtn;
    [SerializeField] Transform content;
    [SerializeField] GameObject slotPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closeBtn.onClick.AddListener(CloseChest);
    }
    
    public void SetChest(ChestB chestb)
    {
        Clear();

        if(chestb == null)
            return;
        
        for(int i = 0; i < chestb.itemIDs.Count; i++)
        {
            Item item = ItemDropManager.instance.Getitem(chestb.itemIDs[i]);
            if(item != null)
            {    
                GameObject slots = Instantiate(slotPrefab, content);
                ChestSlot slot = slots.GetComponent<ChestSlot>();

                if (slot != null)
                    slot.SetData(item,chestb);                
            }
        }

    }

    public void CloseChest()
    {
        Clear();

        DungeunUIManager.instance.CloseChestPop();
        if (StageManager.instance.IsLastStage())
        {
            DungeunUIManager.instance.OpenClearPanel();
        }
        else
        {
            DungeunUIManager.instance.OpenChoisPanel();
        }
    }
    public void Clear()
    {
        if (content == null)
            return;

        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}
