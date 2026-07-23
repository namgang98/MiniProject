using UnityEngine;
using UnityEngine.UI;

public class ChestPanel : MonoBehaviour
{
    [SerializeField] Button closeBtn;
    [SerializeField] ChestSlot[] slots;

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
        
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < chestb.itemIDs.Count)
            {            
                Item item = ItemDropManager.instance.Getitem(chestb.itemIDs[i]);
                if (item != null)
                {
                    slots[i].SetData(item, chestb);
                }
                else
                {
                    slots[i].gameObject.SetActive(false);
                }
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
        if (slots == null)
            return;
        foreach (var slot in slots)
        {
            slot.Clear();
        }
    }
}
