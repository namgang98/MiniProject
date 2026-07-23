using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    [SerializeField] StageData stageData;

    int currentStageID = 1;

    public Stage Stage {  get; private set; }


    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void LoadStage()
    {
        Stage = stageData.stages.Find(x => x.stageID == currentStageID);
    }

    public void NextStage()
    {
        currentStageID++;
        LoadStage();
    }
    public bool IsLastStage()
    {
        return currentStageID == stageData.stages.Count;
    }

}
