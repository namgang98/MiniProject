using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    [SerializeField] SkillData skillData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public Skill GetSkill(int id)
    {
        return skillData.skills.Find(x => x.id == id);
    }
}
