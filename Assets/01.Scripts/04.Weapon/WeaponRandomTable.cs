using UnityEngine;

public class WeaponRandomTable : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] GradeData gradeData;

    int nextID;
    private void Awake()
    {
        nextID = 1100;
    }

    public HaveWeapon CreateWeapon()
    {
        int uniqueID = nextID;
        nextID++;

        Weapon weapon = weaponData.weapons[Random.Range(0, weaponData.weapons.Count)];
        Grade grade = gradeData.grades[Random.Range(0, gradeData.grades.Count)];

        int weaponID = weapon.id;
        int str = grade.str;
        int intel = grade.intel;
        int dex = grade.dex;



        return new HaveWeapon(uniqueID,weaponID,grade,str,intel,dex);
    }
}
