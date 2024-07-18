using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] float conveyorSpeed;
    [SerializeField] bool rightSide;
    [SerializeField] bool leftSide;
    [SerializeField] bool forwardSide;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wallet"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.useGravity = false;

            if (rightSide)
            {
                other.transform.Translate(Vector3.right * conveyorSpeed * Time.deltaTime);
            }
            if (leftSide)
            {
                other.transform.Translate(Vector3.left * conveyorSpeed * Time.deltaTime);
            }
            if (forwardSide)
            {
                other.transform.Translate(Vector3.forward * conveyorSpeed * Time.deltaTime);
            }


        }
    }
}
