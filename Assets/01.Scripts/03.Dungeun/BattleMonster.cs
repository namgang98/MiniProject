using UnityEngine;

public class BattleMonster : BattleUnit
{
    public Monster data { get; private set; }

    [SerializeField] HpBar hpbar;
    float nowHp;

   public void SetData(Monster mos)
    {
        data = mos;
        nowHp = data.maxHp;
        Dex = data.dex; 
        hpbar.SetGauge(data.maxHp);
    }

    public override void TakeDamage(int dmg)
    {
        nowHp -= dmg;

        if (nowHp < 0)
            nowHp = 0;

        hpbar.SetGauge(nowHp/data.maxHp);

        if (nowHp <= 0)
        {
            BattleManager.instance.DieMonster(this);
        }

    }
}
