using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestB : MonoBehaviour
{
    [SerializeField] Button Btn;

    private void Start()
    {
        Btn.onClick.AddListener(OpenChest);
        //드롭아이템을 체스트인벤리스트에 넣기
    }

    public void OpenChest()
    {
        DungeunUIManager.instance.OpenChestPop(this);

    }
}
