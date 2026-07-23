using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestB : MonoBehaviour
{
    public Chest Data { get; private set; }
    public List<int> itemIDs = new();
    [SerializeField] Button Btn;

    private void Start()
    {
        Btn.onClick.AddListener(OpenChest);
    }

    public void OpenChest()
    {
        DungeunUIManager.instance.OpenChestPop(this);

    }
    public void SetData(Chest data)
    {
        Data = data;

        if(data != null && data.rewardids != null)
        {
            List<Item> winItems = ItemDropManager.instance.GetRandomSpawnItem(data.rewardids);

            itemIDs.Clear();
            foreach(var item in winItems)
            {
                itemIDs.Add(item.id);
            }

        }
    }
    public void RemoveItem(int id)
    {
        if(itemIDs.Contains(id))
        {
            itemIDs.Remove(id);
        }    
    }

}
