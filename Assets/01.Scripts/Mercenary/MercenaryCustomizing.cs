using UnityEngine;
using UnityEngine.UI;

public class MercenaryCustomizing : MonoBehaviour
{
    [SerializeField] CustomData customData;
    [SerializeField] Transform hairpos;

    public void SetMercenary(Mercenary mercenary)
    {
        foreach (Transform child in hairpos)
        {
            Destroy(child.gameObject);
        }
        HairData hairData = customData.hairs[mercenary.hairNum];
        GameObject hair = Instantiate(hairData.hairID,hairpos, false);
        
        RectTransform rect = hair.GetComponent<RectTransform>();
        rect.anchoredPosition = hairData.offset;

        Image hairimage = hair.GetComponent<Image>();
        hairimage.color = customData.hairColors[mercenary.hairColorNum];
    }
}
