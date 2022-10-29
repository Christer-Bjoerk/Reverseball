using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPos : MonoBehaviour
{
    [SerializeField] private Transform startPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Go back to the start position
            collision.gameObject.transform.position = startPos.position;
        }
    }
}
