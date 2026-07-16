using System.Collections;
using UnityEngine;

public class ExploreBtn : MonoBehaviour
{
    public void GoExplore()
    {
        int partys = MercenaryManager.instance.PartyCount();

        if (partys == 0)
        {
            StartCoroutine(PartysZeroPopup());
            return;
        }

        if(partys < 4)
        {
            PopupManager.instance.OpenPartysNotFourPop();
            return;
        }

        SceneChanger.Instance.Explore();
    }
    IEnumerator PartysZeroPopup()
    {
        PopupManager.instance.OpenPartysZeroPop();
        yield return new WaitForSeconds(3);
        PopupManager.instance.ClosePartysZeroPanel();
    }
}
