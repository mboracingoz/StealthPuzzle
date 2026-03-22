using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickUp : MonoBehaviour
{
    [SerializeField] private float _pickupRadius = 1f;
    [SerializeField] private LayerMask _playerLayer;

    private float _spawnDelay = 1f;
    private float _spawnTimer = 0f;

    void Update()
    {
        if (_spawnTimer < _spawnDelay)
        {
            _spawnTimer += Time.deltaTime;
            return;
        }

        Collider2D hit = Physics2D.OverlapCircle(transform.position, _pickupRadius, _playerLayer);
        if (hit == null) return;

        PlayerInventory playerInventory = hit.GetComponent<PlayerInventory>();
        if (playerInventory == null) return;

        playerInventory.AddMoney();
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _pickupRadius);
    }
}
