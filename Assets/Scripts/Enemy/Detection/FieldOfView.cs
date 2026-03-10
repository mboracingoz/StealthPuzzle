using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private float _viewRadius = 5f;
    [SerializeField] private float _viewAngel = 90f;
    [SerializeField] private float _viewDirectionOffset = 0f;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private LayerMask _obstacleMask;

    private EnemyAI _enemyAI;

    void Awake()
    {

        _enemyAI = GetComponent<EnemyAI>();

    }

    void Update()
    {
        DetectPlayer();
    }



    private void DetectPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _viewRadius, _playerMask);
        Vector3 forward = Quaternion.Euler(0, 0, _viewDirectionOffset) * transform.up;

        foreach (Collider2D hit in hits)
        {
            Vector2 directionToPlayer = (hit.transform.position - transform.position).normalized;
            float angleTo = Vector2.Angle(forward, directionToPlayer);
            float distanceTo = Vector2.Distance(transform.position, hit.transform.position);

            if (angleTo < _viewAngel / 2f)
            {
                if (!Physics2D.Raycast(transform.position, directionToPlayer, distanceTo, _obstacleMask))
                {
                    _enemyAI.ChangeState(EnemyState.Alert);
                    return;
                }
            }
        }
        if (_enemyAI.CurrentState == EnemyState.Alert || _enemyAI.CurrentState == EnemyState.Patrol) _enemyAI.ChangeState(EnemyState.Patrol);
    }
    private void OnDrawGizmos()
    {
        Vector3 forward = Quaternion.Euler(0, 0, _viewDirectionOffset) * transform.up;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _viewRadius);

        Vector3 leftBoundary = Quaternion.Euler(0, 0, _viewAngel / 2f) * forward;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, -_viewAngel / 2f) * forward;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, leftBoundary * _viewRadius);
        Gizmos.DrawRay(transform.position, rightBoundary * _viewRadius);
    }
}
