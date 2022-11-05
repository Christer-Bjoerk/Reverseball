using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField, Range(0, -80)] 
    private float volumeThreshold = -80f;
    [SerializeField] private AudioMixer mixer;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectsSlider;

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        float music = PlayerPrefs.GetFloat("Music");
        float effects = PlayerPrefs.GetFloat("Effects");

        // Decibel to linear 
        musicSlider.value = MathF.Pow(10f, music / 20f);
        effectsSlider.value = MathF.Pow(10f, effects / 20f);
    }

    /// <summary>
    /// Set the music volume of the audio mixer.
    /// </summary>
    public void SetMusicVolume(float sliderValue)
    {
        if (sliderValue <= 0)
        {
            mixer.SetFloat("Music", volumeThreshold);
        }
        else
        {
            // Translate unit range to logarithmic value.
            float value = 20f * Mathf.Log10(sliderValue);
            mixer.SetFloat("Music", value);
            PlayerPrefs.SetFloat("Music", value);
        }
    }

    /// <summary>
    /// Set the SFX volume of the audio mixer.
    /// </summary>
    public void SetSoundEffectsVolume(float sliderValue)
    {
        if (sliderValue <= 0)
        {
            mixer.SetFloat("Effects", volumeThreshold);
        }
        else
        {
            // Translate unit range to logarithmic value.
            float value = 20f * Mathf.Log10(sliderValue);

            mixer.SetFloat("Effects", value);
            PlayerPrefs.SetFloat("Effects", value);
        }
    }
}