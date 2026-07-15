using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PopupManager : MonoBehaviour
{
    public static PopupManager instance;
    #region 
    Canvas uiCanvas;
    Canvas enCanvas;
    GameObject dim;

    [SerializeField] GameObject option;
    GameObject optionPanel;

    [SerializeField] GameObject merInfo;
    GameObject merInfoPanel;

    [SerializeField] GameObject falsePop;
    GameObject falsePanel;

    [SerializeField] GameObject menuPop;
    GameObject menuPanel;

    [SerializeField] GameObject merListpop;
    GameObject merListPanel;

    [SerializeField] GameObject merStatPop;
    GameObject merStatPanel;
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
        optionPanel = CreatePanel(optionPanel,option);
        Openpanel(optionPanel, uiCanvas, 1);
    }
    public void CloseOptionBtn()
    {
        Closepanel(optionPanel, enCanvas, 2);
    }
    #endregion

    #region 용병inn고용창 나중에 던전들어갈때 생성된거 파괴하고새로생성코드만들기
    public void OpenMerInfoPanel(merDatamanger manager)
    {
        merInfoPanel = CreatePanel(merInfoPanel,merInfo);
        Openpanel(merInfoPanel, uiCanvas, 1);
        merInfoPanel.GetComponent<MerInfoPanel>().SetData(manager);
    }
    public void CloseMerInfoBtn()
    {
        Closepanel(merInfoPanel, enCanvas, 3);
    }
    #endregion

    #region 고용실패팝업관리
    public void OpenfalsePop()
    {
        falsePanel = CreatePanel(falsePanel,falsePop);
        Openpanel(falsePanel,uiCanvas, 1);
    }
    public void CloseFalsePop()
    {
        Closepanel(falsePanel,enCanvas, 2);
    }
    #endregion

    #region 타운메뉴팝업
    public void OpenMenuPopup()
    {
        menuPanel = CreatePanel(menuPanel,menuPop);
        Openpanel(menuPanel,uiCanvas, 1);
    }
    public void CloseMenuBtn()
    {
        Closepanel(menuPanel, enCanvas, 3);
    }
    #endregion

    #region 용병리스트팝업
    public void OpenMerListPopup()
    {
        merListPanel = CreatePanel(merListPanel,merListpop);
        Openpanel(merListPanel, uiCanvas, 1);
    }
    public void CloseMerListPanel()
    {
        Closepanel(merListPanel,enCanvas, 2);
    }
    #endregion

    #region 용병리스트스텟팝업
    public void OpenMerStatPopUp(Mercenary mer)
    {
        merStatPanel = CreatePanel(merStatPanel,merStatPop);
        Openpanel(merStatPanel, uiCanvas, 1);
        merStatPanel.GetComponent<merlistinfoPanel>().SetData(mer);          
    }
    public void CloseMerStatPanel()
    {
        Closepanel(merStatPanel, enCanvas,2);
    }
    #endregion

    #region 함수모음집
    GameObject CreatePanel(GameObject panel, GameObject pop)
    {
        if (panel == null)
            panel = Instantiate(pop, uiCanvas.transform);

        return panel;
    }
    public void Openpanel(GameObject panel, Canvas canvas,int i)
    {
        ChangeParent(panel, canvas);
        panel.SetActive(true);

        setdimpos(i);
        panel.transform.SetAsLastSibling();
    }
    public void Closepanel(GameObject panel, Canvas canvas,int i)
    {
        panel.SetActive(false);
        ChangeParent(panel, canvas);
        setdimpos(i);
    }
    void setdimpos(int i)
    {
        dim.transform.SetSiblingIndex(uiCanvas.transform.childCount - i);
    }
    public void ChangeParent(GameObject panel, Canvas canvas)
    {
        panel.transform.SetParent(canvas.transform, false);
    }
    #endregion

    #region 캔버스연결함수
    public void SetCanvas(Canvas canvas)
    {
        uiCanvas = canvas;
    }
    public void SetDim(GameObject dim)
    {
        this.dim = dim;
    }
    public void SetEnCanvas(Canvas canvas)
    {
        enCanvas = canvas;
    }
    #endregion
}
