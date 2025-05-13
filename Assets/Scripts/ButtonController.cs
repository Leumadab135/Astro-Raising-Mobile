using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Estado de los botones
    public bool IsMovingRight = false;
    public bool IsMovingLeft = false;
    public bool IsFlying = false;

    // Métodos de la interfaz de eventos
    public void OnPointerDown(PointerEventData eventData)
    {
        // Revisamos el nombre del botón para activar la acción correcta
        if (eventData.pointerEnter.name == "Walk R Button") // Si el botón presionado es el de la derecha
        {
            IsMovingRight = true;
            IsMovingLeft = false; // Si movemos a la derecha, no movemos a la izquierda
        }
        else if (eventData.pointerEnter.name == "Walk L Button") // Si el botón presionado es el de la izquierda
        {
            IsMovingLeft = true;
            IsMovingRight = false; // Si movemos a la izquierda, no movemos a la derecha
        }

        if (eventData.pointerEnter.name == "Fly Button")
        {
            IsFlying = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Detener movimiento cuando se suelta el botón
        IsMovingRight = false;
        IsMovingLeft = false;
        IsFlying = false;
    }
}

