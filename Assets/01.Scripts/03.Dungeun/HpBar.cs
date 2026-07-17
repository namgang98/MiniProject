using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Image img;
    float gauge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        img = GetComponent<Image>();
    }
    public void SetGauge(float gauge)
    {
        img.fillAmount = gauge;
    } 


}
