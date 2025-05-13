using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Estado de los botones
    public bool IsMovingRight = false;
    public bool IsMovingLeft = false;
    public bool IsFlying = false;

    // M�todos de la interfaz de eventos
    public void OnPointerDown(PointerEventData eventData)
    {
        // Revisamos el nombre del bot�n para activar la acci�n correcta
        if (eventData.pointerEnter.name == "Walk R Button") // Si el bot�n presionado es el de la derecha
        {
            IsMovingRight = true;
            IsMovingLeft = false; // Si movemos a la derecha, no movemos a la izquierda
        }
        else if (eventData.pointerEnter.name == "Walk L Button") // Si el bot�n presionado es el de la izquierda
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
        // Detener movimiento cuando se suelta el bot�n
        IsMovingRight = false;
        IsMovingLeft = false;
        IsFlying = false;
    }
}

