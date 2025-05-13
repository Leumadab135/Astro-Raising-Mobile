using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotShooter : MonoBehaviour
{
    [SerializeField] private PlayerMovementPrueba _robotMovement;
    [SerializeField] private GameObject _handPrefab;

    // Update is called once per frame
    void Update()
    {
        //Shoot
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (_robotMovement.isGrounded == true)
                StartCoroutine("HandShootGround");

            if (_robotMovement.isGrounded == false)
                StartCoroutine("HandShootAir");
        }
    }

    IEnumerator HandShootGround()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject hand = Instantiate(_handPrefab, transform.position, Quaternion.identity);

        // Ignorar colisión entre el jugador y la bala
        Collider2D playerCollider = GetComponent<Collider2D>();
        Collider2D handCollider = hand.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(playerCollider, handCollider);

        if (_robotMovement._changeScale == false)
            hand.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 800);

        if (_robotMovement._changeScale == true)
        {
            hand.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -800);
            hand.transform.localScale = new Vector2(-1, 1);
        }

        yield return new WaitForSeconds(1);

        if (hand != null)
            Destroy(hand);
    }

    IEnumerator HandShootAir()
    {
        yield return new WaitForSeconds(0.01f);
        GameObject hand = Instantiate(_handPrefab, transform.position, Quaternion.identity);

        // Ignorar colisión entre el jugador y la bala
        Collider2D playerCollider = GetComponent<Collider2D>();
        Collider2D handCollider = hand.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(playerCollider, handCollider);

        if (_robotMovement._changeScale == false)
            hand.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 800);

        if (_robotMovement._changeScale == true)
        {
            hand.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -800);
            hand.transform.localScale = new Vector2(-1, 1);
        }

        yield return new WaitForSeconds(1);

        if (hand != null)
            Destroy(hand);
    }
}

