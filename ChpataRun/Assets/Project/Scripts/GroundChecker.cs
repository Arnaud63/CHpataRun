using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]
    private PlayerMovements playerMovements; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerMovements.isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerMovements.isGrounded = false;
    }
}
