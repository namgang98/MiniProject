using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager instance;

    SaveData data;

    string fileName;
    string savePath;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data = new SaveData();

        fileName = "SaveData.json";

        savePath = Path.Combine(Application.persistentDataPath, fileName);
    }

    public void Save()
    {
        data.gold = GoldManager.instance.HaveGold;

        data.items = new List<int>(InventoryManager.instance.items);
        data.weapons = new List<HaveWeapon>(InventoryManager.instance.weapons);

        data.mercenaries = new List<Mercenary>(MercenaryManager.instance.haveMerList);

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(savePath, json);

        Debug.Log(savePath);
    }

    public void Load()
    {
        if(File.Exists(savePath) == false)
        {
            Debug.Log("세이브파일이없습니다.");
            return;
        }

        string json = File.ReadAllText(savePath);

        SaveData loadData = JsonUtility.FromJson<SaveData>(json);

        GoldManager.instance.SetGold(loadData.gold);

        InventoryManager.instance.weapons = new List<HaveWeapon>(loadData.weapons);
        InventoryManager.instance.items = new List<int>(loadData.items);

        MercenaryManager.instance.haveMerList = new List<Mercenary>(loadData.mercenaries);

    }

    public void NewGame()
    {
        GoldManager.instance.SetGold(500);

        InventoryManager.instance.ClearInven();
        MercenaryManager.instance.ClearMercenaryList();

        Save();
    }
}
