using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsMovingRight = false;
    public bool IsMovingLeft = false;
    public bool IsFlying = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerEnter.name == "Walk R Button")
        {
            IsMovingRight = true;
            IsMovingLeft = false;
        }
        else if (eventData.pointerEnter.name == "Walk L Button")
        {
            IsMovingLeft = true;
            IsMovingRight = false;
        }

        if (eventData.pointerEnter.name == "Fly Button")
        {
            IsFlying = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsMovingRight = false;
        IsMovingLeft = false;
        IsFlying = false;
    }
}

