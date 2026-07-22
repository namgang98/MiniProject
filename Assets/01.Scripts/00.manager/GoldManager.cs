using System.Collections;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public static GoldManager instance;

    TextMeshProUGUI goldtext;

    bool isFirstGold = false;

    public int HaveGold { get; private set; }

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        FirstGold();
    }

    private void FirstGold()
    {
        if (!isFirstGold)
        {
            HaveGold = 500;
            isFirstGold = true;
        }
    }
    public void GetGold(int gold)
    {
        HaveGold += gold;
        UpdateUI();
    }
    public void UseGold(int gold)
    {
        if (HaveGold < gold)
        {
            StartCoroutine(EnoughGoldPopup());
            return;
        }

        HaveGold -= gold;

        UpdateUI();
    }
    public void UpdateUI()
    {
        goldtext.text = $"{HaveGold}G";
    }


    public void SetGoldUI(TextMeshProUGUI text)
    {
        goldtext = text;
        UpdateUI();
    }




    IEnumerator EnoughGoldPopup()
    {
        PopupManager.instance.OpenFalseGoldPop();
        yield return new WaitForSeconds(1.5f);
        PopupManager.instance.CloseFalseGoldPanel();
    }
}
