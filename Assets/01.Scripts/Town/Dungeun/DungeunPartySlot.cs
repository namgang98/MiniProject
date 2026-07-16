using UnityEngine;
using UnityEngine.UI;
public class DungeunPartySlot : MonoBehaviour
{
    [SerializeField] portaitUI portaitUI;
    [SerializeField] Button removeBTN;

    Mercenary saveData;
    DungeunPanel panel;
    public void SetData(Mercenary mer, DungeunPanel panel)
    {
        saveData = mer;
        this.panel = panel;

        portaitUI.SetPortait(mer);
    }
    public void ReMoveParty()
    {
        panel.RemoveParty(saveData);
    }
    public void Clear()
    {
        saveData = null;
        portaitUI.Clear();
    }
}
