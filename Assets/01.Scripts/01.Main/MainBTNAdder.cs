using UnityEngine;
using UnityEngine.UI;

public class MainBTNAdder : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] Button exitBtn;
    [SerializeField] Button optionBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(SceneChanger.Instance.Town);
        exitBtn.onClick.AddListener(SceneChanger.Instance.ExitGame);
        optionBtn.onClick.AddListener(PopupManager.instance.OpenOptionPanel);
    }
}
