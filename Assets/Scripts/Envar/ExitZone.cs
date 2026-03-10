using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitZone : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _playerLayer) != 0)
        {
            GameManager.Instance.ChangeState(GameState.LevelComplete);
            Debug.Log("Player entered exit zone, level complete!");
        }
    }
}
