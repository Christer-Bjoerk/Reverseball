using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private float movementSpeed;

    [SerializeField] private UnityEvent UIEvents;

    private Rigidbody2D rb2D;
    private bool move = true;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            float dirX = Input.GetAxis("Horizontal");

            rb2D.velocity = new Vector2(-dirX * movementSpeed, rb2D.velocity.y);

            if (Input.GetKey(KeyCode.Space))
            {
                rb2D.velocity = new Vector2(0, jumpHeight);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Flag"))
        {
            move = false;
            rb2D.velocity = Vector2.zero;

            StartCoroutine(PlayEndCredits());
        }
    }

    private IEnumerator PlayEndCredits()
    {
        // Display Text
        UIEvents?.Invoke();

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("CreditsScene");

        yield return null;
    }
}
