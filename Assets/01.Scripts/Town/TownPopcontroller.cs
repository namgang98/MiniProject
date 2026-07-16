using UnityEngine;
using UnityEngine.UI;

public class TownPopcontroller : MonoBehaviour
{
    [SerializeField] Button innINBtn;
    [SerializeField] Button ShopINBtn;
    [SerializeField] Button DungeunINBtn;
    [SerializeField] Button innOUTBtn;
    [SerializeField] Button ShopOUTBtn;
    [SerializeField] Button DungeunOUTBtn;

    [SerializeField] GameObject menuBtn;
    [SerializeField] GameObject townPanel;
    [SerializeField] GameObject innPanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject dungeunPanel;
    
    [SerializeField] Canvas enCanvas;
    [SerializeField] Canvas uiCanvas;

    public void InnIN()
    {
        PanelController(innPanel,townPanel,uiCanvas,enCanvas);
        SoundManager.instance.PlayBGM(BGMType.innBGM);
    }
    public void InnOUT()
    {
        PanelController(townPanel,innPanel,uiCanvas,enCanvas);
        SoundManager.instance.PlayBGM(BGMType.townBGM);
    }

    public void DungeunIN()
    {
        PanelController(dungeunPanel,townPanel,uiCanvas,enCanvas);
    }
    public void DungeunOUT()
    {
        PanelController(townPanel,dungeunPanel,uiCanvas,enCanvas);
    }
    public void ShopIN()
    {
        PanelController(shopPanel,townPanel,uiCanvas,enCanvas);
    }
    public void ShopOUT()
    {
        PanelController(townPanel,shopPanel,uiCanvas,enCanvas);
    }
    public void PanelController(GameObject truepanel, GameObject falsepanel, Canvas uicanvas,Canvas encanvas)
    {
        falsepanel.SetActive(false);
        falsepanel.transform.SetParent(encanvas.transform, false);
        truepanel.transform.SetParent (uicanvas.transform, false);
        truepanel.SetActive(true);
        menuBtn.transform.SetAsLastSibling();
    }





}
