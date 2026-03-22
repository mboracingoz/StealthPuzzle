using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitZone : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private PlayerInventory _playerInventory;

    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       _spriteRenderer.color = _playerInventory.HasMoney ? Color.green : Color.red;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _playerLayer) == 0) return;

        PlayerInventory playerInventory = collision.GetComponent<PlayerInventory>();
        if (playerInventory == null) return;

        if (playerInventory.HasMoney)
        {
            GameManager.Instance.ChangeState(GameState.LevelComplete);
            Debug.Log("Player entered exit zone, level complete!");
        }
        else
        {
            Debug.Log("You need to money to escape!");
        }
    }
}
