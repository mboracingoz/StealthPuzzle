using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThrowButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerThrow _playerThrow;

    public void OnPointerDown(PointerEventData eventData)
    {
        _playerThrow.OnThrowButtonDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _playerThrow.OnThrowButtonUp();
    }
}