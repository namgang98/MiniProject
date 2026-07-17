using UnityEngine;

public class BattleMonster : MonoBehaviour
{
    public Monster data { get; private set; }

    [SerializeField] HpBar hpbar;

    float nowHp;

   public void SetData(Monster mos)
    {
        data = mos;
        nowHp = data.maxHp;
        hpbar.SetGauge(data.maxHp);
    }

    public void TakeDamage(int dmg)
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
