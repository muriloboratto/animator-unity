using UnityEngine;

public class player_Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;

    private float horizontal;
    private bool isGrounded;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }

        bool andando = (horizontal != 0);
        animator.SetBool("isWalking", andando);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", false);
    }
}