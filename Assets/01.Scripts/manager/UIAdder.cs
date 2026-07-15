using UnityEngine;

public class UIAdder : MonoBehaviour
{

    [SerializeField] Canvas canvas;
    [SerializeField] Canvas encanvas;
    [SerializeField] GameObject dim;

    private void Awake()
    {
        PopupManager.instance.SetCanvas(canvas);
        PopupManager.instance.SetEnCanvas(encanvas);
        PopupManager.instance.SetDim(dim);
    }
}
