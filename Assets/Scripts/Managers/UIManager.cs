using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _levelCompletePanel;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        _gameOverPanel.SetActive(false);
        _levelCompletePanel.SetActive(false);
    }


    public void ShowGameOver()
    {
        _gameOverPanel.SetActive(true);
    }

    public void ShowLevelComplete()
    {
        _levelCompletePanel.SetActive(true);
    }

}
