using UnityEngine;

public abstract class BattleUnit : MonoBehaviour
{
    protected float hp;
    protected HpBar hpBar;

    public virtual void TakeDamage(int dmg)
    {

    }

}
