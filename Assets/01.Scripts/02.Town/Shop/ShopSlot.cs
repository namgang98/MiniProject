using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] Transform iconpos;
    [SerializeField] Button selectBtn;
    public Item item;
    public HaveWeapon weapon;
    GameObject icon;

    public void SetWeaponicon(HaveWeapon data)
    {
        Clear();
        if (data == null)
            return;

        item = ItemDropManager.instance.Getitem(data.weaponiconID);

        icon = Instantiate(item.icon, iconpos);
        this.weapon = data;
        Image iconimg = icon.GetComponent<Image>();
        if (iconimg != null)
        {
            iconimg.color = Color.white;

            if (data.grade != null)
                iconimg.color = data.grade.gradeColor;
        }
    }
    public void SetItems(int itemID)
    {
        Clear();
        item = ItemDropManager.instance.Getitem(itemID);
        if (item != null)
        {
            icon = Instantiate(item.icon, iconpos);
        }

    }
    public void Clear()
    {
        item = null;
        weapon = null;

        if (icon != null)
        {
            Destroy(icon);
            icon = null;
        }
    }

    public void OnClick()
    {
        if (item == null)
            return;

        switch (item.type)
        {
            case ItemType.Consumable:
                InventoryManager.instance.SetSelectItem(item);
                break;
            case ItemType.Weapon:
                InventoryManager.instance.SetSelectWeapon(weapon);
                break;
        }
    }
}
