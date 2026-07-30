using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{ 
    [SerializeField] Transform iconpos;
    [SerializeField] Button selectBtn;
    [SerializeField] ShopPanel shopPanel;
    public HaveWeapon weapon;
    public Item item;
    GameObject icon;

    public void SetPanel(ShopPanel p)
    {
        shopPanel = p;
    }
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

        shopPanel.Buy(this);
    }
    public void SellClick()
    {
        SellData data = new();

        data.weapon = weapon;
        data.item = item;

        shopPanel.AddSellItem(data);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item == null)
            return;

        if (weapon != null)
            TooltipManager.instance.Open(weapon);
        else
            TooltipManager.instance.Open(item);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.instance.Close();
    }


}
