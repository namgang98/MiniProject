using UnityEngine;
using UnityEngine.UI;

public class InvenPanel : MonoBehaviour
{
    //¿Œ∫•
    [SerializeField] Transform content;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] Button close;

    [SerializeField] portaitUI[] portaits;
    [SerializeField] InvenSlot[] weaponslots;
    [SerializeField] GameObject weapons;
    [SerializeField] GameObject helmets;
    [SerializeField] GameObject armors;
    private void Awake()
    {
        close.onClick.AddListener(ClosePanel);
    }
    private void OnEnable()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        bool isBattle = BattleManager.instance.isBattle;

        BattleUI(isBattle);

        RefreshMerUI();

        Clear();

        foreach(HaveWeapon weapon in InventoryManager.instance.weapons)
        {
            GameObject slotP = Instantiate(slotPrefab,content);
            InvenSlot slot = slotP.GetComponent<InvenSlot>();

            if(slot != null)
            {
                slot.SetWeaponicon(weapon);
            }
        }

        foreach(int items in InventoryManager.instance.items)
        {
            GameObject slotP = Instantiate(slotPrefab, content);
            InvenSlot slot = slotP.GetComponent<InvenSlot>();
            if (slot != null)
            {
                slot.SetItems(items);
            }

        }
        foreach (int items in InventoryManager.instance.equipments)
        {
            GameObject slotP = Instantiate(slotPrefab, content);
            InvenSlot slot = slotP.GetComponent<InvenSlot>();
            if (slot != null)
            {
                slot.SetItems(items);
            }

        }
    }
    void RefreshMerUI()
    {
        Mercenary[] party = MercenaryManager.instance.party;

        for(int i = 0; i < party.Length;i++)
        {
            if(i < portaits.Length && portaits[i] != null)
            {
                if (party[i] != null)
                    portaits[i].SetPortait(party[i]);
                else
                    portaits[i].Clear();
            }

            if (i < weaponslots.Length && weaponslots != null)
            {
                    if (party[i] != null)
                    weaponslots[i].SetWeaponicon(party[i].weapon);
                    else
                    weaponslots[i].Clear();
                }
            }
        }
    public void Clear()
    {
        if (content == null)
            return;
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
    public void ClosePanel()
    {
        DungeunUIManager.instance.CloseInven();
    }
    void BattleUI(bool isbattle)
    {
        bool battle = !isbattle;

        weapons.gameObject.SetActive(battle);
        helmets.gameObject.SetActive(battle);
        armors.gameObject.SetActive(battle);
    }

}
