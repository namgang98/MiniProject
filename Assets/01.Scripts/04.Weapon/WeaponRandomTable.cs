using UnityEngine;

public class WeaponRandomTable : MonoBehaviour
{
    public static WeaponRandomTable instance;
    [SerializeField] WeaponData weaponData;
    [SerializeField] GradeData gradeData;

    int nextID;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else 
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        nextID = 1100;
    }

    public HaveWeapon CreateWeapon()
    {
        int uniqueID = nextID;
        nextID++;

        Weapon weapon = weaponData.weapons[Random.Range(0, weaponData.weapons.Count)];
        Grade grade = gradeData.grades[Random.Range(0, gradeData.grades.Count)];
        string weaponname = weapon.name;
        int weaponID = weapon.id;
        int iconid = weapon.itemid;
        int str = grade.str;
        int intel = grade.intel;
        int dex = grade.dex;



        return new HaveWeapon(uniqueID,weaponID,iconid, weaponname, grade,str,intel,dex);
    }
}
