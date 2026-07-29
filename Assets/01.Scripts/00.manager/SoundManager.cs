using UnityEngine;


public enum BGMType
{
    mainBGM,
    townBGM,
    innBGM,
    dungeunBGM
}
public enum SFXType
{
    Door,

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

    public AudioClip doorSFXClip;
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
        SetSFXVolume(PlayerPrefs.GetFloat("SFXVolume", 1));
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
    public void PlaySFX(SFXType type)
    {
        switch (type)
        {
            case SFXType.Door:
                SFXAudioSource.clip = doorSFXClip;
                break;
        }
        SFXAudioSource.Play();
    }
    public void SetBgmVolume(float volume)
    {
        BGMAudioSource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        SFXAudioSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public float GetBgmVolume()
    {
        return BGMAudioSource.volume;
    }
    public float GetSFXVolume()
    {
        return SFXAudioSource.volume;
    }
}
