using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (FadeManager.Instance != null)
        {
            return;
        }
    }

    public void OnPlayBTN()
    {
        FadeManager.Instance.LoadScene(1);
    }

    public void OnSettingsBTN()
    {
        _settingsPanel.SetActive(true);
    }
}
