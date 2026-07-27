using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] Button closeBtn;
    [SerializeField] Button optionBtn;
    [SerializeField] Button merBtn;
    [SerializeField] Button chestBtn;

    private void Awake()
    {
        if (merBtn != null)
            merBtn.onClick.AddListener(OpenMerList);
        if (chestBtn != null)
            chestBtn.onClick.AddListener(OpenInven);
        if (optionBtn != null)
            optionBtn.onClick.AddListener(OpenOption);
        if (closeBtn != null)
            closeBtn.onClick.AddListener(CloseBtn);
    }

    public void OpenOption()
    {
        PopupManager.instance.OpenOptionPanel();
    }
    public void CloseBtn()
    {
        PopupManager.instance.CloseMenuBtn();
    }
    public void OpenMerList()
    {
        PopupManager.instance.OpenMerListPopup();
    }
    public void OpenInven()
    {
        PopupManager.instance.OpenInven();
    }
    public void SaveGoMain()
    {
        //세이브코드
        SceneChanger.Instance.Main();
    }
}
