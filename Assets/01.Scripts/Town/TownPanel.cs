using UnityEngine;
using UnityEngine.UI;

public class TownPanel : MonoBehaviour
{
    [SerializeField] Button innBtn;
    [SerializeField] Button ShopBtn;
    [SerializeField] Button DungeunBtn;

    [SerializeField] GameObject townPanel;
    [SerializeField] GameObject innPanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject dungeunPanel;

    MercenaryRandomTable mertable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    
    public void OpenInn()
    {
        townPanel.SetActive(false);
        innPanel.SetActive(true);
        SoundManager.instance.PlayBGM(BGMType.innBGM);
    }
}
