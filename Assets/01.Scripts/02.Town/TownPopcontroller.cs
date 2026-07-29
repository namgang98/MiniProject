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

    [SerializeField] Transform innDoorPos;
    [SerializeField] Transform ShopDoorPos;
    [SerializeField] Transform DungeunDoorPos;

    [SerializeField] GameObject UIs;
    [SerializeField] GameObject townPanel;
    [SerializeField] GameObject innPanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] ShopPanel shop;
    [SerializeField] GameObject dungeunPanel;
    
    [SerializeField] Canvas enCanvas;
    [SerializeField] Canvas uiCanvas;
    [SerializeField] Camera cam;
    private void Start()
    {
        DotWeenManager.instance.SetCamara(cam);
    }
    public void InnIN()
    {
        DotWeenManager.instance.ZoomIN(innDoorPos,() => PanelController(innPanel, townPanel, uiCanvas, enCanvas));
        SoundManager.instance.PlaySFX(SFXType.Door);
        
        SoundManager.instance.PlayBGM(BGMType.innBGM);
    }
    public void InnOUT()
    {
        SoundManager.instance.PlaySFX(SFXType.Door);
        PanelController(townPanel,innPanel,uiCanvas,enCanvas);
        SoundManager.instance.PlayBGM(BGMType.townBGM);
    }

    public void DungeunIN()
    {
        DotWeenManager.instance.ZoomIN(DungeunDoorPos,() => PanelController(dungeunPanel, townPanel, uiCanvas, enCanvas));
       
    }
    public void DungeunOUT()
    {
        PanelController(townPanel,dungeunPanel,uiCanvas,enCanvas);
    }
    public void ShopIN()
    {
        DotWeenManager.instance.ZoomIN(ShopDoorPos,() => PanelController(shopPanel, townPanel, uiCanvas, enCanvas));
        SoundManager.instance.PlaySFX(SFXType.Door);
        
        shop.OpenShop(); 
    }
    public void ShopOUT()
    {
        SoundManager.instance.PlaySFX(SFXType.Door);
        PanelController(townPanel,shopPanel,uiCanvas,enCanvas);
    }
    public void PanelController(GameObject truepanel, GameObject falsepanel, Canvas uicanvas,Canvas encanvas)
    {
        falsepanel.SetActive(false);
        falsepanel.transform.SetParent(encanvas.transform, false);
        truepanel.transform.SetParent (uicanvas.transform, false);
        truepanel.SetActive(true);
        UIs.transform.SetAsLastSibling();
    }





}
