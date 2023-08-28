using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelectionRotator : MonoBehaviour, IPointerMoveHandler
{
    private void OnMouseOver()
    {
        Debug.Log(Input.mousePosition);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        Debug.Log(transform.position + " " + Input.mousePosition);
    }
}
