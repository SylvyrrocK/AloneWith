using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider masterSlider;

    const string MIXER_MUSIC = "musicVolume";
    const string MIXER_SFX = "sfxVolume";
    const string MIXER_MASTER = "masterVolume";

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetEffectVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat(MIXER_MASTER, volume);
    }

    public void SetEffectVolume(float volume)
    {
        audioMixer.SetFloat(MIXER_SFX, volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(MIXER_MUSIC, volume);
    }

    public void Save()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
