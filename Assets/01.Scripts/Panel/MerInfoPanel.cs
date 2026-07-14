using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MerInfoPanel : MonoBehaviour
{
    public Button closeBtn;
    public Button employBtn;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI lVText;
    public TextMeshProUGUI strText;
    public TextMeshProUGUI intText;
    public TextMeshProUGUI dexText;

    private merDatamanger currentManger;
    private Mercenary currentmerdata;

    public void SetData(merDatamanger manger)
    {
        currentManger = manger;
        currentmerdata = manger.data;

        nameText.text = currentmerdata.name;
        lVText.text = currentmerdata.level.ToString();
    
        strText.text = currentmerdata.str.ToString();
        intText.text = currentmerdata.intel.ToString();
        dexText.text = currentmerdata.dex.ToString();
    }

    public void CloseBtn()
    {
        PopupManager.instance.CloseMerInfoBtn();
    }

    public void EmployBtn()
    {
        
        if(MercenaryManager.instance.AddMercenary(currentmerdata))
        {
            PopupManager.instance.CloseMerInfoBtn();
            Destroy(currentManger.gameObject);
        }
        else
       {
            StartCoroutine(EmployfalsePopup());

       }
    }

    IEnumerator EmployfalsePopup()
    {
        PopupManager.instance.OpenfalsePop();
        yield return new WaitForSeconds(3);
        PopupManager.instance.CloseFalsePop();
    }
    

}
