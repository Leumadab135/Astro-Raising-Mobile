using UnityEngine;

public class ItemMineral : Item
{
    const float MINERAL_TRANSLATE = 2.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Recolected();
            CreateParticles();
        }

        if (collision.gameObject.tag == "Player")
        {
            Transform playerTransform = collision.gameObject.GetComponent<Transform>();
            PlayerDetections playerDetections = collision.gameObject.GetComponent<PlayerDetections>();

            if (playerDetections.IsGrounded == false)
                playerTransform.GetComponent<Transform>().Translate(Vector2.down * MINERAL_TRANSLATE);
            else
                playerTransform.GetComponent<Transform>().Translate(Vector2.up * MINERAL_TRANSLATE);


            Recolected();
            CreateParticles();
        }
    }
}
