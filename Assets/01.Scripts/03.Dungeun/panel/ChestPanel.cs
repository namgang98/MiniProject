using UnityEngine;
using UnityEngine.UI;

public class ChestPanel : MonoBehaviour
{
    [SerializeField] Button closeBtn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closeBtn.onClick.AddListener(CloseChest);
    }
    public void CloseChest()
    {
        //체스트인벤 닫기
        DungeunUIManager.instance.CloseChestPop();
        //확인후 복귀/다음층 이동시 안에 아이템이스트 초기화 > 다음 버튼기능들로 이동
        DungeunUIManager.instance.OpenChoisPanel();
    }
}
