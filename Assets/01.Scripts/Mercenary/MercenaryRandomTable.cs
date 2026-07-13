using UnityEngine;

public class MercenaryRandomTable : MonoBehaviour
{
    int nextID;

    [SerializeField] private CustomData customData;
    [SerializeField] private NameData nameData;

    private void Awake()
    {
        nextID = 10001;
    }
    public Mercenary Spawning()
    {
        //°´Ã¼¾ÆÀÌµð
        int uniqueID = nextID;
        nextID += 1;

        // ÀÌ¸§·£´ý¼³Á¤
        string changeName = "No named";
        if (nameData != null && nameData.names.Count > 0)
        {
            int randomNameChans = Random.Range(0, nameData.names.Count);

            changeName = nameData.names[randomNameChans].name;
        }

        //½ºÅÝ·£´ýºÐ¹è
        int str = 1;
        int dex = 1;
        int intel = 1;

        int allStats = 12; // ±âº» 111 + 12 ÃÑ15½ºÅÝºÐ¹è

        while (allStats > 0)
        {
            int randomStat = Random.Range(0, 3);
            if (randomStat == 0)
                str++;
            else if (randomStat == 1)
                dex++;
            else if (randomStat == 2)
                intel++;

            allStats--;
        }

        // Ä¿¸¶ ·£´ý¼³Á¤
        int hairNum = 0;
        int hairColorNum = 0;

        if (customData != null)
        {
            hairNum = Random.Range(0, customData.hairs.Count);
            hairColorNum = Random.Range(0, customData.hairColors.Length);
        }

        // À­ °ª ¿ëº´»ý¼º
        return new Mercenary(uniqueID, changeName, str, intel, dex, hairNum, hairColorNum);
    }
}
