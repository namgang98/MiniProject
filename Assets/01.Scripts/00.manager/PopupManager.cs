using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PopupManager : MonoBehaviour
{
    public static PopupManager instance;

    #region 맴버
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

    [SerializeField] GameObject PartysZeroPop;
    GameObject PartysZeroPanel;

    [SerializeField] GameObject NotFourPop;
    GameObject NotFourPanel;

    [SerializeField] GameObject falsegold;
    GameObject falsegoldPanel;

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
        OpenPanel(optionPanel, uiCanvas, 1);
    }
    public void CloseOptionBtn()
    {
        ClosePanel(optionPanel, enCanvas, 2);
    }
    #endregion

    #region 용병inn고용창 나중에 던전들어갈때 생성된거 파괴하고새로생성코드만들기
    public void OpenMerInfoPanel(merDatamanger manager)
    {
        merInfoPanel = CreatePanel(merInfoPanel,merInfo);
        OpenPanel(merInfoPanel, uiCanvas, 1);
        merInfoPanel.GetComponent<MerInfoPanel>().SetData(manager);
    }
    public void CloseMerInfoBtn()
    {
        ClosePanel(merInfoPanel, enCanvas, 3);
    }
    #endregion

    #region 고용실패팝업관리
    public void OpenfalsePop()
    {
        falsePanel = CreatePanel(falsePanel,falsePop);
        OpenPanel(falsePanel,uiCanvas, 1);
    }
    public void CloseFalsePop()
    {
        ClosePanel(falsePanel,enCanvas, 2);
    }
    #endregion

    #region 타운메뉴팝업
    public void OpenMenuPopup()
    {
        menuPanel = CreatePanel(menuPanel,menuPop);
        OpenPanel(menuPanel,uiCanvas, 1);
    }
    public void CloseMenuBtn()
    {
        ClosePanel(menuPanel, enCanvas, 3);
    }
    #endregion

    #region 용병리스트팝업
    public void OpenMerListPopup()
    {
        merListPanel = CreatePanel(merListPanel,merListpop);
        OpenPanel(merListPanel, uiCanvas, 1);
    }
    public void CloseMerListPanel()
    {
        ClosePanel(merListPanel,enCanvas, 2);
    }
    #endregion

    #region 용병리스트스텟팝업
    public void OpenMerStatPopUp(Mercenary mer)
    {
        merStatPanel = CreatePanel(merStatPanel,merStatPop);
        OpenPanel(merStatPanel, uiCanvas, 1);
        merStatPanel.GetComponent<MerListInfoPanel>().SetData(mer);          
    }
    public void CloseMerStatPanel()
    {
        ClosePanel(merStatPanel, enCanvas,2);
    }
    #endregion

    #region 파티원없을시 뜨는 팝업
    public void OpenPartysZeroPop()
    {
        PartysZeroPanel = CreatePanel(PartysZeroPanel,PartysZeroPop);
        OpenPanel(PartysZeroPanel,uiCanvas,1);
    }
    public void ClosePartysZeroPanel()
    {
        ClosePanel(PartysZeroPanel,enCanvas, 3);
    }
    #endregion

    #region 파티원 4명이하일시 뜨는 팝업
    public void OpenPartysNotFourPop()
    {
        NotFourPanel = CreatePanel(NotFourPanel, NotFourPop);
        OpenPanel(NotFourPanel,uiCanvas,1);
    }
    public void ClosePartysNotFourPanel()
    {
        ClosePanel(NotFourPanel,enCanvas,3);
    }
    #endregion

    #region 골드부족팝업
    public void OpenFalseGoldPop()
    {
        falsegoldPanel = CreatePanel(falsegoldPanel, falsegold);
        OpenPanel(falsegoldPanel,uiCanvas,1);
    }
    public void CloseFalseGoldPanel()
    {
        ClosePanel(falsegoldPanel, enCanvas, 2);
    }
    #endregion

    #region 함수모음집
    GameObject CreatePanel(GameObject panel, GameObject pop)
    {
        if (panel == null)
            panel = Instantiate(pop, uiCanvas.transform);

        return panel;
    }
    public void OpenPanel(GameObject panel, Canvas canvas,int i) // 걍 1넣으면됨
    {
        ChangeParent(panel, canvas);
        panel.SetActive(true);

        SetDimPos(i);
        panel.transform.SetAsLastSibling();
    }
    public void ClosePanel(GameObject panel, Canvas canvas,int i) // 처음여는 팝업일경우 3 그다음 켜는팝업 2
    {
        panel.SetActive(false);
        ChangeParent(panel, canvas);
        SetDimPos(i);
    }
    void SetDimPos(int i)
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
