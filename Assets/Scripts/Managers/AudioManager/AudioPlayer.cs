using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private string musicName;

    void Start()
    {
        AudioManager.instance.PlayMusic(musicName);
    }
}
