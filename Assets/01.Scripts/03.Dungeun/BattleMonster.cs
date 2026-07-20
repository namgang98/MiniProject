using UnityEngine;
using UnityEngine.UI;

public class BattleMonster : BattleUnit
{
    public Monster Data { get; private set; }
    [SerializeField] Button btn;
    [SerializeField] HpBar hpbar;
    float nowHp;
    float maxHp;

    private void Start()
    {
        if(btn != null)
        {
            btn.onClick.AddListener(OnClick);
        }
    }
    public void SetData(Monster mos)
    {
        Data = mos;
        nowHp = Data.maxHp;
        maxHp = Data.maxHp;
        Dex = Data.dex;
        UnitType = UnitType.Monster;
        hpbar.SetGauge(nowHp/maxHp);
    }

    public override void TakeDamage(int dmg)
    {
        nowHp -= dmg;

        if (nowHp < 0)
            nowHp = 0;

        hpbar.SetGauge(nowHp/maxHp);

        if (nowHp <= 0)
        {
            BattleManager.instance.DieMonster(this);
        }

    }

    public void OnClick()
    {
        if (BattleManager.instance.stateMachin.currentState is SelectTargetState targetState)
        {
            targetState.OnClickTarget(this);
        }
    }
}
