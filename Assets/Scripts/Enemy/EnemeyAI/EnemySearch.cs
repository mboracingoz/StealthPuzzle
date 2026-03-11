using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch : MonoBehaviour
{
    [SerializeField] private float _searchDuration = 4f;
    [SerializeField] private float _arrivalThreshold = 0.3f;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _rotationSpeed = 10f;

    private Rigidbody2D _rigidbody;
    private EnemyAI _enemyAI;

    private Vector2 _lastKnownPosition;
    private float _searchTimer = 0f;
    private bool _arrivedAtLastPosition = false;


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemyAI = GetComponent<EnemyAI>();
    }


    public void StartSearch(Vector2 lastKnowPos)
    {
        _lastKnownPosition = lastKnowPos;
        _searchTimer = 0f;
        _arrivedAtLastPosition = false;
    }

    public void UpdateSearch()
    {
        Debug.Log($"Searching — arrived: {_arrivedAtLastPosition}, pos: {_lastKnownPosition}");

        if (!_arrivedAtLastPosition)
        {
            MoveToLastKnowPosition();
            return;
        }

        _searchTimer += Time.deltaTime;
        _rigidbody.velocity = Vector2.zero;

        if (_searchTimer >= _searchDuration)
        {
            _enemyAI.ChangeState(EnemyState.Patrol);
        }
    }

    private void MoveToLastKnowPosition()
    {
        Vector2 dir = (_lastKnownPosition - (Vector2)transform.position).normalized;
        _rigidbody.velocity = dir * _moveSpeed;

        float angel = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, -angel);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);


        float distance = Vector2.Distance(transform.position, _lastKnownPosition);

        if (distance <= _arrivalThreshold)
        {
            _arrivedAtLastPosition = true;
        }
    }
}
