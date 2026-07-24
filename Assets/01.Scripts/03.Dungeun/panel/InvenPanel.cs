using UnityEngine;
using UnityEngine.UI;

public class InvenPanel : MonoBehaviour
{
    //¿Œ∫•
    [SerializeField] Transform content;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] Button close;

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

}
