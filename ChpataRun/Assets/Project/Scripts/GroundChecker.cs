using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]
    private PlayerMovements playerMovements; 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerMovements.isGrounded = true;
            playerMovements.isJumped = false;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        playerMovements.isGrounded = false;
    }
}
