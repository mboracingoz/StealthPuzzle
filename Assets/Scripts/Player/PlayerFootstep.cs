using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstep : MonoBehaviour
{
    [SerializeField] private float _normalRadius = 0f;
    [SerializeField] private float _movingRadius = 1f;
    [SerializeField] private float _radiusChangeSpeed = 5f;

    private PlayerInput _playerInput;

    public float CurrentNoiseRadius { get; private set; }

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetRadius = _playerInput.MoveDirection != Vector2.zero ? _movingRadius : _normalRadius;

        CurrentNoiseRadius = Mathf.Lerp(CurrentNoiseRadius, targetRadius, _radiusChangeSpeed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, CurrentNoiseRadius);
    }
}
