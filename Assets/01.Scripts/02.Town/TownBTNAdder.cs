using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TownBTNAdder : MonoBehaviour
{
    [SerializeField] Button menuBtn;
    [SerializeField] TextMeshProUGUI goldtext;
    [SerializeField] Canvas uicavas;
    [SerializeField] Canvas encanvas;
    [SerializeField] GameObject dim;
    [SerializeField] GameObject dungunpanel;
    private void Start()
    {
        menuBtn.onClick.AddListener(PopupManager.instance.OpenMenuPopup);
        GoldManager.instance.SetGoldUI(goldtext);
        PopupManager.instance.SetCanvas(uicavas);
        PopupManager.instance.SetEnCanvas(encanvas);
        PopupManager.instance.SetDim(dim);
        PopupManager.instance.SetDungeunPanel(dungunpanel);
    }
}
