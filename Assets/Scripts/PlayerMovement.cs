using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardMoveSpeed;
    [SerializeField] float sidewaysForce;
    [SerializeField] ScreenTouchController screenTouchController;
    Camera mainCam;



    Rigidbody rb;
    Vector3 touchViewportPos;
    float direction;
    Vector2 startTouchPosition;
    Vector2 horizontalDirection;
    float delta;
    bool moved;

    //Vector2 touchPos;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
    }


    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private bool isDragging = false;
    Vector2 screenPos;

    public float movementSpeed = 5.0f;

    void Update()
    {

        MoveForward();

        //if (screenTouchController.isDragging)
        //{
        //    if (screenTouchController.isDragging)
        //    {
        //        transform.Translate(screenTouchController.direction * sidewaysForce * Time.deltaTime);
        //    }
            
        //}
        

        screenPos = mainCam.WorldToScreenPoint(transform.position);

        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    switch (touch.phase)
        //    {
        //        case TouchPhase.Began:
        //            // Record the starting touch position
        //            touchStartPos = mainCam.ScreenToViewportPoint(touch.position);
        //            isDragging = true;
        //            moved = false;
        //            break;

        //        case TouchPhase.Moved:
        //            // Calculate the horizontal distance moved
        //            Vector2 worldPos = mainCam.ScreenToViewportPoint(touch.position);
        //            delta = worldPos.x - touchStartPos.x;
        //            //horizontalDirection = delta.normalized;
        //            moved = true;
        //            // Move the player character

        //            Vector3 force = new Vector3(delta * sidewaysForce * Time.deltaTime, 0, 0);
        //            rb.AddForce(force);
        //            //Vector3 newPosition = transform.position + new Vector3(horizontalDelta * movementSpeed * Time.deltaTime, 0, 0);
        //            //transform.position = newPosition;

        //            // Update the touch start position for the next frame
        //            touchStartPos = mainCam.ScreenToViewportPoint(touch.position);
        //            break;

        //        case TouchPhase.Ended:
        //        case TouchPhase.Canceled:
        //            horizontalDirection = Vector2.zero;
        //            isDragging = false;
        //            moved = false;
        //            break;
        //    }
        //}
    }


    //void Update()
    //{

    //    //GetTouchInput();


    //    if ()
    //    {

    //    }



    //    transform.position += new Vector3(screenTouchController.direction.x * Time.deltaTime * sidewaysForce, 0, 0);
    //}

    void FixedUpdate()
    {
        //if (screenPos== screenTouchController.touchPos)
        //{
        //    return;
        //}
        rb.AddForce(screenTouchController.direction * sidewaysForce, ForceMode.Impulse);



        //MoveSideways();
    }

    void MoveForward()
    {

        transform.position += new Vector3(0, 0, forwardMoveSpeed * Time.deltaTime);
    }

    void MoveSideways()
    {








        Vector3 force = new Vector3(sidewaysForce * direction, 0, 0);
        rb.AddForce(force, ForceMode.Force);
    }

    //void GetTouchInput()
    //{

    //    //if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
    //    //{
    //    //    startTouchPosition = Input.GetTouch(0).position;

    //    //}

    //    if (Touchscreen.current.primaryTouch.press.isPressed)
    //    {

    //        Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();

    //        var worldPos = mainCam.ScreenToWorldPoint(touchPos);
    //        Debug.Log($"WorldPos: {worldPos}");
    //        Debug.Log($"Transform: {transform.position}");

    //        //TouchPhase phase = Touchscreen.current.primaryTouch.phase.ReadValue();



    //        //if (phase == TouchPhase.Began)
    //        //{
    //        //    Debug.Log("Began");
    //        //}

    //        //if (phase == TouchPhase.Moved)
    //        //{
    //        //    Debug.Log("Moved");
    //        //}
    //        //if (phase == TouchPhase.Ended)
    //        //{
    //        //    Debug.Log("Ended");
    //        //}






    //        //Vector3 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();

    //        //touchViewportPos = mainCam.ScreenToViewportPoint(touchPos);
    //        ////Debug.Log($"TouchPos: {touchPos}");
    //        //Debug.Log($"TouchWorldPos: {touchViewportPos}");
    //        //Debug.Log($"Velocity: {rb.velocity}");
    //        //if (touchViewportPos.x < 0.5f)
    //        //{
    //        //    direction = -1;
    //        //}
    //        //if (touchViewportPos.x >= 0.5f)
    //        //{
    //        //    direction = 1;
    //        //}
    //        ////direction = touchViewportPos - transform.position;



    //        ////direction.Normalize();
    //    }
    //    else
    //    {
    //        direction = 0;
    //    }
    //}


    //public void OnDrag(PointerEventData eventData)
    //{
    //    var anan = eventData.radius;
    //    Debug.Log("Dragging " + anan);
    //}

    //public void Click(PointerEventData eventData)
    //{
    //    var anan = eventData.position;
    //    Debug.Log("Clicking " + anan);
    //}

    //public void Up()
    //{
    //    Debug.Log("Up");
    //}





}
