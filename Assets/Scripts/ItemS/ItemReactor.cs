using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReactor : Item
{
    const float REACTOR_HEAL = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Recolected();
            CreateParticles();
        }

        if (collision.gameObject.tag == "Player")
        {
            Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();
            PlayerDetections playerDetections = collision.gameObject.GetComponent<PlayerDetections>();
            jetpack.AddEnergy(REACTOR_HEAL);

            Recolected();
            CreateParticles();
        }
    }
}
