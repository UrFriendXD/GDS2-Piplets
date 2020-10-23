using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipletSilhouettes : MonoBehaviour
{
    [SerializeField] private PipletStats _pipletStats;
    [SerializeField] private Image _spriteRenderer;

    private void OnValidate()
    {
        _spriteRenderer = GetComponent<Image>();
    }

    public void Open()
    {
        if (_pipletStats.isUnlocked)
        {
            _spriteRenderer.sprite = _pipletStats.icon;
        }
    }
}
