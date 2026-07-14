using UnityEngine;

public class UIAdder : MonoBehaviour
{

    [SerializeField] Canvas canvas;
    [SerializeField] GameObject dim;

    private void Awake()
    {
        PopupManager.instance.SetCanvas(canvas);
        PopupManager.instance.SetDim(dim);
    }
}
