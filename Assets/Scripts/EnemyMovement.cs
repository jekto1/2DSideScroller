using System;
using Unity.Mathematics;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public Transform wallDetector;
    public LayerMask wallLayer;
    private bool movingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetector.position, transform.right, 0.2f, wallLayer);
        if (wallInfo.collider != null)
        {
            movingRight = !movingRight;
            transform.eulerAngles = new Vector3(0, movingRight ? 0 : 180, 0);
        }
    }



}

