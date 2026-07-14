using Unity.VisualScripting;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager instance;

    Canvas uiCanvas;
    GameObject dim;

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

    #region 용병inn고용창 나중에 던전들어갈때 생성된거 파괴하고새로생성코드만들기
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



    public void SetCanvas(Canvas canvas)
    {
        uiCanvas = canvas;
    }
    public void SetDim(GameObject dim)
    {
        this.dim = dim;
    }

}
