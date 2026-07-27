using UnityEngine;
using UnityEngine.UI;

public class DunGeunInvenPanel : InvenPanel
{
    protected override void RefreshMerUI()
    {
        Mercenary[] party = MercenaryManager.instance.party;

        for (int i = 0; i < party.Length; i++)
        {
            if (i >= portaitSlots.Length)
            break;

            portaitSlots[i].SetData(party[i]);
        }
    }
    protected override void ClosePanel()
    {
        DungeunUIManager.instance.CloseInven();
    }
}
