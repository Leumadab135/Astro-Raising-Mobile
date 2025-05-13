using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour, IRecolectable
{
    enum ItemTypes
    {
        None,
        Rock,
        Piragna,
        Reactor,
        Mineral
    }

    //Attributes
    [SerializeField] ItemTypes Type { get; set; }
    public GameObject _effect;

    public void Recolected()
    {
        Destroy(gameObject);
    }

    public void CreateParticles()
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
    }


}
