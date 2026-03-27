using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set; }

    [SerializeField] private Joystick _joystick;

    private void Update() {
        Vector2 keyboardInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (keyboardInput != Vector2.zero)
        {
            MoveDirection = keyboardInput.normalized;
        }else
        {
            MoveDirection = new Vector2(_joystick.Horizontal, _joystick.Vertical).normalized;
        }
    }

}