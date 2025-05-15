using UnityEngine;

public class PlayerDetections : MonoBehaviour
{
    public bool IsGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Table")
        {
            IsGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Table")
            IsGrounded = false;
    }
}
