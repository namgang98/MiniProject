using UnityEngine;
using UnityEngine.UI;

public class MainBTNAdder : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] Button exitBtn;
    [SerializeField] Button optionBtn;
    [SerializeField] Canvas uicavas;
    [SerializeField] Canvas encanvas;
    [SerializeField] GameObject dim;
    private void Start()
    {
        startBtn.onClick.AddListener(SceneChanger.Instance.Town);
        exitBtn.onClick.AddListener(SceneChanger.Instance.ExitGame);
        optionBtn.onClick.AddListener(PopupManager.instance.OpenOptionPanel);
        PopupManager.instance.SetCanvas(uicavas);
        PopupManager.instance.SetEnCanvas(encanvas);
        PopupManager.instance.SetDim(dim);
    }
}
