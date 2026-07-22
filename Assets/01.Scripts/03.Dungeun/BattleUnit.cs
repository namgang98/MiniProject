using UnityEngine;
public enum UnitType
{
    Mercenary,
    Monster
}
public abstract class BattleUnit : MonoBehaviour
{
    [SerializeField] GameObject turnMark;
    public int Dex { get; protected set; }
    public int INT { get; protected set; }
    public int STR { get; protected set; }
    public UnitType UnitType { get; protected set; }
    public virtual void TakeDamage(int dmg)
    {

    }
    public void SetTurnMark(bool action)
    {
        turnMark.SetActive(action);
    }

}
