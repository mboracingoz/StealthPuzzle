using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _wayPointThreshold = 0.15f;


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

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

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
