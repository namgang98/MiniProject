using UnityEngine;

public class MerListPanel : MonoBehaviour
{
    [SerializeField] Transform conten;
    [SerializeField] GameObject merSlot;

    private void OnEnable()
    {
        Refresh();
    }

    void Refresh()
    {
        foreach(Mercenary mer in MercenaryManager.instance.haveMerList)
        {
            GameObject slot = Instantiate(merSlot, conten);

            slot.GetComponent<MercenarySlot>().SetData(mer);
        }
    }
}
