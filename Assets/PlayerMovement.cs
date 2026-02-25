using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Rigidbody2D rb;
    private Vector2 movement;
    private float jumpStrength = 6f;
    public bool isGrounded;

    public bool isDead;

    public float dashCD;
    public float jumpTimer = 0f;
    private float facingDirection = 1f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (movement.x != 0)
        {
            facingDirection = Mathf.Sign(movement.x);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpTimer > 0)
        {
            var y = new Vector2(0f, jumpStrength);
            rb.AddForce(y, ForceMode2D.Impulse);
            isGrounded = false;
        }
        if (isDead)
        {
            Time.timeScale = 0;
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
        if (dashCD > 0)
        {
            dashCD -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCD < 1)
        {
            rb.AddForce(Vector2.right * facingDirection * 100, ForceMode2D.Impulse);
            dashCD = 3;
        }
        if (isGrounded == true)
        {
            jumpTimer = 0.1f;
        }
        else if (isGrounded == false)
        {
            jumpTimer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Spikes")
        {
            isDead = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
