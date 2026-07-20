using UnityEngine;
using UnityEngine.UI;

public class TownBTNAdder : MonoBehaviour
{
    [SerializeField] Button menuBtn;
    [SerializeField] Canvas uicavas;
    [SerializeField] Canvas encanvas;
    [SerializeField] GameObject dim;
    private void Start()
    {
       menuBtn.onClick.AddListener(PopupManager.instance.OpenMenuPopup);
        PopupManager.instance.SetCanvas(uicavas);
        PopupManager.instance.SetEnCanvas(encanvas);
        PopupManager.instance.SetDim(dim);
    }
}
