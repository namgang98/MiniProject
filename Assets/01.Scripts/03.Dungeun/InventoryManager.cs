using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Item SelectItem { get; private set; }
    public HaveWeapon SelectWeapon { get; private set; }

    public List<int> items = new();
    public List<int> equipments = new();
    public List<HaveWeapon> weapons = new();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void AddItem(int id)
    {
        items.Add(id);
    }
    public void AddEqui(int id)
    {
        equipments.Add(id);
    }
    public void AddWeapon(HaveWeapon weapon)
    {
        weapons.Add(weapon);
    }

    public void ClearInven()
    {
        items.Clear();
        equipments.Clear();
        weapons.Clear();
    }

    public void SetSelectWeapon(HaveWeapon weapon)
    {
        SelectWeapon = weapon;
    }
    public void SwapWeapon(Mercenary mer, HaveWeapon weapon)
    {
        if (mer.weapon != null)
            weapons.Add(mer.weapon);
        weapons.Remove(weapon);
        mer.weapon = weapon;

        SelectWeapon = null;

        SaveLoadManager.instance.Save();
    }
    public void SetSelectItem(Item item)
    {
        SelectItem = item;
    }
    public void UseItem(Item item)
    {
        items.Remove(item.id);
        SelectItem = null;
        SaveLoadManager.instance.Save();
    }

}
