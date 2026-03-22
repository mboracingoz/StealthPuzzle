using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private float _interactRadius = 1.5f;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Sprite _openSprite;
    [SerializeField] private GameObject _moneyPrefab;
    [SerializeField] private float _closeAfterSeconds = 3.5f;

    private SpriteRenderer _spriteRenderer;
    private Sprite _closedSprite;
    private bool _isOpen = false;
    private float _closeTimer = 0f;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _closedSprite = _spriteRenderer.sprite;
    }

    void Update()
    {
        if (_isOpen)
        {
            _closeTimer += Time.deltaTime;
            if (_closeTimer >= _closeAfterSeconds)
                CloseChest();
            return;
        }

        if (!Input.GetKeyDown(KeyCode.E)) return;

        Collider2D hit = Physics2D.OverlapCircle(transform.position, _interactRadius, _playerLayer);
        if (hit == null) return;

        PlayerInventory playerInventory = hit.GetComponent<PlayerInventory>();
        if (playerInventory == null) return;

        if (playerInventory.UseKey())
            OpenChest();
        else
            Debug.Log("You need a key!");
    }


    private void OpenChest()
    {
        _isOpen = true;
        _closeTimer = 0f;
        
        if (_openSprite != null)
        {
            _spriteRenderer.sprite = _openSprite;
        }

        if (_moneyPrefab != null)
        {
            Instantiate(_moneyPrefab, transform.position,Quaternion.identity);
        }

        Debug.Log("Chest opened! You found some money!");
    }

    private void CloseChest()
    {
        _isOpen = false;
        _spriteRenderer.sprite = _closedSprite;
        Debug.Log("Chest closed.");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _interactRadius);
    }
}
