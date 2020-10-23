using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomPCUIWindow : MonoBehaviour
{
    [SerializeField] private PipletSilhouettes[] _pipletSilhouetteses;
    private bool _inUse;

    private void OnValidate()
    {
        _pipletSilhouetteses = GetComponentsInChildren<PipletSilhouettes>(true);
    }

    public void OpenUI()
    {
        if (!_inUse)
        {
            _inUse = true;
            
            gameObject.SetActive(true);

            foreach (var piplet in _pipletSilhouetteses)
            {
                piplet.Open();
            }
        }
    }
    
    public void CloseUI()
    {
        if (!_inUse) return;
        
        _inUse = false;
        gameObject.SetActive(false);
    }
    
}