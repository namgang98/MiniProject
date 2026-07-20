using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField]Image img;

    public void SetGauge(float gauge)
    {
        if (img != null)
        {
            img.fillAmount = gauge;
        }
    } 


}
