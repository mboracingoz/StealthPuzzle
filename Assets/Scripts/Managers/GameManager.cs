using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState CurrentState { get; private set; } = GameState.Playing;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ChangeState(GameState newState)
    {
        if (CurrentState == newState) return;
        CurrentState = newState;

        if (newState == GameState.GameOver)
        {
            UIManager.Instance.ShowGameOver();
        }

        Debug.Log($"Game state changed to {newState}");
    }
}
