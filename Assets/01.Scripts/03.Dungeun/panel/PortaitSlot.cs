using UnityEngine;
using UnityEngine.UI;

public class PortaitSlot : MonoBehaviour
{
    Mercenary mer;
    [SerializeField] Button useBtn;
    [SerializeField] Button swapWeaponBtn;
    [SerializeField] InvenPanel inven;

    [SerializeField] PortaitUI portaitSlot;
    [SerializeField] InvenSlot weaponSlot;
    [SerializeField] InvenSlot helmetSlot;
    [SerializeField] InvenSlot armorSlot;


    private void Start()
    {
        useBtn.onClick.AddListener(UseItem);
        swapWeaponBtn.onClick.AddListener(SwapWeapon);
    }
    public void SetData(Mercenary data)
    {
        mer = data;
               
        if(mer == null)
        {
            Clear();
            return;
        }

        useBtn.interactable = true;
        swapWeaponBtn.interactable = true;
        portaitSlot.SetPortait(mer);
        helmetSlot.gameObject.SetActive(false);
        armorSlot.gameObject.SetActive(false);

        if (mer.weapon != null)
        {
            weaponSlot.gameObject.SetActive(true);
            weaponSlot.SetWeaponicon(mer.weapon);
        }
        else
            weaponSlot.gameObject.SetActive(false);
        
    }
    void Clear()
    {
        mer = null;

        portaitSlot.Clear();
        weaponSlot.Clear();
        armorSlot.Clear();
        helmetSlot.Clear();

        helmetSlot.gameObject.SetActive(false);
        armorSlot.gameObject.SetActive(false);
        weaponSlot.gameObject.SetActive(false);

        useBtn.interactable = false;
        swapWeaponBtn.interactable = false;
    }
    public void UseItem()
    {
        Item item = InventoryManager.instance.SelectItem;

        if (item == null)
            return;
        BattleMercenary bmer = BattleUnitManager.instance.FindBattlemer(mer);
       
        if (bmer == null)
            return;

        if (item.type == ItemType.Consumable)
        {
            if(bmer.Data.hp >= bmer.Data.maxHp)
                return;

            bmer.Heal(item.velue);
            InventoryManager.instance.UseItem(item);
            inven.RefreshUI();
        }
    }
    public void SwapWeapon()
    {
        if(mer == null)
            return;
        if (InventoryManager.instance.SelectWeapon == null)
            return;

        InventoryManager.instance.SwapWeapon(mer, InventoryManager.instance.SelectWeapon);
        inven.RefreshUI();

    }
}
