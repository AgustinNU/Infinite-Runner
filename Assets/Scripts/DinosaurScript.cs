using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float upForce;
    private Rigidbody2D dinoRb;
    private int groundContactCount = 0;
    private bool isGrounded = false;
    private Animator dinoAnimator;
    private bool canJump = true;
    void Start()
    {
        dinoRb = GetComponent<Rigidbody2D>();
        dinoAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = groundContactCount > 0 && canJump; ;
        dinoAnimator.SetBool("IsGrounded", isGrounded);

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            dinoRb.AddForce(Vector2.up * upForce);
            canJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContactCount++;
            canJump = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManagerScript.Instance.GameOver();
            dinoAnimator.SetTrigger("Die");
            Time.timeScale = 0f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (groundContactCount < 0)
        {
            groundContactCount = 0;
        }
    }
}
