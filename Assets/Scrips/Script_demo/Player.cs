using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;


    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float checkTheLenght = 3f;
    private float xInput;
    private bool flip = true;
    private bool isGrounded;
    private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        PlayerMovement();
        PlayerFlip();
        PlayerInput();
        PlayerAnimator();
        checkGround();
    }
    private void PlayerAnimator()
    {
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        anim.SetBool("isGrounded", isGrounded);
    }
    private void PlayerInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayerJump();
        }
    }

    private void PlayerJump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);


    }
    private void checkGround()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, checkTheLenght, groundLayer);
    }
    private void PlayerFlip()
    {
        if(rb.linearVelocity.x > 0 && flip == false) 
        {
            Flip();
        }
        else if(rb.linearVelocity.x < 0 && flip == true)
        {
            Flip();
        }

    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        flip = !flip;
    }

    private void PlayerMovement()
    {
        xInput = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - checkTheLenght));
    }
}
