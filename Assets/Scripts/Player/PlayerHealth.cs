using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _enemyLayer) != 0)
        {
            GameManager.Instance.ChangeState(GameState.GameOver);
            Debug.Log("Player hit by enemy, game over!");
        }
    }
}
