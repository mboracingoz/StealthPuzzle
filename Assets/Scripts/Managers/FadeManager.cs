using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance {get; private set;}

    [SerializeField] private Image _fadePanel;
    [SerializeField] private float _fadeDuration = .5f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(FadeOutAndLoad(sceneIndex));
    }

    private IEnumerator FadeIn()
    {
        _fadePanel.gameObject.SetActive(true);  
        float timer = 0f;
        Color color = Color.black;

        while (timer < _fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = 1f - (timer / _fadeDuration);
            _fadePanel.color = color;
            yield return null;
        }

        color.a = 0f;
        _fadePanel.color = color;
        _fadePanel.gameObject.SetActive(false);
    }

    private IEnumerator FadeOutAndLoad(int sceneIndex)
    {
        _fadePanel.gameObject.SetActive(true);
        float timer = 0f;
        Color color = Color.black;
        color.a = 0f;
        _fadePanel.color = color;

        while (timer < _fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = timer / _fadeDuration;
            _fadePanel.color = color;
            yield return null;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
