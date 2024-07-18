using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] bool oscillate;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period;
    float movementFactor;


    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }


    void Update()
    {
        if (!oscillate || period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2;

        Vector3 offset = movementVector * movementFactor;

        transform.position = startingPos + offset;


    }
}
