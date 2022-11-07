using System.Collections;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private string sfxGem;
    [SerializeField] private GameEvent loadScene;
    [SerializeField] private float delay = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(GemCollected());
        }
    }

    private IEnumerator GemCollected()
    {
        // Play particle effect
        ParticleEffectManager.instance.PlayParticleEffect(sfxGem, false);

        // Play sfx
        AudioManager.instance.PlaySound(sfxGem);

        // Unlock the next level
        // Save progress
        GameManager.instance.UnlockNextLevel();

        yield return new WaitForSeconds(delay);

        // Load next level
        loadScene.TriggerEvent();

        yield return null;
    }
}