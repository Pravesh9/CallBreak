using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    Card currentCard;

    public void OnDrag(PointerEventData eventData)
    {
    
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (EventSystem.current.currentSelectedGameObject == null) //We've to modify it on saturday.
        {
            DebugManager.LogWithColor(EventSystem.current.currentSelectedGameObject.name, Color.blue);
        }
        Debug.Log("This ispointer down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    
    }

    
}
