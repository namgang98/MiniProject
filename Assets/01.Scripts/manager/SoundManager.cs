using UnityEngine;
using UnityEngine.Rendering;


public enum BGMType
{
    mainBGM,
    townBGM,
    innBGM,
    dungeunBGM
}
public enum SFXType
{

}


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioSource BGMAudioSource;
    [SerializeField] AudioSource SFXAudioSource;

    public AudioClip mainBGMClip;
    public AudioClip townBGMClip;
    public AudioClip innBGMClip;
    public AudioClip dungeunBGMClip;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetBgmVolume(PlayerPrefs.GetFloat("BGMVolume", 1));
        PlayBGM(BGMType.mainBGM);
    }

    public void PlayBGM(BGMType type)
    {
        switch(type)
        {
            case BGMType.mainBGM:
                BGMAudioSource.clip = mainBGMClip;
                break;
            case BGMType.townBGM:
                BGMAudioSource.clip = townBGMClip;
                break;
            case BGMType.innBGM:
                BGMAudioSource.clip= innBGMClip;
                break;
            case BGMType.dungeunBGM:
                BGMAudioSource.clip= dungeunBGMClip;
                break;
        }
        BGMAudioSource.Play();
    }
    public void SetBgmVolume(float volume)
    {
        BGMAudioSource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }
    public float GetBgmVolume()
    {
        return BGMAudioSource.volume;
    }
}
