using UnityEngine;
using UnityEngine.UI;

public class MerListPanel : MonoBehaviour
{
    [SerializeField] Transform conten;
    [SerializeField] GameObject merSlot;

    [SerializeField] Button closebtn;

    private void OnEnable()
    {
        Refresh();
    }

   public void Refresh()
    {
        foreach(Transform child in conten)
        {
            Destroy(child.gameObject);
        }

        foreach(Mercenary mer in MercenaryManager.instance.haveMerList)
        {
            GameObject slot = Instantiate(merSlot, conten);

            slot.GetComponent<MercenarySlot>().SetData(mer);
        }
    }

    public void ClosePop()
    {
        PopupManager.instance.CloseMerListPanel();
    }
}
