using UnityEngine;
using UnityEngine.UI;

public class InnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPos;
    [SerializeField] GameObject mercenaryPrefab;
    [SerializeField] MercenaryRandomTable randomTable;

    [SerializeField] WeaponRandomTable weaponRandomTable;

    bool isSpawn = false;

    private void OnEnable()
    {
        if (!isSpawn)
        {
            SpawnMercenary();
            isSpawn = true;
        }
    }

    void SpawnMercenary()
    {
        for (int i = 0; i < spawnPos.Length; i++)
        {
            Mercenary data = randomTable.Spawning();
            data.weapon = weaponRandomTable.CreateWeapon();
            GameObject obj = Instantiate(mercenaryPrefab, spawnPos[i], false);

            
            obj.GetComponent<merDatamanger>().SetData(data);
            obj.GetComponent<MercenaryCustomizing>().SetMercenary(data);
        }
    }
    public void RESpawnMercenary()
    {
        for (int i = 0; i < spawnPos.Length; i++)
        {
            foreach ( Transform chaild in spawnPos[i])
            {
                if (spawnPos[i] != null)
                Destroy(chaild.gameObject);
            }
        }
        isSpawn = false;
    }
}
