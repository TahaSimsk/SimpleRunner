using UnityEngine;
using TouchPhase = UnityEngine.TouchPhase;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardMoveSpeed;
    [SerializeField] float horizontalMoveSpeed;
    [SerializeField] float bounceForce;
    [SerializeField] float stopBounceTimer;

    [SerializeField] float roadLenght;

    bool shouldBounce = false;
    float horizontalValue;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        MoveForward();
        MoveHorizontal();

    }


    void MoveForward()
    {
        if (!shouldBounce)
        {
            transform.Translate(new Vector3(0, 0, forwardMoveSpeed * Time.deltaTime));
        }
        else
        {
            transform.Translate(new Vector3(0, 0, -forwardMoveSpeed * Time.deltaTime));
        }
    }

    void MoveHorizontal()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !LevelManager.Instance.isDead)
        {
            horizontalValue = Input.GetTouch(0).deltaPosition.x / Screen.width * horizontalMoveSpeed;
            float newPositionX = transform.position.x + horizontalValue;
            newPositionX = Mathf.Clamp(newPositionX, -roadLenght, roadLenght);
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            shouldBounce = true;
            Invoke(nameof(StopBouncing), stopBounceTimer);
        }
    }

    void StopBouncing()
    {
        shouldBounce = false;
    }
}