using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isDead;
    public float moveSpeed = 5f;
    public float jumpStrength = 6f;
    public float dashForce = 12f;
    public float dashCooldown = 1f;
    public float dashDuration = 0.2f; // how long dash lasts

    private Rigidbody2D rb;
    private Vector2 movement;
    private float facingDirection = 1f;

    private bool isGrounded;
    private float dashTimer;
    private bool isDashing;

    private BoxCollider2D boxCollider;
    public LayerMask groundLayer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isDead == false)
        {
            if (!isDashing)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                if (movement.x != 0)
                    facingDirection = Mathf.Sign(movement.x);
            }

            Bounds bounds = boxCollider.bounds;
            float extraHeight = 0.1f;
            isGrounded = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, extraHeight, groundLayer);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                Jump();

            if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer <= 0f && !isDashing)
                StartDash();

            if (dashTimer > 0f) dashTimer -= Time.deltaTime;

            ScaleFlip(facingDirection);
        }
        
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
    }

    private void StartDash()
    {
        isDashing = true;
        rb.linearVelocity = new Vector2(facingDirection * dashForce, 0f); // forceful dash
        rb.gravityScale = 0f;
        dashTimer = dashCooldown;
        Invoke(nameof(EndDash), dashDuration); // end dash after short time
    }

    private void EndDash()
    {
        isDashing = false;
        rb.gravityScale = 1f;
    }

    public float GetHorizontalSpeed() { return rb.linearVelocity.x; }
    public bool IsGrounded() { return isGrounded; }

    private void ScaleFlip(float facingDirection)
    {
        if (facingDirection < 0)
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (facingDirection > 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes"))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            Time.timeScale = 0;
        }
    }
    private void Die()
    {
        if (facingDirection == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (facingDirection == -1)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }
    public void Revive()
    {
        isDead = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
            isDead = true;
            Time.timeScale = 0;
        }
    }
}
