using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{

    [SerializeField] WeaponData weaponData;
    [SerializeField] SkillData skillData;
    [SerializeField] Button[] skillBottons;


    public void SetSkillButton(BattleMercenary mer)
    {
        Weapon haveweapon = weaponData.weapons.Find(x => x.id == mer.Data.weapon.weaponID);
        int skillindex = mer.Data.weapon.grade.skillcount;

        for (int i = 0; i < skillBottons.Length; i++)
        {
            skillBottons[i].gameObject.SetActive(false);

            if (i < skillindex && haveweapon != null && i < haveweapon.skillID.Count)
            {
                skillBottons[i].gameObject.SetActive(true);

                int skillsID = haveweapon.skillID[i];
                Skill skill = SkillManager.instance.GetSkill(skillsID);
                skillBottons[i].GetComponentInChildren<TMP_Text>().text = skill.name;

                skillBottons[i].onClick.RemoveAllListeners();
                Skill clickskill = skill;
                skillBottons[i].onClick.AddListener(() => OnCklickSkill(clickskill));
            }
        }

    }
    public void OnCklickSkill(Skill skill)
    {
        BattleManager.instance.currentSkill = skill;
        DungeunUIManager.instance.CloseSkillPanel();
        BattleManager.instance.stateMachin.ChangeState(BattleManager.instance.stateMachin.selectTargetState);
    }
}
