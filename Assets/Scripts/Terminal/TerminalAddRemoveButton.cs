using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TerminalAddRemoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler,
    IPointerExitHandler
{
    // Player variables set from terminal
    //[HideInInspector]
    public Inventory PlayerInventory;

    // Values for selling 
    protected bool _adding, _removing;
    protected float _delay;
    protected int _amount;
    [SerializeField] protected float delayReset = 0.2f;
    
    [SerializeField] protected TextMeshProUGUI amountText;
    
    // Cursor stuff
    [SerializeField] private Texture2D hoverCursorTexture;
    [SerializeField] private Texture2D normalCursorTexture;
    private CursorMode _cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    // Audio stuff
    public AK.Wwise.Event pass;
    public AK.Wwise.Event fail;
    protected bool Success;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        // If already add or removing ignore. Forces only one MB active
        if (_adding || _removing) return;

        //Debug.Log(eventData.pointerId);
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

        //Debug.Log("click");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _adding = false;
        _removing = false;
        if (Success)
        {
            pass.Post(gameObject);
        }
        else
        {
            fail.Post(gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(hoverCursorTexture, hotSpot, _cursorMode);
    }

    public void OnPointerExit(PointerEventData eventData)
    { 
        Cursor.SetCursor(normalCursorTexture, hotSpot, _cursorMode);
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
    
