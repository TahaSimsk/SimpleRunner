using RDG;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Vibration.Vibrate(10, 50);

        Destroy(gameObject,0.01f);
    }

}
