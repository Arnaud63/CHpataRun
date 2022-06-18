using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovements : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GameManager manager;
    [SerializeField] public Text text;
    [SerializeField] public Canvas canvas;


    [SerializeField] public Button restartButton;
    [SerializeField] public Button quitButton;
    public float speed = 2;

    public float jumpForce = 50;
    public bool isGrounded;
    public bool oneTimeJumped = false;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        animator.SetBool("MoveChpatata", Input.GetAxis("Horizontal") != 0 ? true : false);
        gameObject.transform.localScale = Input.GetAxis("Horizontal") < 0 ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);

        rb.velocity = Input.GetAxis("Horizontal") != 0 ? new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y) : new Vector2(rb.velocity.x - rb.velocity.x/10, rb.velocity.y);

        if ( (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z)) && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetTrigger("JumpChpatata");
            animator.ResetTrigger("JumpChpatata");
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
            Destroy(gameObject, 0.1f);
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            manager.SpawnDeadPlayer(this.gameObject);
        }

        if (other.gameObject.CompareTag("Flag"))
        {
            canvas.gameObject.SetActive(true);
            text.text = "You won ! :)";
            text.color = Color.green;

            Destroy(gameObject);
        }
    }

}
