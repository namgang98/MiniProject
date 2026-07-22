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
        DungeunUIManager.instance.CloseChestPop();
        if (StageManager.instance.isLastStage())
        {
            DungeunUIManager.instance.OpenClearPanel();
        }
        else
        {
            DungeunUIManager.instance.OpenChoisPanel();
        }
    }
}
