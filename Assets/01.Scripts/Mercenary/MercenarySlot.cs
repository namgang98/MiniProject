using UnityEngine;
using UnityEngine.UI;

public class MercenarySlot : MonoBehaviour
{
    [SerializeField] portaitUI portaitUI;
    [SerializeField] Button openstatBTN;

    Mercenary saveData;

    public void SetData(Mercenary mer)
    {
        saveData = mer;
        portaitUI.SetPortait(mer);
    }

    public void OpenStatPop()
    {
        PopupManager.instance.OpenMerStatPopUp(saveData);
    }
}
