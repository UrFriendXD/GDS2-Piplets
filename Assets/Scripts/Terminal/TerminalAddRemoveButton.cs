using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TerminalAddRemoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Player variables set from terminal
    [HideInInspector]
    public Inventory PlayerInventory;
    
    // Values for selling 
    protected bool _adding, _removing;
    protected float _delay;
    protected int _amount;
    [SerializeField] protected float delayReset = 0.2f;

    [SerializeField] private TextMeshProUGUI amountText;

    public void OnPointerDown(PointerEventData eventData)
    {
        // If already add or removing ignore. Forces only one MB active
        if (_adding || _removing) return;
        
        // If LMB add, RMB remove
        switch (eventData.pointerId)
        {
            case -1:
                _adding = true;
                break;
            case -2:
                _removing = true;
                break;
        }
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        _adding = false;
        _removing = false;
    }

    protected virtual void UpdateAmount(int changeAmount)
    {
        _amount = changeAmount;
        amountText.text = _amount.ToString();
    }

    private void OnDisable()
    {
        UpdateAmount(0);
    }
}
