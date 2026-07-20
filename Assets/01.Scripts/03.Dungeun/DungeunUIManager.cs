using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DungeunUIManager : MonoBehaviour
{
    public static DungeunUIManager Instance;

    [SerializeField] Canvas uiCanvas;
    [SerializeField] Canvas battleCanvas;

    [SerializeField] StatPanel statPanel;

    [SerializeField] WeaponData weaponData;
    [SerializeField] SkillData skillData;
    [SerializeField] GameObject skillpop;
    [SerializeField] Button[] skillBottons;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void OpenSkillPop(BattleMercenary mer)
    {
        skillpop.SetActive(true);
        Weapon haveweapon = weaponData.weapons.Find(x => x.id == mer.Data.weapon.weaponID);
        int skillindex = mer.Data.weapon.grade.skillcount;

        for(int i = 0; i < skillBottons.Length; i++)
        {
            skillBottons[i].gameObject.SetActive(false);

            if (i < skillindex && haveweapon != null && i < haveweapon.skillID.Count)
            {
                skillBottons[i].gameObject.SetActive(true);
                   
                int skillsID = haveweapon.skillID[i];
                Skill skill = skillData.skills.Find(x => x.id == skillsID);
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
        CloseSkillPop();
        BattleManager.instance.stateMachin.ChangeState(BattleManager.instance.stateMachin.selectTargetState);
    }
    public void CloseSkillPop()
    {
        skillpop.SetActive(false);
    }
    public void OpenStatPop(BattleMercenary mer)
    {
        statPanel.gameObject.SetActive(true);
        statPanel.SetStatPop(mer);
    }
    public void CloseStatPop()
    {
        statPanel.gameObject.SetActive(false);
    }
}
