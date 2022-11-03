using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private float volumeThreshold = -80f;
    [SerializeField] private AudioMixer mixer;

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
        }
    }
}