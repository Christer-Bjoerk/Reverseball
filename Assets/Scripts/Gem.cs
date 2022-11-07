using System.Collections;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private string sfxGem;
    [SerializeField] private GameEvent loadScene;
    [SerializeField] private float delay = 1f;

    [SerializeField] private int completed = 0;

    private void Awake()
    {
        completed = PlayerPrefs.GetInt("LvL 1", 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            StartCoroutine(GemCollected());
    }

    private IEnumerator GemCollected()
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
        loadScene.TriggerEvent();

        yield return null;
    }
}