using Unity.VisualScripting;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager instance;
    #region 
    Canvas uiCanvas;
    GameObject dim;

    [SerializeField] GameObject option;
    GameObject optionPanel;

    [SerializeField] GameObject merInfo;
    GameObject merInfoPanel;

    [SerializeField] GameObject falsePop;
    GameObject falsePanel;

    [SerializeField] GameObject menuPop;
    GameObject menuPanel;

    [SerializeField] GameObject merlistpop;
    GameObject merlistpanel;
    #endregion
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
    #region 용병inn고용창 나중에 던전들어갈때 생성된거 파괴하고새로생성코드만들기
    public void OpenMerInfoPanel(merDatamanger manager)
    {
        if (merInfoPanel == null)
            merInfoPanel = Instantiate(merInfo, uiCanvas.transform);
        else
            merInfoPanel.SetActive(true);

        dim.SetActive(true);
        dim.transform.SetAsLastSibling();
        merInfoPanel.transform.SetAsLastSibling();

        merInfoPanel.GetComponent<MerInfoPanel>().SetData(manager);
    }
    public void CloseMerInfoBtn()
    {
        merInfoPanel.SetActive(false);
        dim.SetActive(false);
    }
    #endregion
    #region 고용실패팝업관리
    public void OpenfalsePop()
    {
        if(falsePanel == null)
            falsePanel = Instantiate(falsePop, uiCanvas.transform);
        else
            falsePanel.SetActive(true);

        falsePanel.transform.SetAsLastSibling();
    }
    public void CloseFalsePop()
    {
        falsePanel.SetActive(false);
    }
    #endregion
    #region 타운메뉴팝업
    public void OpenMenuPopup()
    {
        if (menuPanel == null)
        {
            menuPanel = Instantiate(menuPop, uiCanvas.transform);
        }
        else
        {
            menuPanel.SetActive(true);
        }
        dim.SetActive(true);
        dim.transform.SetAsLastSibling();
        menuPanel.transform.SetAsLastSibling();
    }
    public void CloseMenuBtn()
    {
        menuPanel.SetActive(false);
        dim.SetActive(false);
    }
    #endregion
    #region 용병리스트팝업
    public void OpenMerListPopup()
    {
        if (merlistpanel == null)
            merlistpanel = Instantiate(merlistpanel,uiCanvas.transform);
        else
            merlistpanel.SetActive(true);
            
        dim.SetActive (true);
        dim.transform.SetAsLastSibling();
        merlistpanel.transform.SetAsLastSibling();
    }
    public void CloseMerListPanel()
    {
        merlistpanel.SetActive (false);
        dim.SetActive(false);
    }
    #endregion
    public void SetCanvas(Canvas canvas)
    {
        uiCanvas = canvas;
    }
    public void SetDim(GameObject dim)
    {
        this.dim = dim;
    }

}
