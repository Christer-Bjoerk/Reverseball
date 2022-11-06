using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Preferences")]
    [SerializeField, Range(0, -80)]
    private float volumeThreshold = -80f;

    [SerializeField] private GameObject audioParent;

    [Header("References")]
    [SerializeField] private AudioMixer mixer;

    [SerializeField] private Audio[] music;

    [SerializeField] private Audio[] soundEffects;

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

        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < music.Length; i++)
        {
            GameObject audioObject = new GameObject("Music_" + i + "_" + music[i].audioName);
            audioObject.transform.parent = audioParent.transform;
            audioObject.AddComponent<AudioSource>();
            audioObject.GetComponent<AudioSource>().outputAudioMixerGroup = mixer.FindMatchingGroups("Music")[0];
            audioObject.GetComponent<AudioSource>().loop = music[i].audioLoop;
            audioObject.GetComponent<AudioSource>().volume = music[i].audioVolume;
            audioObject.GetComponent<AudioSource>().clip = music[i].audioClip;
            music[i].audioSource = audioObject.GetComponent<AudioSource>();
        }

        for (int i = 0; i < soundEffects.Length; i++)
        {
            GameObject audioObject = new GameObject("Effects_" + i + "_" + soundEffects[i].audioName);
            audioObject.transform.parent = audioParent.transform;
            audioObject.AddComponent<AudioSource>();
            audioObject.GetComponent<AudioSource>().outputAudioMixerGroup = mixer.FindMatchingGroups("Effects")[0];
            audioObject.GetComponent<AudioSource>().loop = soundEffects[i].audioLoop;
            audioObject.GetComponent<AudioSource>().volume = soundEffects[i].audioVolume;
            audioObject.GetComponent<AudioSource>().clip = soundEffects[i].audioClip;
            audioObject.GetComponent<AudioSource>().playOnAwake = false;
            soundEffects[i].audioSource = audioObject.GetComponent<AudioSource>();
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
    /// Play music from the array.
    /// </summary>
    public void PlayMusic(string name)
    {
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i].audioName == name)
            {
                music[i].Play();
                return;
            }
        }
    }

    /// <summary>
    /// Play a sound-effect from the array.
    /// </summary>
    public void PlaySound(string name)
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            if (soundEffects[i].audioName == name)
            {
                soundEffects[i].Play();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Pause music from the array.
    /// </summary>
    public void PauseMusic(string name)
    {
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i].audioName == name)
            {
                music[i].Pause();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Pause a sound from the array.
    /// </summary>
    public void PauseSound(string name)
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            if (soundEffects[i].audioName == name)
            {
                soundEffects[i].Pause();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Resume music from the array.
    /// </summary>
    public void ResumeMusic(string name)
    {
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i].audioName == name)
            {
                music[i].Resume();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Resume a sound-effect from the array.
    /// </summary>
    public void ResumeSound(string name)
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            if (soundEffects[i].audioName == name)
            {
                soundEffects[i].Resume();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Stop music from the array.
    /// </summary>
    public void StopMusic(string name)
    {
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i].audioName == name)
            {
                music[i].Stop();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
    }

    /// <summary>
    /// Stop a sound-effect from the array.
    /// </summary>
    public void StopSound(string name)
    {
        for (int i = 0; i < soundEffects.Length; i++)
        {
            if (soundEffects[i].audioName == name)
            {
                soundEffects[i].Stop();
                return;
            }
        }

        Debug.Log("AudioManager: " + name + " not found in list.");
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