using UnityEngine;
using UnityEngine.UI;

public class InvenSlot : MonoBehaviour
{
    [SerializeField] Transform iconpos;
    GameObject icon;
    
    public void SetWeaponicon(HaveWeapon data)
    {
        Clear();
        if (data == null)
            return;
        Item weapon = ItemDropManager.instance.Getitem(data.weaponiconID);

        icon = Instantiate(weapon.icon, iconpos);
        
        Image iconimg = icon.GetComponent<Image>();
        if(iconimg != null)
        {
            iconimg.color = Color.white;

            if (data.grade != null)
                iconimg.color = data.grade.gradeColor;
        }
    }
    public void SetItems(int itemID)
    {
        Clear();
        Item item = ItemDropManager.instance.Getitem(itemID);
        if (item != null)
        {
            icon = Instantiate(item.icon, iconpos);
        }

    }
    public void Clear()
    {
        if(icon != null)
        {
            Destroy(icon);
            icon = null;
        }
    }
}

