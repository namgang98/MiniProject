using UnityEngine;
using UnityEngine.UI;

public class InnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPos;
    [SerializeField] GameObject mercenaryPrefab;
    [SerializeField] MercenaryRandomTable randomTable;

    [SerializeField] GameObject townPanel;
    [SerializeField] GameObject innPanel;
    [SerializeField] Button outBtn;

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
                Destroy(chaild.gameObject);
            }
        }
        isSpawn = false;
    }

    public void OutInn()
    {
        innPanel.SetActive(false);
        SoundManager.instance.PlayBGM(BGMType.townBGM);
        townPanel.SetActive(true);
    }

}
