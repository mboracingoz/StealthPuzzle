using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    [SerializeField] private GameObject _stonePrefab;
    [SerializeField] private Transform _throwPoint;
    [SerializeField] private int _maxStones = 3;
    [SerializeField] private float _cooldownDuration = 3f;

    [SerializeField] private float _minForce = 1f;
    [SerializeField] private float _maxForce = 15f;
    [SerializeField] private float _chargeSpeed = 5f;

    [SerializeField] private GameObject _trajectoryDotPrefab;
    [SerializeField] private int _trajectoryDotCount = 10;
    [SerializeField] private float _trajectoryDotSpacing = 0.3f;

    private PlayerInput _playerInput;
    private Vector2 _lastFacingDirection = Vector2.up;
    private int _remainingStones;
    private float _cooldownTimer = 0f;
    private float _currentForce = 0f;
    private bool _isCharging = false;
    private GameObject[] _trajectoryDots;
    private bool _isMobileCharging = false;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _remainingStones = _maxStones;

        HUDManager.Instance.UpdateStoneCount(_remainingStones);

        _trajectoryDots = new GameObject[_trajectoryDotCount];
        for (int i = 0; i < _trajectoryDotCount; i++)
        {
            _trajectoryDots[i] = Instantiate(_trajectoryDotPrefab);
            _trajectoryDots[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (_playerInput.MoveDirection != Vector2.zero)
            _lastFacingDirection = _playerInput.MoveDirection;

        if (_cooldownTimer > 0f)
            _cooldownTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            _isCharging = true;
            _currentForce = Mathf.MoveTowards(_currentForce, _maxForce, _chargeSpeed * Time.deltaTime);
            ShowTrajectory();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isCharging = false;
            HideTrajectory();
            TryThrow();
            _currentForce = 0f;
        }

        if (_isMobileCharging)
        {
            _currentForce = Mathf.MoveTowards(_currentForce, _maxForce, _chargeSpeed * Time.deltaTime);
            ShowTrajectory();
        }
    }   

    private void TryThrow()
    {
        if (_remainingStones <= 0 || _cooldownTimer > 0f) return;
        Throw();
        _remainingStones--;
        _cooldownTimer = _cooldownDuration;

        HUDManager.Instance.UpdateStoneCount(_remainingStones);
    }

    private void Throw()
    {
        float force = Mathf.Max(_currentForce, _minForce);
        GameObject stone = Instantiate(_stonePrefab, _throwPoint.position, Quaternion.identity);
        Rigidbody2D rb = stone.GetComponent<Rigidbody2D>();
        rb.AddForce(_lastFacingDirection * force, ForceMode2D.Impulse);
    }

    public void OnThrowButtonDown()
    {
        _isMobileCharging = true;
    }

    public void OnThrowButtonUp()
    {
        _isMobileCharging = false;
        HideTrajectory();
        TryThrowMobile();
        _currentForce = 0f;
    }

    private void ShowTrajectory()
    {
        if (_remainingStones <= 0 || _cooldownTimer > 0f)
        {
            HideTrajectory();
            return;
        }

        float spacing = _trajectoryDotSpacing * (_currentForce / _maxForce);
        spacing = Mathf.Max(spacing, 0.05f);

        for (int i = 0; i < _trajectoryDotCount; i++)
        {
            Vector2 pos = (Vector2)_throwPoint.position + _lastFacingDirection * (i * spacing);
            _trajectoryDots[i].transform.position = pos;
            _trajectoryDots[i].SetActive(true);
        }
    }

    private void HideTrajectory()
    {
        foreach (GameObject dot in _trajectoryDots)
            dot.SetActive(false);
    }

    public void TryThrowMobile()
    {
        if(_remainingStones <= 0 || _cooldownTimer > 0f) return;
        _currentForce = _maxForce;
        Throw();
        _remainingStones--;
        _cooldownTimer = _cooldownDuration;
        HUDManager.Instance.UpdateStoneCount(_remainingStones);
    }
}