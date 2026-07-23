using System.Collections.Generic;
using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    public static ItemDropManager instance;

    [SerializeField] ItemData itemData;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    public Item Getitem(int id)
    {
        return itemData.items.Find(x => x.id == id);
    }

    public List<Item> GetRandomSpawnItem(List<int> rewardIDs)
    {
        List<Item> dropItems = new();

        foreach(int id in rewardIDs)
        {
            Item item = Getitem(id);
            if (item == null)
                continue;

            float roll = Random.Range(0f, 100f);
            if(roll <= item.spawnChance)
            {
                dropItems.Add(item);
            }
        }

        return dropItems;
    }
}
