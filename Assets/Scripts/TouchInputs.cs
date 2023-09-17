using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputs : MonoBehaviour
{

    public float horizontalValue;
    public bool moveByMouse = false;
    public bool moveByTouch = true;


    private void Start()
    {
        moveByTouch = true;
    }

    void Update()
    {

        if (moveByMouse)
        {
            if (Input.GetMouseButton(0))
            {
                horizontalValue = Input.GetAxis("Mouse X");

            }
            else
            {
                horizontalValue = 0;
            }
        }


        if (moveByTouch)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {

                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    horizontalValue = Input.GetTouch(0).deltaPosition.x;

                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    horizontalValue = 0;
                }
            }
        }

    }




    //UI ELEMENTS


    //public void MoveByMouse()
    //{
    //    moveByMouse = true;
    //}
    //public void DisableMouse()
    //{
    //    moveByMouse = false;
    //}

    //public void MoveByTouch() 
    //{ 
    //    moveByTouch = true;
    //}
    //public void DisableTouch()
    //{
    //    moveByTouch = false;
    //}
}
