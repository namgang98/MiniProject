using Unity.Android.Gradle.Manifest;
using UnityEditor.Animations;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [SerializeField] BattleMercenary battleMercenary;
    [SerializeField] MonsterData monsterData;
    [SerializeField] ChestData chestData;
    public ChestB chest;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }
    public BattleMercenary SpawnMercenary(Transform pos, Mercenary data)
    {
        BattleMercenary mer = Instantiate(battleMercenary,pos);
    
        mer.SetData(data);

        return mer;
    }
    public BattleMonster SpawnMonster(Transform pos, int id)
    {
        Monster data = monsterData.monsterList.Find(x => x.id == id);

        BattleMonster mon = Instantiate(data.prefab, pos);

        mon.SetData(data);

        return mon;
        
    }
    public ChestB SpawnChest(Transform pos, int id)
    {
        Chest data = chestData.chests.Find(x => x.id == id);
        ChestB chest = Instantiate(data.chest, pos);
        this.chest = chest;
        return chest;
    }
}
