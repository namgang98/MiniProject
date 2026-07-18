using UnityEngine;

public abstract class BattleUnit : MonoBehaviour
{
    public int Dex { get; protected set; }

    public virtual void TakeDamage(int dmg)
    {

    }

}
