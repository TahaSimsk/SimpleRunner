using UnityEngine;
using UnityEngine.SceneManagement;
using TouchPhase = UnityEngine.TouchPhase;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardMoveSpeed;
    [SerializeField] float horizontalMoveSpeed;
    [SerializeField] float bounceForce;
    [SerializeField] float stopBounceTimer;

    [SerializeField] float roadLenght;

    public bool isClone;
    public float cloneAmount;

    bool shouldBounce = false;
    float horizontalValue;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (isClone)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -roadLenght, roadLenght), transform.position.y, transform.position.z);
            return;
        }
        MoveForward();
        MoveHorizontal();

    }


    void MoveForward()
    {
        if (!shouldBounce)
        {
            transform.Translate(new Vector3(0, 0, forwardMoveSpeed * Time.deltaTime));
        }
    }

    void MoveHorizontal()
    {

        //float newPositionX = transform.position.x + touchInputs.horizontalValue / 7f;
        //transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !LevelManager.Instance.isDead)
        {
            horizontalValue = Input.GetTouch(0).deltaPosition.x / Screen.width * horizontalMoveSpeed;
            float newPositionX = transform.position.x + horizontalValue;
            newPositionX = Mathf.Clamp(newPositionX, -roadLenght + cloneAmount, roadLenght - cloneAmount);
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
            //rb.AddForce(new Vector3(horizontalValue, 0, 0), ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obsticle"))
        {
            rb.AddForce(Vector3.back * bounceForce);
            shouldBounce = true;
            Invoke("StopBouncing", stopBounceTimer);
        }
    }

    void StopBouncing()
    {
        shouldBounce = false;
    }


}