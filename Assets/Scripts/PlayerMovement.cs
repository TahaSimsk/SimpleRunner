using UnityEngine;
using UnityEngine.SceneManagement;
using TouchPhase = UnityEngine.TouchPhase;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardMoveSpeed;
    [SerializeField] TouchInputs touchInputs;

    float horizontalValue;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {
        MoveForward();
        HorizontalSpeed();
    }


    void MoveForward()
    {
        transform.position += new Vector3(0, 0, forwardMoveSpeed * Time.deltaTime);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    void HorizontalSpeed()
    {


        //float newPositionX = transform.position.x + touchInputs.horizontalValue / 7f;
        //transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);




        if (touchInputs.moveByTouch)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                horizontalValue = Input.GetTouch(0).deltaPosition.x;
                float newPositionX = transform.position.x + touchInputs.horizontalValue / 100f;
                newPositionX = Mathf.Clamp(newPositionX, -4, 4);
                transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

            }
        }


    }

}