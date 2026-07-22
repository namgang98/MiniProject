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

    [SerializeField] GameObject choisPanel;
    [SerializeField] GameObject nextBTN;

    [SerializeField] SkillPanel skillPanel;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    #region ½ºÅ³ÆÇ³Ú
    public void OpenSkillPanel(BattleMercenary mer)
    {
        skillPanel.gameObject.SetActive(true);
        skillPanel.SetSkillButton(mer);
    }
    public void CloseSkillPanel()
    {
        skillPanel.gameObject.SetActive(false);
    }
    #endregion

    #region ½ºÅÝÆÇ³Ú
    public void OpenStatPop(BattleMercenary mer)
    {
        statPanel.gameObject.SetActive(true);
        statPanel.SetStatPop(mer);
    }
    public void CloseStatPop()
    {
        statPanel.gameObject.SetActive(false);
    }
    #endregion

    #region »óÀÚÆÇ³Ú
    public void OpenChestPop(ChestB chest)
    {
        chestpop.SetActive(true);
        this.chest = chest;
    }
    public void CloseChestPop()
    {
        chestpop.SetActive(false);
    }
    #endregion

    #region ÃÊÀÌ½ºÆÇ³Ú
    public void OpenChoisPanel()
    {
        choisPanel.SetActive(true);
    }
    public void CloseChoisPanel()
    {
        choisPanel.SetActive(false);
        nextBTN.SetActive(true);
    }
    public void OpenClearPanel()
    {
        choisPanel.SetActive(true);
        nextBTN.SetActive(false);
    }
    #endregion
}
