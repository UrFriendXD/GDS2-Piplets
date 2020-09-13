using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellingConfirmButton : MonoBehaviour, IPointerDownHandler
{
    public Terminal terminal;

    public void OnPointerDown(PointerEventData eventData)
    {
        terminal.SellItems();
    }
}
