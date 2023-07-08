using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;

    const string MIXER_MASTER = "masterVolume";
    const string MIXER_MUSIC = "musicVolume";
    const string MIXER_SFX = "sfxVolume";

    private void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        SFXSlider.onValueChanged.AddListener(SetEffectVolume);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat(MIXER_MASTER, volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(MIXER_MUSIC, volume);
    }
    public void SetEffectVolume(float volume)
    {
        audioMixer.SetFloat(MIXER_SFX, volume);
    }

    public void Save()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
