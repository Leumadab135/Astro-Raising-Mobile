using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetections : MonoBehaviour
{
    //Attributes
    public bool IsGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            IsGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
            IsGrounded = false;
    }
}
