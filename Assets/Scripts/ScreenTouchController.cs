using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ScreenTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler 
{

    public Vector2 touchPos;
    public Vector2 direction;
    public bool isDragging;
    



    public void OnDrag(PointerEventData eventData)
    {

        
        isDragging = true;
        direction = eventData.position - touchPos;
        direction.Normalize();
        direction.y = 0;

        touchPos = eventData.position;
        
       

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = false;
        touchPos = eventData.position;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        direction = Vector2.zero;

    }

  


    private Vector3 previousPointerPosition;

    void Update()
    {
       
        Vector3 currentPointerPosition = GetPointerPosition();

        
        if (currentPointerPosition == previousPointerPosition && isDragging)
        {
            direction = Vector3.zero;
            
            Debug.Log("Pointer has stopped moving");
        }

        
        previousPointerPosition = currentPointerPosition;
    }

    
    Vector3 GetPointerPosition()
    {
       
        return Touchscreen.current.primaryTouch.position.ReadValue();
    }


}