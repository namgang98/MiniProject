using UnityEngine;
using UnityEngine.UI;

public class ChestSlot : MonoBehaviour
{
    Item data;
    ChestB chest;
    HaveWeapon weapon;
    [SerializeField] Transform iconPos;

    GameObject currentIcon;

    public void SetData(Item item, ChestB chestB)
    {
        data = item;
        chest = chestB;
        if(item == null)
        {
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(true);

        if (currentIcon != null)
            Destroy(currentIcon);

        currentIcon = Instantiate(item.icon, iconPos);

        Image iconimg = currentIcon.GetComponent<Image>();

        if(iconimg != null)
        {
            iconimg.color = Color.white;
            if (item.type == ItemType.Weapon)
            { 
                weapon = WeaponRandomTable.instance.CreateWeapon();
                iconimg.color = weapon.grade.gradeColor;
            }
        }
    }

    public void Onclick()
    {
        switch(data.type)
        {
            case ItemType.Gold:
                GoldManager.instance.GetGold(data.amount);
                break;
            case ItemType.Consumable:
                InventoryManager.instance.AddItem(data.id);
                break;
            case ItemType.Weapon:
                InventoryManager.instance.AddWeapon(weapon);
                break;
            case ItemType.Equipment:
                InventoryManager.instance.AddEqui(data.id);
                break;

        }
        if(chest != null)
            chest.RemoveItem(data.id);

        Clear();
    }
    public void Clear()
    {
        data = null;
        chest = null;
        if(currentIcon != null)
        {
            Destroy(currentIcon);
            currentIcon = null;
        }
        gameObject.SetActive(false);
    }

}
