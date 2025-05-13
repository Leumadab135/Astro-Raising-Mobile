using UnityEngine;

public class ItemPiragna : Item
{
    const float PIRAGNA_DAMAGE = -20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(_effect, transform.position, Quaternion.identity);
            Recolected();
        }

        if (collision.gameObject.tag == "Player")
        {
            Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();
            Animator _anim = collision.gameObject.GetComponent<Animator>();

            _anim.SetTrigger("AstroHit");
            jetpack.AddEnergy(PIRAGNA_DAMAGE);

            Instantiate(_effect, transform.position, Quaternion.identity);
            Recolected();
        }
    }
}

