using System;
using System.Collections.Generic;
using UnityEngine;

public class SellPanel : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] ShopSlot slotPrefab;
    [SerializeField] ShopPanel shopPanel;

    private void OnEnable()
    {
        Open();
    }
    public void Open()
    {
       RefreshUI();
    }
    public void RefreshUI()
    {
        Clear();

        foreach(var weapon in InventoryManager.instance.weapons)
        {
            ShopSlot slot = Instantiate(slotPrefab,content);
            slot.SetWeaponicon(weapon);
            slot.SetPanel(shopPanel);
        }
        foreach(var id in InventoryManager.instance.items)
        {
            ShopSlot slot = Instantiate(slotPrefab, content);
            slot.SetItems(id);
            slot.SetPanel(shopPanel);
        }
        foreach (var id in InventoryManager.instance.equipments)
        {
            ShopSlot slot = Instantiate(slotPrefab, content);
            slot.SetItems(id);
            slot.SetPanel(shopPanel);
        }
    }
    public void Clear()
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}
[Serializable]
public class SellData
{
    public Item item;
    public HaveWeapon weapon;

}
