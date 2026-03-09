using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _moveSpeed = 5f;
    private PlayerInput _playerInput;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        Move(_playerInput.MoveDirection);
    }

    public void Move(Vector2 direction)
    {
        _rb.velocity = direction * _moveSpeed;
    }
}