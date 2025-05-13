using UnityEngine;

public class AutoDestroyEffect : MonoBehaviour
{
    public float lifetime = 1.3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}

