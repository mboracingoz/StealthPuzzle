using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTİmer : MonoBehaviour
{
    public static LevelTİmer Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _bestTimeText;

    private float _elapsedTime = 0f;
    private bool _isRunning = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
       _isRunning = true;
       int sceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
       float best = PlayerPrefs.GetFloat("BestTime_Level_" + sceneIndex, 0f);
       _bestTimeText.text = best > 0 ? $"Best {FormatTime(best)}" : "Best: --"; 
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isRunning) return;
        _elapsedTime += Time.deltaTime;
        _timerText.text = FormatTime(_elapsedTime);   
    }

    public void StopTimer()
    {
        _isRunning = false;
        SaveBestTime();
    }

    private void SaveBestTime()
    {
        int sceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        float bestTime = PlayerPrefs.GetFloat($"BestTime_Level_{sceneIndex}", 0f);

        if (bestTime == 0f || _elapsedTime < bestTime)
        {
            PlayerPrefs.SetFloat($"BestTime_Level_{sceneIndex}", _elapsedTime);
            PlayerPrefs.Save();
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:00}:{seconds:00}";
    }
}
