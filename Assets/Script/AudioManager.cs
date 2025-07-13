using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("BGM Clips")]
    public AudioClip menuBGM;
    public AudioClip gameBGM;

    [Header("SFX Clips - Menu")]
    public AudioClip buttonClick1;
    public AudioClip buttonClick2;
    public AudioClip gameStart;

    [Header("SFX Clips - Game")]
    public AudioClip countdown321;
    public AudioClip foodBalance;
    public AudioClip walk;
    public AudioClip[] passengerVoices;
    public AudioClip foodBam;
    public AudioClip moneyToCounter;
    public AudioClip last10Seconds;
    public AudioClip suddenEvent;
    public AudioClip biggieEvent;
    public AudioClip scoreCounting;
    public AudioClip scoreCountFinish;
    public AudioClip endUITone;
    public AudioClip backToMenu;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Load volume settings
            bgmSource.volume = PlayerPrefs.GetFloat("BGMVolume", 1f);
            sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(string sceneName)
    {
        if (sceneName == "GameScene" && bgmSource.clip != gameBGM)
        {
            bgmSource.clip = gameBGM;
        }
        else if (sceneName == "MenuScene" && bgmSource.clip != menuBGM)
        {
            bgmSource.clip = menuBGM;
        }

        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }

    public void PlayRandomPassengerVoice()
    {
        if (passengerVoices.Length > 0)
        {
            int index = Random.Range(0, passengerVoices.Length);
            PlaySFX(passengerVoices[index]);
        }
    }

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
}
