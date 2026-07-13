using NUnit.Framework;
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

    private Mercenary currentmerdata;

    public void SetData(Mercenary data)
    {
        nameText.text = data.name;
        lVText.text = data.level.ToString();
    
        strText.text = data.str.ToString();
        intText.text = data.intel.ToString();
        dexText.text = data.dex.ToString();
            
        currentmerdata = data;
    }

    public void CloseBtn()
    {
        PopupManager.instance.CloseMerInfoBtn();
    }

    public void EmployBtn()
    {
       // List<>
    }




}
