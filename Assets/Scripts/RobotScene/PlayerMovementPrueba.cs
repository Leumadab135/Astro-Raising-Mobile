using UnityEditor;
using UnityEngine;

public class PlayerMovementPrueba : MonoBehaviour
{
    //Attributes
    [SerializeField] private Rigidbody2D playerRigidbody;
    private float speed = 5;
    private float jumpForce = 5f;
    public bool isGrounded;
    public bool _changeScale;

    //Methods
    void Update()
    {
        //Left/Right Movement
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.A))
            _changeScale = true;

        if (Input.GetKeyDown(KeyCode.D))
            _changeScale = false;

        if (_changeScale == false) 
            transform.localScale = new Vector2(1,1);
            
        if (_changeScale == true)
            transform.localScale = new Vector2(-1,1);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();

        //Block Movement while Blocking
        if (Input.GetKey(KeyCode.F))
            speed = 0;
        if (Input.GetKeyUp(KeyCode.F))
            speed = 5;


    }

    void Jump()
    {
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

