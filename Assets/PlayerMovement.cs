using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjustable speed in the Inspector
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame to capture input
    void Update()
    {
        // Get input for the horizontal axis (A/D keys or Left/Right arrows by default)
        movement.x = Input.GetAxisRaw("Horizontal");
        // For simple top-down movement, you might use the vertical axis here too
        // movement.y = Input.GetAxisRaw("Vertical"); 
    }

    // FixedUpdate is called at a fixed interval and is ideal for physics operations
    void FixedUpdate()
    {
        // Apply movement to the Rigidbody2D's velocity
        // The y velocity is maintained for effects like gravity or jumping
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
    }
}
