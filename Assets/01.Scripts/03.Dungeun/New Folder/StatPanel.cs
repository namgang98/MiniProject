using TMPro;
using UnityEngine;

public class StatPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI merName;
    [SerializeField] TextMeshProUGUI str;
    [SerializeField] TextMeshProUGUI intel;
    [SerializeField] TextMeshProUGUI dex;

    public void SetStatPop(BattleMercenary mer)
    {
        merName.text = mer.Data.name;
        str.text = $"STR : {mer.Data.str}";
        intel.text =$"INT : { mer.Data.intel}";
        dex.text = $"DEX : {mer.Data.dex}";
    }
}
