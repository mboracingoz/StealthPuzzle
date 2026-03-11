using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _wayPointThreshold = 0.15f;
    [SerializeField] private float _rotationSpeed = 10f;


    private int _currentPatrolIndex = 0;
    private Rigidbody2D _rigidbody2D;
    private EnemyAI _enemyAI;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _enemyAI = GetComponent<EnemyAI>();
    }


    void FixedUpdate()
    {
        if (_enemyAI.CurrentState != EnemyState.Patrol) return;
        MoveToCurrentPoint();
        CheckWayPointReached();
    }


    private void MoveToCurrentPoint()
    {
        Vector2 dir = (_patrolPoints[_currentPatrolIndex].position - transform.position).normalized;
        _rigidbody2D.velocity = dir * _moveSpeed;

        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, -angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

    }

    private void CheckWayPointReached()
    {
        float distance = Vector2.Distance(transform.position, _patrolPoints[_currentPatrolIndex].position);
        if (distance <= _wayPointThreshold)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
        }

    }
}
