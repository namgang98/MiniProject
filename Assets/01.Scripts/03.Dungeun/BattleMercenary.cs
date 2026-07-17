using UnityEngine;

public class BattleMercenary : MonoBehaviour
{
   
    public Mercenary data { get; private set; }
    [SerializeField] HpBar hpBar;
        
    public void SetData(Mercenary mer)
    {
        data = mer;
        hpBar.SetGauge(data.maxHp);
    }
    public void TakeDamage(int dmg)
    {
        data.hp -= dmg;

        if(data.hp < 0)
            data.hp = 0;

        hpBar.SetGauge(data.hp/data.maxHp);

        if(data.hp <= 0)
        {
            BattleManager.instance.DieMercenary(this);
        }
    }     

    public void Heal(int heal)
    {
        data.hp += heal;

        if(data.hp > data.maxHp)
            data.hp = data.maxHp;

        hpBar.SetGauge(data.hp / data.maxHp);
    }
}
