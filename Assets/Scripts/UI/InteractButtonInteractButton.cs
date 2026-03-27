using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractButtonInteractButton : MonoBehaviour, IPointerDownHandler
{
    public static bool IsPressed {get; private set;} = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        IsPressed = true;
    }

    private void LateUpdate()
    {
        IsPressed = false;
    }


}
