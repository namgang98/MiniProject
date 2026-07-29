using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDOTWeen : MonoBehaviour
{
    Button btn;
    RectTransform rect;

    private void Awake()
    {
        btn = GetComponent<Button>();
        rect = GetComponent<RectTransform>();

        btn.onClick.AddListener(() => DotWeenManager.instance.OnClickBTN(rect));
    }
    private void OnDisable()
    {
        rect.DOKill();
    }
}
