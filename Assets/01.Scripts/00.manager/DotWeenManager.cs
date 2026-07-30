using DG.Tweening;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DotWeenManager : MonoBehaviour
{   
    public static DotWeenManager instance;

    [SerializeField] Camera maincamera;
    Vector3 camOriginPos;
    float camOriginSize;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

    }
    

    public void OnClickBTN(RectTransform target)
    {
        target.DOKill();

        target.localScale = Vector3.one;

        target.DOScale(0.7f, 0.08f).OnComplete(() => { target.DOScale(1f, 0.1f); });
    }
    public void ZoomIN(Transform doorpos, Action complete)
    {
        Sequence seq= DOTween.Sequence();

        seq.Append(maincamera.transform.DOMove(doorpos.position, 0.7f));
        seq.Join(maincamera.DOOrthoSize(1f, 1f));

        
        seq.AppendCallback(() => complete?.Invoke());
        seq.AppendInterval(0.2f);

        seq.Append(maincamera.transform.DOMove(camOriginPos, 0.1f));
        seq.Join(maincamera.DOOrthoSize(camOriginSize, 1f));
    }
    public void AttackMove(BattleUnit attacker, List<BattleUnit> targets, AttackAniType ani, GameObject background, Action hit, Action complate)
    {
        if (attacker == null || targets == null)
        {
            complate?.Invoke();
            return;
        }
        RectTransform attackerRect = attacker.GetComponent<RectTransform>();
        RectTransform targetRect = targets[0].GetComponent<RectTransform>();
        Vector2 originPos = attackerRect.anchoredPosition;

        if (background != null)
        {
            background.transform.SetAsLastSibling();
        }

        foreach (var target in targets)
        {
            target.Slot.SetAsLastSibling();
        }

        attacker.Slot.SetAsLastSibling();


        float offsetX = 0;

        if (attacker.UnitType == UnitType.Mercenary)
            offsetX = 80f;
        else
            offsetX = -80f;

        Vector2 targetPos = new(targetRect.anchoredPosition.x + offsetX, targetRect.anchoredPosition.y);
       
        Animator atk = attacker.GetComponentInChildren<Animator>();
        Sequence seq = DOTween.Sequence();

        seq.Append(attackerRect.DOAnchorPos(targetPos, 0.2f).SetEase(Ease.OutCubic));
        switch (ani)
        {
            case AttackAniType.attack:
            seq.AppendCallback(() => atk.SetBool("attack", true));
            break;
            case AttackAniType.skill:
            seq.AppendCallback(() => atk.SetBool("skill", true));
            break;
        }
   
        seq.AppendInterval(0.3f);
        seq.AppendCallback(() =>
        {
             hit?.Invoke();
             foreach (var target in targets)
             {
                RectTransform rect = target.GetComponent<RectTransform>();
                rect.DOShakeAnchorPos(0.2f, strength: 15, vibrato: 20);
                
             }
        });
        seq.AppendInterval(0.3f);
        switch (ani)
        {
            case AttackAniType.attack:
                seq.AppendCallback(() => atk.SetBool("attack", false));
                break;
            case AttackAniType.skill:
                seq.AppendCallback(() => atk.SetBool("skill", false));
                break;
        }

        seq.Append(attackerRect.DOAnchorPos(originPos, 0.2f).SetEase(Ease.OutCubic));

        seq.OnComplete(() => 
        { attackerRect.anchoredPosition = originPos;
            
            background.transform.SetAsFirstSibling();

            complate?.Invoke();
        });

    }
    public void SetCamara(Camera cam)
    {
        maincamera = cam;

        camOriginPos = maincamera.transform.position;
        camOriginSize = maincamera.orthographicSize;
    }
}
