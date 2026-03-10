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

        switch (newState)
        {
            case GameState.GameOver:
                UIManager.Instance.ShowGameOver();
                break;
            case GameState.LevelComplete:
                UIManager.Instance.ShowLevelComplete();
                break;
            default:
                break;
        }

        Debug.Log($"Game state changed to {newState}");
    }
}
