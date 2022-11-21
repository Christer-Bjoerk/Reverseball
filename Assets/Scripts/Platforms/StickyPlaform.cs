using UnityEngine;

public class StickyPlaform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Make the player stick to the platform
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Make the player unstick from the platform
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.transform.SetParent(null);
    }
}