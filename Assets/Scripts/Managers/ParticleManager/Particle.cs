using UnityEngine;

[System.Serializable]
public class Particle
{
    [SerializeField] private string name;

    [SerializeField] private ParticleSystem particle;

    /// <summary>
    /// Play a particle effect
    /// </summary>
    /// <param name="withChildren"></param>
    public void Play(bool withChildren)
    {
        particle.Play(withChildren);
    }

    /// <summary>
    /// Stop a particle effect
    /// </summary>
    /// <param name="withChildren"></param>
    public void Stop(bool withChildren)
    {
        particle.Stop(withChildren);
    }

    public string particleName
    {
        get { return name; }
        set { name = value; }
    }

    public ParticleSystem particleSystem
    {
        get { return particle; }
        set { particle = value; }
    }
}