using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference actionPlayerMovement;

    [SerializeField] private float jumpHeight;
    [SerializeField] private float movementSpeed;

    [SerializeField] private UnityEvent UIEvents;

    private Rigidbody2D rb2D;
    private bool move = true;

    private void OnEnable()
    {
        actionPlayerMovement.action.Enable();
    }

    private void OnDisable()
    {
        actionPlayerMovement.action.Disable();
    }

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (move)
        {
            Vector2 dirX = actionPlayerMovement.action.ReadValue<Vector2>();

            rb2D.velocity = new Vector2(dirX.x * movementSpeed, rb2D.velocity.y);

            //if (Input.GetKey(KeyCode.Space))
            //    rb2D.velocity = new Vector2(0, jumpHeight);
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

        // Display Credits
        SceneManager.LoadScene("CreditsScene");

        yield return null;
    }
}