using UnityEngine;

public class B : MonoBehaviour
{
    [Header("Attack")]
    public GameObject fireBall;

    [Header("Movement")]
    public float runSpeed;
    public float jumpForce;

    [Header("Collision")]
    public float groundedCheckRadius;
    public LayerMask groundLayer;

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private CapsuleCollider2D capsuleCollider2D;

    private bool isGrounded;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x, capsuleCollider2D.bounds.min.y), groundedCheckRadius, groundLayer);

        JumpCheck();
        FireBallCheck();
    }

    private void FixedUpdate()
    {
        MoveHorizontally();
    }

    private void FireBallCheck()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CastFireBall();
        }
    }

    private void CastFireBall()
    {
        Instantiate(fireBall, transform.position, transform.rotation);
    }

    private void JumpCheck()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (animator.GetBool("isFalling"))
            {
                animator.SetBool("isFalling", false);
            }
        }
        else if (!isGrounded)
        {
            if (rigidbody2D.velocity.y < 0f)
            {
                animator.SetBool("isFalling", true);
            } else if (rigidbody2D.velocity.y > 1f && Input.GetKeyUp(KeyCode.Space))
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
            }
        }
    }

    private void Jump()
    {
        rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        animator.SetTrigger("jump");
    }

    private void MoveHorizontally()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            MoveRight();
        } else if (Input.GetAxis("Horizontal") < 0)
        {
            MoveLeft();
        } else
        {
            StopHorizontalMovement();
        }
    }

    private void MoveRight()
    {
        rigidbody2D.velocity = new Vector2(runSpeed * Input.GetAxis("Horizontal"), rigidbody2D.velocity.y);
        transform.localScale = new Vector2(1, transform.localScale.y);
        animator.SetBool("isRunning", true);
    }

    private void MoveLeft()
    {
        rigidbody2D.velocity = new Vector2(runSpeed * Input.GetAxis("Horizontal"), rigidbody2D.velocity.y);
        transform.localScale = new Vector2(-1, transform.localScale.y);
        animator.SetBool("isRunning", true);
    }

    private void StopHorizontalMovement()
    {
        rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);
        animator.SetBool("isRunning", false);
    }
}
