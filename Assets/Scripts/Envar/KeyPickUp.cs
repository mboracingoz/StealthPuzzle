using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    [SerializeField] private float _pickupRadius = 1f;
    [SerializeField] private LayerMask _playerLayer;

    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _pickupRadius, _playerLayer);
        if (hit == null) return;  // hit yoksa çık

        PlayerInventory inventory = hit.GetComponent<PlayerInventory>();
        if (inventory == null) return;  // inventory yoksa çık

        inventory.AddKey();
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, _pickupRadius);
    }
}
