using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ReloadCurrentScene()
    {
        FadeManager.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        if (nextIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("No More Levels ");
        }

        FadeManager.Instance.LoadScene(nextIndex);
    }

    public void LoadMainMenu()
    {
        FadeManager.Instance.LoadScene(0);
    }
}
