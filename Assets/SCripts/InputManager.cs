using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    public Card currentCard;
    public float minDistanceToMoveCardToTable;


    private float totalTime;
    private float startTime;
    private float endTime;

    private Vector2 startPos;
    private Vector2 endPos;
    private float totalDistance;
    private float distance;
    private float currentVelocity;

    public void OnDrag(PointerEventData eventData)
    {
        if (currentCard != null)
        {
            currentCard.transform.position = eventData.position;
        }
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.GetComponent<Card>()!=null) 
        {
            currentCard = eventData.pointerCurrentRaycast.gameObject.GetComponent<Card>();
            startTime = Time.time;
            startPos = eventData.position;
            currentCard.transform.position = eventData.position;
            currentCard.SetFakeParent();
        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        if (currentCard != null)
        {
            endTime = Time.time;
            endPos = eventData.position;
            totalDistance = Vector2.Distance(endPos, startPos);
            totalTime = endTime - startTime;

            //speed = distance/time
            currentVelocity = (totalDistance / totalTime)/1000f;

            //if (currentVelocity > minVelocityToMoveCardToTable)
            if (totalDistance > minDistanceToMoveCardToTable)
            {

                currentCard.MoveToTable();
            }
            else
            {
                currentCard.MoveToDeckAgain();
            }


        }


    }

    
}
