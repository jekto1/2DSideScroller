using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public Transform wallDetector;
    public LayerMask wallLayer;
    private bool move = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetector.position, -transform.right, 0.2f, wallLayer);
        if (wallInfo.collider != null)
        {
            move = !move;
            transform.eulerAngles = new Vector3(0, move ? 0 : 180, 0);
        }
    }
}

