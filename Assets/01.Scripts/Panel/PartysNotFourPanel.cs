using UnityEngine;
using UnityEngine.UI;

public class PartysNotFourPanel : MonoBehaviour
{
    [SerializeField] Button yes;
    [SerializeField] Button no;

    public void YesButton()
    {
        PopupManager.instance.ClosePartysNotFourPanel();
        SceneChanger.Instance.Explore();
    }

    public void NoButton()
    {
        PopupManager.instance.ClosePartysNotFourPanel();
    }
}
