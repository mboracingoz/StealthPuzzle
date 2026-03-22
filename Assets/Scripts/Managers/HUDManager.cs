using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _stoneTXT;
    [SerializeField] private UnityEngine.UI.Image _keyIcon;
    [SerializeField] private UnityEngine.UI.Image _moneyIcon;

    [SerializeField] private Color _activeColor = Color.white;
    [SerializeField] private Color _inactiveColor = new Color(1,1,1,0.3f);

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
        _keyIcon.color = _inactiveColor;
        _moneyIcon.color = _inactiveColor;
    }


    public void UpdateStoneCount(int count)
    {
        _stoneTXT.text = "x" + count;
    }

    public void UpdateKeyStatus(bool hasKey)
    {
        _keyIcon.color = hasKey ? _activeColor : _inactiveColor;
    }

    public void UpdateMoneyStatus(bool hasMoney)
    {
        _moneyIcon.color = hasMoney ? _activeColor : _inactiveColor;
    }
}
