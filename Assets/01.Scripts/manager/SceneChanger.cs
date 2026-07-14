using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance;



    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

   public void Main()
    {
        SceneManager.LoadScene("Main");
        SoundManager.instance.PlayBGM(BGMType.mainBGM);
    }
    public void GameStart()
    {
        SceneManager.LoadScene("Town");
        SoundManager.instance.PlayBGM(BGMType.townBGM);
    }
    public void Dungeun()
    {
        SceneManager.LoadScene("Dungeun");
    }




    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
