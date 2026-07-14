using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] Button closeBtn;
    [SerializeField] Button optionBtn;
    [SerializeField] Button merBtn;
    [SerializeField] Button chestBtn;

    public void opoption()
    {
        PopupManager.instance.OpenOptionPanel();
    }
    public void CloseBtn()
    {
        PopupManager.instance.CloseMenuBtn();
    }
    public void openmerlist()
    {
        PopupManager.instance.OpenMerListPopup();
    }
}
