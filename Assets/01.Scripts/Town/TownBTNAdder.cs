using UnityEngine;
using UnityEngine.UI;

public class TownBTNAdder : MonoBehaviour
{
    [SerializeField] Button menuBtn;

    private void Start()
    {
       menuBtn.onClick.AddListener(PopupManager.instance.OpenMenuPopup);
    }
}
