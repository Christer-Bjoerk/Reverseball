using System.Collections;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] protected string sfxGem;
    [SerializeField] protected GameEvent levelCompletion;
    [SerializeField] protected float delay = 1f;

    [SerializeField] protected int completed = 0;

    protected virtual void Awake()
    {
        completed = PlayerPrefs.GetInt("LvL 1", 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            StartCoroutine(GemCollected());
    }

    protected virtual IEnumerator GemCollected()
    {
        // Play particle effect
        ParticleEffectManager.instance.PlayParticleEffect(sfxGem, false);

        // Play sfx
        AudioManager.instance.PlaySound(sfxGem);

        // Unlock the next level
        // Save progress

        if (completed < 1)
        {
            completed = 1;
            PlayerPrefs.SetInt("LvL 1", 1);
            GameManager.instance.UnlockNextLevel();
        }

        yield return new WaitForSeconds(delay);

        // Load next level
        levelCompletion.TriggerEvent();

        yield return null;
    }
}