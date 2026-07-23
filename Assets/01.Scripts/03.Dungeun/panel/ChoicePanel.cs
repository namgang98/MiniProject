using UnityEngine;
using UnityEngine.UI;

public class ChoicePanel : MonoBehaviour
{
    [SerializeField] Button exitBTN;
    [SerializeField] Button nextBTN;
    private void Awake()
    {
        exitBTN.onClick.AddListener(ClickExit);
        nextBTN.onClick.AddListener(ClickNext);
    }

    public void ClickExit()
    {
        DungeunUIManager.instance.CloseChoisPanel();
        Destroy(SpawnManager.instance.chest.gameObject);
        BattleUnitManager.instance.ExitFullHeal();
        SceneChanger.Instance.Town();
    }
    public void ClickNext()
    {
        DungeunUIManager.instance.CloseChoisPanel();
        Destroy(SpawnManager.instance.chest.gameObject);
        BattleManager.instance.Next();
    }
}
