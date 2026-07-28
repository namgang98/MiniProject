using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] ShopSlot[] shopSlots;
    [SerializeField] ShopSlot[] sellSlots;
    [SerializeField] GameObject sellPanel;
    [SerializeField] SellPanel sell;
    List<Item> shopItem = new();
    List<SellData> sellItem = new();

    public int rerollprice = 50;

    public void OpenSop()
    {
        RefreshShop();
    }

    public void RefreshShop()
    {
        shopItem = ItemDropManager.instance.GetRandomShopItem(9);

        for(int i = 0; i < shopSlots.Length; i++)
        {
            if(i >= shopItem.Count)
            {
                shopSlots[i].Clear();
                continue;
            }

            if(shopItem[i].type == ItemType.Weapon)
            {
                HaveWeapon weapon = WeaponRandomTable.instance.CreateWeapon();
                shopSlots[i].SetWeaponicon(weapon);
            }
            else
            {
                shopSlots[i].SetItems(shopItem[i].id);
            }
        }
    }
    public void Buy(ShopSlot slot)
    {
        if(slot.item == null)
            return;
        int price = slot.item.price;
        if (slot.item.type == ItemType.Weapon)
            price = slot.weapon.GetPrice();    

        if (GoldManager.instance.HaveGold < price)
        {
            StartCoroutine(EnoughGoldPopup());
            return;
        }

        GoldManager.instance.UseGold(price);
        switch (slot.item.type)
        {
            case ItemType.Consumable:
                InventoryManager.instance.AddItem(slot.item.id);
                break;
            case ItemType.Equipment:
                InventoryManager.instance.AddEqui(slot.item.id);
                break;
            case ItemType.Weapon:
                InventoryManager.instance.AddWeapon(slot.weapon);
                break;
        }
        slot.Clear();

        SaveLoadManager.instance.Save();
    }
    public void AddSellItem(SellData item)
    {
        if(item == null)
            return;
        if (sellItem.Contains(item))
            return;
        sellItem.Add(item);

        RefreshSellUI();
    }
    public void RefreshSellUI()
    {
        for(int i = 0; i < sellSlots.Length; i++)
        {
            if(i >= sellItem.Count)
            {
                sellSlots[i].Clear();
                continue;
            }
            if (sellItem[i].weapon != null)
            {
                sellSlots[i].SetItems(sellItem[i].weapon.weaponiconID);
            }
            else
            {
                sellSlots[i].SetItems(sellItem[i].item.id);
            }

        }
    }
    public void Sell()
    {
        foreach (var data in sellItem)
        {
            if (data.weapon != null)
            {
                GoldManager.instance.GetGold(data.weapon.GetPrice());

                InventoryManager.instance.weapons.Remove(data.weapon);
            }
            else
            {
                GoldManager.instance.GetGold(data.item.price);

                switch (data.item.type)
                {
                    case ItemType.Consumable:
                        InventoryManager.instance.items.Remove(data.item.id);
                        break;

                    case ItemType.Equipment:
                        InventoryManager.instance.equipments.Remove(data.item.id);
                        break;
                }
            }
        }

        sellItem.Clear();
        RefreshSellUI();
        sell.RefreshUI();
        SaveLoadManager.instance.Save();
        sellPanel.SetActive(false);
    }
    public void RemoveSellItem(SellData data)
    {
        sellItem.Remove(data);
        RefreshSellUI();
    }
    public void Reroll()
    {
        if (GoldManager.instance.HaveGold < rerollprice)
            return;
        GoldManager.instance.UseGold(rerollprice);
        RefreshShop();
    }

    public void OpenSellPanel()
    {
        sellPanel.SetActive(true);
    }

    IEnumerator EnoughGoldPopup()
    {
        PopupManager.instance.OpenFalseGoldPop();
        yield return new WaitForSeconds(1.5f);
        PopupManager.instance.CloseFalseGoldPanel();
    }
}
