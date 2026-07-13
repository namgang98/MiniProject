using UnityEngine;
using UnityEngine.UI;

public class merDatamanger : MonoBehaviour
{
    public Mercenary data;

    [SerializeField] Button btn;

    public void SetData(Mercenary data)
    {
        this.data = data;

    }
    private void Awake()
    {
        btn = GetComponentInChildren<Button>();
        btn.onClick.AddListener(OpenInfo);
    }

    public void OpenInfo()
    {
        PopupManager.instance.OpenMerInfoPanel(data);
    }
}
