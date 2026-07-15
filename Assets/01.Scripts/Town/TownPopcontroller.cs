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
        townPanel.SetActive(false);
        townPanel.transform.SetParent(enCanvas.transform, false);
        innPanel.transform.SetParent(uiCanvas.transform, false);
        innPanel.SetActive(true);
        menuBtn.transform.SetAsLastSibling();
        SoundManager.instance.PlayBGM(BGMType.innBGM);
    }
    public void InnOUT()
    {
        innPanel.SetActive(false);
        innPanel.transform.SetParent(enCanvas.transform, false);
        townPanel.transform.SetParent(uiCanvas.transform, false);
        townPanel.SetActive(true);
        menuBtn.transform.SetAsLastSibling();
        SoundManager.instance.PlayBGM(BGMType.townBGM);
    }



}
