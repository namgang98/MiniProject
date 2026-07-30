using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public enum UnitType
{
    Mercenary,
    Monster
}
public abstract class BattleUnit : MonoBehaviour
{
    [SerializeField] GameObject turnMark;
    [SerializeField] Image[] bodyimage;
    public Transform Slot => transform.parent;
    public int Dex { get; protected set; }
    public int INT { get; protected set; }
    public int STR { get; protected set; }
    public UnitType UnitType { get; protected set; }
   
    public void TakeDamage(int dmg)
    {
        StartCoroutine(EffectTakeDamage(dmg));      
    }
    public abstract void OnTakeDamage(int dmg);

    public IEnumerator EffectTakeDamage(int dmg)
    { 
        foreach (Image img in bodyimage)
        {
            if (img == null)
                continue;
            img.DOColor(Color.red, 0.2f).SetLoops(2, LoopType.Yoyo);
        }
        yield return new WaitForSeconds(0.4f);

        OnTakeDamage(dmg);
    }
    public void SetTurnMark(bool action)
    {
        turnMark.SetActive(action);
    }

}
