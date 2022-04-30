using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBR : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 100f;

    public Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Move()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // Debug.Log("move left");
            pos.x -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // Debug.Log("move right");
            pos.x += speed * Time.deltaTime;
        }
        transform.position = pos;
    }

    void Jump()
    {
        rb2d.AddForce(Vector2.up * jumpForce);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        rb2d.gravityScale = other.GetComponent<Ball>().GetGravityScale();
    }
}
