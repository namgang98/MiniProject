using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class MerListInfoPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI lvText;
    [SerializeField] TextMeshProUGUI totalStrText;
    [SerializeField] TextMeshProUGUI totalIntText;
    [SerializeField] TextMeshProUGUI totalDexText;

    [SerializeField] TextMeshProUGUI statpointText;
    [SerializeField] TextMeshProUGUI strText;
    [SerializeField] TextMeshProUGUI intText;
    [SerializeField] TextMeshProUGUI dexText;

    [SerializeField] portaitUI PortaitUI;

    private Mercenary saveData;

    public void SetData(Mercenary data)
    {
        saveData = data;

        nameText.text = data.name;
        lvText.text = data.level.ToString();
        
        totalStrText.text = data.totalStr.ToString();
        totalIntText.text = data.totalInt.ToString();
        totalDexText.text = data.totalDex.ToString();

        statpointText.text = data.statpoint.ToString();
        strText.text = data.str.ToString();
        intText.text = data.intel.ToString();
        dexText.text = data.dex.ToString();

        SetPortait(data);
    }
    #region 힘업버튼
    public void UpSTR()
    {
        if (saveData.statpoint <= 0)
            return;

        saveData.str++;
        saveData.statpoint--;

        UpSTRRefrash();
    }
    void UpSTRRefrash()
    {
        totalStrText.text = saveData.totalStr.ToString();
        strText.text = saveData.str.ToString();
        statpointText.text = saveData.statpoint.ToString();
    }
    #endregion
    #region 인트업버튼
    public void UpINT()
    {
        if (saveData.statpoint <= 0)
            return;

        saveData.intel++;
        saveData.statpoint--;

        UpINTRefrash();
    }
    void UpINTRefrash()
    {
        totalIntText.text = saveData.totalInt.ToString();
        intText.text = saveData.intel.ToString();
        statpointText.text = saveData.statpoint.ToString();
    }
    #endregion
    #region 덱스업버튼
    public void UpDEX()
    {
        if (saveData.statpoint <= 0)
            return;

        saveData.dex++;
        saveData.statpoint--;

        UpDEXRefrash();
    }
    void UpDEXRefrash()
    {
        totalDexText.text = saveData.totalDex.ToString();
        dexText.text = saveData.dex.ToString();
        statpointText.text = saveData.statpoint.ToString();
    }
    #endregion

    public void SetPortait(Mercenary data)
    {
        PortaitUI.SetPortait(data);
    }

    public void ClosePanel()
    {
        PopupManager.instance.CloseMerStatPanel();
    }
}
