using Unity.VisualScripting;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager instance;

    [SerializeField] Canvas uiCanvas;
    [SerializeField ]GameObject dim;

    [SerializeField] GameObject option;
    GameObject optionPanel;

    [SerializeField] GameObject merInfo;
    GameObject merInfoPanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    #region 옵션판낼코드
    public void OpenOptionPanel()
    {      
        if (optionPanel == null)
        {
            optionPanel = Instantiate(option, uiCanvas.transform);
        }
        else
        {
            optionPanel.SetActive(true);
        }
        dim.SetActive(true);
        dim.transform.SetAsLastSibling(); 
        optionPanel.transform.SetAsLastSibling();  
    }
    public void CloseOptionBtn()
    {
        optionPanel.SetActive(false);
        dim.SetActive(false);
    }
    #endregion

    #region 용병inn고용창
    public void OpenMerInfoPanel(Mercenary Data)
    {
        if (merInfoPanel == null)
            merInfoPanel = Instantiate(merInfo, uiCanvas.transform);
        else
            merInfoPanel.SetActive(true);

        dim.SetActive(true);
        dim.transform.SetAsLastSibling();
        merInfoPanel.transform.SetAsLastSibling();

        merInfoPanel.GetComponent<MerInfoPanel>().SetData(Data);
    }
    public void CloseMerInfoBtn()
    {
        merInfoPanel.SetActive(false);
        dim.SetActive(false);
    }
    #endregion


}
