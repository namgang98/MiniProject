using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DungeunUIManager : MonoBehaviour
{
    public static DungeunUIManager instance;

    [SerializeField] Canvas uiCanvas;
    [SerializeField] Canvas battleCanvas;

    [SerializeField] StatPanel statPanel;

    [SerializeField] GameObject chestpop;
    ChestB chest;

    [SerializeField] GameObject exitNextBTNPanel;

    [SerializeField] SkillPanel skillPanel;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    public void OpenSkillPanel(BattleMercenary mer)
    {
        skillPanel.gameObject.SetActive(true);
        skillPanel.SetSkillButton(mer);
    }
    public void CloseSkillPanel()
    {
        skillPanel.gameObject.SetActive(false);
    }
    public void OpenStatPop(BattleMercenary mer)
    {
        statPanel.gameObject.SetActive(true);
        statPanel.SetStatPop(mer);
    }
    public void CloseStatPop()
    {
        statPanel.gameObject.SetActive(false);
    }
    public void OpenChestPop(ChestB chest)
    {
        chestpop.SetActive(true);
        this.chest = chest;
    }
    public void CloseChestPop()
    {
        chestpop.SetActive(false);
    }

    public void OpenChoisPanel()
    {
        exitNextBTNPanel.SetActive(true);
    }
    public void CloseChoisPanel()
    {
        exitNextBTNPanel.SetActive(false);
    }

}
