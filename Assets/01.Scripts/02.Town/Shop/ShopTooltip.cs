using TMPro;
using UnityEngine;

public class ShopTooltip : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI priceText;

    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        gameObject.SetActive(false);
        TooltipManager.instance.SetToolPop(this);
    }
    public void Open(Item item)
    {
        nameText.text = item.name;
        priceText.text = item.price.ToString() + "G";

        gameObject.SetActive(true);
    }
    public void Open(HaveWeapon weapon)
    {
        nameText.text = weapon.name;
        priceText.text = weapon.GetPrice().ToString() + "G";

        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
