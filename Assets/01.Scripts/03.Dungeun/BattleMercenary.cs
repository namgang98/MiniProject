using System;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;

public class BattleMercenary : BattleUnit
{
    [SerializeField] SkillPanel skillPanel;
    public Mercenary Data { get; private set; }
    [SerializeField] HpBar hpBar;
    [SerializeField] MercenaryCustomizing custom;
    [SerializeField] Button btn;
   
    private void Start()
    {
        btn.onClick.AddListener(OnClick);
    }
    public void SetData(Mercenary mer)
    {
        Data = mer;

        STR = Data.totalStr;
        INT = Data.totalInt;
        Dex = Data.totalDex;

        UnitType = UnitType.Mercenary;
        custom = GetComponent<MercenaryCustomizing>();
        if(custom != null)
        custom.SetMercenary(Data);

        hpBar.SetGauge(Data.hp/Data.maxHp);
    }
    public override void TakeDamage(int dmg)
    {
        Data.hp -= dmg;

        if(Data.hp < 0)
            Data.hp = 0;

        hpBar.SetGauge(Data.hp/Data.maxHp);

        if(Data.hp <= 0)
        {
            BattleManager.instance.DieMercenary(this);
        }
    }     

    public void Heal(int heal)
    {
        Data.hp += heal;

        if(Data.hp > Data.maxHp)
            Data.hp = Data.maxHp;

        hpBar.SetGauge(Data.hp / Data.maxHp);
    }
    public void FullHeal()
    {
        Data.hp = Data.maxHp;
        hpBar.SetGauge(Data.hp / Data.maxHp);
    }

    public void OnClick()
    {
        BattleUnit unit = TurnManager.instance.GetCurrentUnits();

        if (unit == this)
        {
            DungeunUIManager.instance.OpenStatPop(this);
            DungeunUIManager.instance.OpenSkillPanel(this);

        }
        else
        {
            DungeunUIManager.instance.OpenStatPop(this);
            DungeunUIManager.instance.CloseSkillPanel();
        }
    }
}
