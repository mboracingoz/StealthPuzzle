using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    [SerializeField] private GameObject _stonePrefab;
    [SerializeField] private float _throwForce = 8f;
    [SerializeField] private Transform _throwPoint;
    [SerializeField] private int _maxStones = 3;
    [SerializeField] private float _cooldownDuration = 3f;

    private PlayerInput _playerInput;
    private Vector2 _lastFacingDirection = Vector2.up;
    private int _remainingStones;
    private float _cooldownTimer = 0f;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _remainingStones = _maxStones;
    }

    private void Update()
    {
        if (_playerInput.MoveDirection != Vector2.zero)
            _lastFacingDirection = _playerInput.MoveDirection;

        if (_cooldownTimer > 0f)
            _cooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
            TryThrow();
    }

    private void TryThrow()
    {
        if (_remainingStones <= 0) return;
        if (_cooldownTimer > 0f) return;

        Throw();
        _remainingStones--;
    
        _cooldownTimer = _cooldownDuration;
    }

    private void Throw()
    {
        GameObject stone = Instantiate(_stonePrefab, _throwPoint.position, Quaternion.identity);
        Rigidbody2D rb = stone.GetComponent<Rigidbody2D>();
        rb.AddForce(_lastFacingDirection * _throwForce, ForceMode2D.Impulse);
    }
}