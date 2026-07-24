using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DungeunUIManager : MonoBehaviour
{
    public static DungeunUIManager instance;

    [SerializeField] Canvas uiCanvas;
    [SerializeField] Canvas battleCanvas;
    [SerializeField] GameObject dim;
    [SerializeField] StatPanel statPanel;

    [SerializeField] GameObject chestpop;
    ChestB chest;

    [SerializeField] GameObject choisPanel;
    [SerializeField] GameObject nextBTN;

    [SerializeField] SkillPanel skillPanel;
    [SerializeField] ChestPanel chestPanel;

    [SerializeField] GameObject invenPanel;
    [SerializeField] Button invenBtn;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        invenBtn.onClick.AddListener(OpenInven);
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

        ChestPanel panel = chestpop.GetComponent<ChestPanel>();
        panel.SetChest(chest);
        dim.SetActive(true);
    }
    public void CloseChestPop()
    {
        chestpop.SetActive(false);
        dim.SetActive(false);
    }
    #endregion

    #region ÃÊÀÌ½ºÆÇ³Ú
    public void OpenChoisPanel()
    {
        choisPanel.SetActive(true);
    }
    public void CloseChoisPanel()
    {
        chestPanel.Clear();
        choisPanel.SetActive(false);
        nextBTN.SetActive(true);
    }
    public void OpenClearPanel()
    {
        chestPanel.Clear();
        choisPanel.SetActive(true);
        nextBTN.SetActive(false);
    }
    #endregion

    #region ÀÎº¥ÆÇ³Ú
    public void OpenInven()
    {
        invenPanel.SetActive(true);
        dim.SetActive(true);
    }
    public void CloseInven()
    {
        invenPanel.SetActive(false);
        dim.SetActive(false);
    }
    #endregion
}
