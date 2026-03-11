using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    [SerializeField] private LayerMask _hideSpotLayer;
    [SerializeField] private float _hiddenAlpha = 0.4f;
    [SerializeField] private float _fadeSpeed = 5f;

    private SpriteRenderer _spriteRenderer;
    private float _targetAlpha = 1f;

    public bool isHiding { get; private set; } = false;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Color color = _spriteRenderer.color;
        color.a = Mathf.Lerp(color.a, _targetAlpha, _fadeSpeed * Time.deltaTime);
        _spriteRenderer.color = color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((1 << other.gameObject.layer & _hideSpotLayer) != 0)
        {
            isHiding = true;
            _targetAlpha = _hiddenAlpha;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((1 << other.gameObject.layer & _hideSpotLayer) != 0)
        {
            isHiding = false;
            _targetAlpha = 1f;
        }
    }
}
