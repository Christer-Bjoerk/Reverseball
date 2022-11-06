using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Audio
{
    [SerializeField]
    private string name;

    [SerializeField]
    private AudioClip clip;

    [SerializeField]
    [Range(0f, 1f)]
    private float volume = 0.7f;

    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float pitch = 1f;

    [SerializeField]
    [Range(0f, 0.5f)]
    private float randomVolume = 0.1f;

    [SerializeField]
    [Range(0f, 0.5f)]
    private float randomPitch = 0.1f;

    [SerializeField]
    private bool loop = false;

    private AudioSource source;

    public void Play()
    {
        source.Play();
    }

    public void Pause()
    {
        source.Pause();
    }

    public void Resume()
    {
        source.UnPause();
    }

    public void Stop()
    {
        source.Stop();
    }

    public AudioSource audioSource
    {
        get { return source; }
        set { source = value; }
    }

    public AudioClip audioClip
    {
        get { return clip; }
        set { clip = value; }
    }

    public string audioName
    {
        get { return name; }
        set { name = value; }
    }

    public bool audioLoop
    {
        get { return loop; }
        set { loop = value; }
    }

    public float audioVolume
    {
        get { return volume; }
        set { volume = value; }
    }
}
