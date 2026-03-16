using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionObject : MonoBehaviour
{
    [SerializeField] private float _distractionRadius = 4f;
    [SerializeField] private LayerMask _enemyLayer;

    void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerDistraction();
    }

    private void TriggerDistraction()
    {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _distractionRadius, _enemyLayer);

            foreach (Collider2D hit in hits)
            {
                EnemyAI enemyAI = hit.GetComponent<EnemyAI>();
                if (enemyAI != null)
                {
                    enemyAI.ChangeState(EnemyState.Search, transform.position);
                }

                Destroy(gameObject);
            }
    }

    private void OawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _distractionRadius);   
     }
}
