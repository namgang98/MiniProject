using UnityEngine;
using UnityEngine.UI;

public class DungeunMerSlot : MonoBehaviour
{
    [SerializeField] portaitUI portaitUI;
    [SerializeField] Button addBTN;

    [SerializeField] GameObject dim;
    Mercenary saveData;
    DungeunPanel panel;

    public void SetData(Mercenary mer, DungeunPanel panel)
    {
        saveData = mer;
        this.panel = panel;

        portaitUI.SetPortait(mer);

        dim.SetActive(MercenaryManager.instance.IsInParty(mer));
    }
    public void addparty()
    {
        panel.AddParty(saveData);
    }
}
