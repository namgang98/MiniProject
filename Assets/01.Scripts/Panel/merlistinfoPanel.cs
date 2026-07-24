using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    GameObject currentIcon;
    [SerializeField] Transform iconPos;
    [SerializeField] TextMeshProUGUI weaponName;
    [SerializeField] TextMeshProUGUI weaponGrade;
    [SerializeField] TextMeshProUGUI weaponSTR;
    [SerializeField] TextMeshProUGUI weaponInt;
    [SerializeField] TextMeshProUGUI weaponDex;
    [SerializeField] Button unequipBtn;

    [SerializeField] Button byeMer;

    private Mercenary saveData;

    public void SetData(Mercenary data)
    {
        saveData = data;
        RefreshStatUI();
        RefreshWeaponUI();
    }
    public void RefreshStatUI()
    {
        nameText.text = saveData.name;
        lvText.text = saveData.level.ToString();

        totalStrText.text = saveData.totalStr.ToString();
        totalIntText.text = saveData.totalInt.ToString();
        totalDexText.text = saveData.totalDex.ToString();

        statpointText.text = saveData.statpoint.ToString();
        strText.text = saveData.str.ToString();
        intText.text = saveData.intel.ToString();
        dexText.text = saveData.dex.ToString();



        SetPortait(saveData);
    }
    public void RefreshWeaponUI()
    {
        if(currentIcon != null)
        {
            Destroy(currentIcon);
            currentIcon = null;
        }
        if (saveData == null || saveData.weapon == null)
            return;

        Item weapon = ItemDropManager.instance.Getitem(saveData.weapon.weaponiconID);
       
        if(weapon != null && weapon.icon != null)
        {
            currentIcon = Instantiate(weapon.icon, iconPos);
            Image iconimg = currentIcon.GetComponent<Image>();
            if (iconimg != null)
            {
                iconimg.color = Color.white;
                if(saveData.weapon.grade != null)
                {
                    iconimg.color = saveData.weapon.grade.gradeColor;
                }
            }
        }    
        weaponName.text = saveData.weapon.name;
        weaponGrade.text = saveData.weapon.grade.ToString();
        weaponSTR.text = saveData.weapon.str.ToString();
        weaponInt.text = saveData.weapon.intel.ToString();
        weaponDex.text = saveData.weapon.dex.ToString();
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
        PopupManager.instance.CloseMerStatPanel(saveData);
    }
    public void ByeMer()
    {
        MercenaryManager.instance.ReMoveMercenary(saveData);
        ClosePanel();
    }
}
