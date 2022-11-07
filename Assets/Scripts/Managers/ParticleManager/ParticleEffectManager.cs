using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectManager : MonoBehaviour
{
    public static ParticleEffectManager instance;

    [SerializeField] private Transform parent;

    [SerializeField] private Particle[] particle;

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
    /// Play a particle effect
    /// Optional, play its children
    /// </summary>
    /// <param name="name"></param>
    /// <param name="withChildren"></param>
    public void PlayParticleEffect(string name, bool withChildren)
    {
        for (int i = 0; i < particle.Length; i++)
        {
            if (particle[i].particleName == name)
            {
                particle[i].Play(withChildren); 
            }
        }
    }

    /// <summary>
    /// Stop playing a particle effect
    /// Optional, stop playing its children
    /// </summary>
    /// <param name="name"></param>
    /// <param name="withChildren"></param>
    public void StopParticleEffect(string name, bool withChildren)
    {
        for (int i = 0; i < particle.Length; i++)
        {
            if (particle[i].particleName == name)
            {
                particle[i].Play(withChildren);
            }
        }
    }
}
