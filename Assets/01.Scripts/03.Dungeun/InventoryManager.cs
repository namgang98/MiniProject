using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<int> items = new();
    public List<int> equipments = new();
    public List<HaveWeapon> weapons = new();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
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

    public void SwapWeapon(Mercenary mer, HaveWeapon weapon)
    {
        if (mer.weapon != null)
            weapons.Add(mer.weapon);
        weapons.Remove(weapon);
        mer.weapon = weapon;
    }
}
