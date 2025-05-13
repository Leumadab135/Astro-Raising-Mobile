using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WindTunnel : MonoBehaviour
{
    private float windForce = 500f;

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 windDirection = transform.up;
            rb.AddForce(windDirection * windForce);
        }
    }
}
