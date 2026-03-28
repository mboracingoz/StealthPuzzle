using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance {get; private set;}

    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private Toggle _soundToggle;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        bool soundON = PlayerPrefs.GetInt("SoundEnabled", 1) == 1;
        _soundToggle.isOn  = soundON;
        AudioListener.volume = soundON ? 1f : 0f;
    }

    public void OpenSettings()
    {
        _settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        _settingsPanel.SetActive(false);
    }


    public void OnSoundToggle(bool isOn)
    {
        AudioListener.volume = isOn ? 1f : 0f;
        PlayerPrefs.SetInt("SoundEnabled", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
