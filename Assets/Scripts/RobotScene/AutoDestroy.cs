using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float delayBeforeDestruction = 0.3f; // Tiempo en segundos antes de destruir el objeto

    void Start()
    {
        // Llama a la función DestroyObject después del retraso especificado
        Destroy(gameObject, delayBeforeDestruction);
    }
}

