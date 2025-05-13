using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandExplosion : MonoBehaviour
{
    [SerializeField] private GameObject handExplosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Instantiate(handExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}


