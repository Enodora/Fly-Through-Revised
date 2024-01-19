using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource buttonSource;
    [SerializeField] AudioClip buttonClip;
    [SerializeField] AudioSource starSource;
    [SerializeField] AudioClip starClip;
    [SerializeField] AudioSource explosionSource;
    [SerializeField] AudioClip explosionClip;
    [SerializeField] AudioSource clearSource;
    [SerializeField] AudioClip clearClip;

    public const string BGM_KEY = "bgmVolume";
    public const string SFX_KEY = "sfxVolume";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }

    public void buttonSFX()
    {
        buttonSource.PlayOneShot(buttonClip);
    }
    public void StarSFX()
    {
        starSource.PlayOneShot(starClip);
    }
    public void ExplosionSFX()
    {
        explosionSource.PlayOneShot(explosionClip);
    }
    public void ClearSFX()
    {
        clearSource.PlayOneShot(clearClip);
    }

    void LoadVolume()   //Volume saved in VolumeSettings.cs
    {
        float bgmVolume = PlayerPrefs.GetFloat(BGM_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        mixer.SetFloat(VolumeSettings.MIXER_BGM, Mathf.Log10(bgmVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }
}
