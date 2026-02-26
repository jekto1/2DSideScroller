using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
        // Movement input
        if (!isDashing) // lock input during dash
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            if (movement.x != 0)
                facingDirection = Mathf.Sign(movement.x);
        }

        // Ground check using BoxCollider bounds
        Bounds bounds = boxCollider.bounds;
        float extraHeight = 0.1f;
        isGrounded = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, extraHeight, groundLayer);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer <= 0f && !isDashing)
            StartDash();

        // Cooldown
        if (dashTimer > 0f) dashTimer -= Time.deltaTime;
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes"))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            Time.timeScale = 0;
        }
    }
}
