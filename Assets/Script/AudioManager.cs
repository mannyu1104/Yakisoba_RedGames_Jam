using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// A singleton AudioManager that manages BGM and SFX in the game.
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip[] bgmClips;
    public AudioClip[] sfxClips;

    // Dictionary for quick lookup
    private Dictionary<string, AudioClip> sfxDictionary = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> bgmDictionary = new Dictionary<string, AudioClip>();

    void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeDictionaries();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Initializes dictionaries for quick clip lookup by name.
    /// </summary>
    private void InitializeDictionaries()
    {
        foreach (AudioClip clip in sfxClips)
        {
            if (!sfxDictionary.ContainsKey(clip.name))
                sfxDictionary.Add(clip.name, clip);
        }

        foreach (AudioClip clip in bgmClips)
        {
            if (!bgmDictionary.ContainsKey(clip.name))
                bgmDictionary.Add(clip.name, clip);
        }
    }

    /// <summary>
    /// Plays a BGM clip by name.
    /// </summary>
    public void PlayBGM(string name, bool loop = true)
    {
        if (bgmDictionary.TryGetValue(name, out AudioClip clip))
        {
            bgmSource.clip = clip;
            bgmSource.loop = loop;
            bgmSource.Play();
        }
        else
        {
            Debug.LogWarning("BGM clip not found: " + name);
        }
    }

    /// <summary>
    /// Stops the current BGM.
    /// </summary>
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    /// <summary>
    /// Plays a one-shot sound effect by name.
    /// </summary>
    public void PlaySFX(string name)
    {
        if (sfxDictionary.TryGetValue(name, out AudioClip clip))
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("SFX clip not found: " + name);
        }
    }

    /// <summary>
    /// Sets the BGM volume.
    /// </summary>
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = Mathf.Clamp01(volume);
    }

    /// <summary>
    /// Sets the SFX volume.
    /// </summary>
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp01(volume);
    }

    /// <summary>
    /// Gets the current BGM volume.
    /// </summary>
    public float GetBGMVolume()
    {
        return bgmSource.volume;
    }

    /// <summary>
    /// Gets the current SFX volume.
    /// </summary>
    public float GetSFXVolume()
    {
        return sfxSource.volume;
    }
}
