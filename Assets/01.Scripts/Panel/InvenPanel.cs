using UnityEngine;
using UnityEngine.UI;

public abstract class InvenPanel : MonoBehaviour
{
    [SerializeField] protected Transform content;
    [SerializeField] protected InvenSlot slotPrefab;
    [SerializeField] protected Button close;

    [SerializeField] protected PortaitSlot[] portaitSlots;

    protected void Awake()
    {
        close.onClick.AddListener(ClosePanel);
    }
    protected void OnEnable()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        RefreshMerUI();

        Clear();

        foreach (HaveWeapon weapon in InventoryManager.instance.weapons)
        {
            InvenSlot slot = Instantiate(slotPrefab, content);

            if (slot != null)
            {
                slot.SetWeaponicon(weapon);
            }
        }

        foreach (int items in InventoryManager.instance.items)
        {
            InvenSlot slot = Instantiate(slotPrefab, content);
            if (slot != null)
            {
                slot.SetItems(items);
            }

        }
        foreach (int items in InventoryManager.instance.equipments)
        {
            InvenSlot slot = Instantiate(slotPrefab, content);
            if (slot != null)
            {
                slot.SetItems(items);
            }

        }
    }
    protected abstract void RefreshMerUI();
    public void Clear()
    {
        if (content == null)
            return;
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
    protected abstract void ClosePanel();

}
