using System.Collections.Generic;

public class TownInvenPanel : InvenPanel
{
    protected override void RefreshMerUI()
    {
        List<Mercenary> mers = MercenaryManager.instance.haveMerList;

        for (int i = 0; i < mers.Count; i++)
        {
            if (i >= portaitSlots.Length)
                break;

            portaitSlots[i].SetData(mers[i]);
        }
    }
    protected override void ClosePanel()
    {
        PopupManager.instance.CloseInven();
    }
}
