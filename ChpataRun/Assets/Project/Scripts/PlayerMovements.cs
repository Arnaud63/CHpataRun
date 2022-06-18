using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PlayerMovements : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2;

    public float jumpForce = 5;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if ((Input.GetKey(KeyCode.Space) && isGrounded == true) || (Input.GetKey(KeyCode.UpArrow) && isGrounded == true) || (Input.GetKey(KeyCode.Z) && isGrounded == true))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
