using Unity.VisualScripting;
using UnityEngine;

public class pler : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5f;
    private float jumpStrength = 10f;
    private bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        var x = horizontalInput * speed * Time.deltaTime;
        var newpos = new Vector3(x, 0f , 0f);
        //transform.Translate(newpos);





        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            var y = new Vector2(0f, jumpStrength);
            rb.AddForce(y, ForceMode2D.Impulse);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
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
