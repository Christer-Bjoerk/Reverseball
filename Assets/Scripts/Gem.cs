using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gemCollecting;
    [SerializeField] private ParticleSystem gemParticle;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(gemCollecting);
            gemParticle.Play();

            // Unlock the next level & save progress
            // Will get a null error if there's no level to unlock
            GameManager.instance.UnlockNextLevel();

            // Load the next level through SceneManager
        }
    }
}