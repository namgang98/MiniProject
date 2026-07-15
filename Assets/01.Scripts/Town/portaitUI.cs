using UnityEngine;
using UnityEngine.UI;

public class portaitUI : MonoBehaviour
{
    [SerializeField] CustomData customData;
    [SerializeField] PortaitData portaitData;
    [SerializeField] Transform porpos;

    public void SetPortait(Mercenary mer)
    {
        foreach (Transform child in porpos)
            Destroy(child.gameObject);

        Portait portait = portaitData.Portaits[mer.hairNum];
        GameObject por = Instantiate(portait.portait, porpos, false);

        RectTransform rect = por.GetComponent<RectTransform>();
        rect.anchoredPosition = portait.offset;

        Image image = por.transform.Find("Hair").GetComponent<Image>();
        image.color = customData.hairColors[mer.hairColorNum];
    }
}
