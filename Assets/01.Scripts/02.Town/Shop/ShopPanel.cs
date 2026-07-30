using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{

    [SerializeField] ShopSlot[] shopSlots;
    [SerializeField] ShopSlot[] sellSlots;
    [SerializeField] GameObject sellPanel;
    [SerializeField] SellPanel sell;
    
     List<SellData> sellItem = new();

    public int rerollprice = 50;

    public List<ShopData> shopDatas = new();
    public void OpenShop()
    { 
        if (shopDatas.Count == 0)
            RefreshShop();
        else
            RefreshShopUI();
    }

    public void RefreshShop()
    {
        shopDatas.Clear(); 
       List<Item> shopItems = ItemDropManager.instance.GetRandomShopItem(9);

        for(int i = 0; i < shopSlots.Length; i++)
        {
            ShopData data = new();

            if(shopItems[i].type == ItemType.Weapon)
            {
                data.haveWeapon = WeaponRandomTable.instance.CreateWeapon();
            }
            else
            {
               data.item = shopItems[i];
            }

            shopDatas.Add(data);
        }
        RefreshShopUI();
    }
    public void RefreshShopUI()
    {
        for (int i = 0; i < shopSlots.Length; i++)
        {
            if (shopDatas[i].isSoldOut)
            {
                shopSlots[i].Clear();
                continue;
            }

            if (shopDatas[i].haveWeapon != null)
            {
                shopSlots[i].SetWeaponicon(shopDatas[i].haveWeapon);
            }
            else
            {
                shopSlots[i].SetItems(shopDatas[i].item.id);
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
        int index = Array.IndexOf(shopSlots, slot);

        shopDatas[index].isSoldOut = true;

        slot.Clear();

        SaveLoadManager.instance.Save();
    }
    public void AddSellItem(SellData data)
    {
        if (data == null)
        {
            return;
        }

        if (data.weapon != null)
        {
            if (sellItem.Exists(x => x.weapon == data.weapon))
                return;
        }
        else if (data.item != null)
        {
            if(sellItem.Exists(x=>x.item == data.item))
                return;
        }
        sellItem.Add(data);

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

        SaveLoadManager.instance.Save();
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

[Serializable]
public class ShopData
{
    public Item item;
    public HaveWeapon haveWeapon;
    public bool isSoldOut;
}
