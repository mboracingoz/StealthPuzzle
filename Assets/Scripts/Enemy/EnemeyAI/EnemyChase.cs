using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private float _chaseSpeed = 3f;

    [SerializeField] private Transform _playerTransform;

    private Rigidbody2D _rb;
    private EnemyAI _enemyAI;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyAI = GetComponent<EnemyAI>();
    }

    void FixedUpdate()
    {
        if (_enemyAI.CurrentState != EnemyState.Chase) return;
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        Vector2 dir = (_playerTransform.position - transform.position).normalized;
        _rb.velocity = dir * _chaseSpeed;

        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -angle);

        Debug.Log("Chasing player");
    }
}
