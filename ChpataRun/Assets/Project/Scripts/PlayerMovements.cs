using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PlayerMovements : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2;

    public float jumpForce = 50;
    public bool isGrounded;
    public bool isJumped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = Input.GetAxis("Horizontal") != 0 ? new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y) : new Vector2(rb.velocity.x - rb.velocity.x/10, rb.velocity.y);

        if ((Input.GetKey(KeyCode.Space) && isGrounded == true) || (Input.GetKey(KeyCode.UpArrow) && isGrounded == true) || (Input.GetKey(KeyCode.Z) && isGrounded == true))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
       rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y > 0 ? rb.velocity.y * 0.9f : rb.velocity.y * 1.1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("GameOver");
            Destroy(gameObject, 0.1f);
        }
    }

}
