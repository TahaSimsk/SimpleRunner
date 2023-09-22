using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRangeObsticle : MonoBehaviour
{
    [SerializeField] bool increaseRange;
    [SerializeField] bool decreaseRange;
    [SerializeField] float rangeMultiplier;
    [SerializeField] float bulletRange;

    [SerializeField] GameObject visuals;

    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (increaseRange)
            {
                bulletRange += rangeMultiplier;
            }
            if (decreaseRange)
            {
                bulletRange -= rangeMultiplier;
            }
        }

        PlayerShooting playerShooting= other.GetComponent<PlayerShooting>();

        if (playerShooting != null)
        {
            playerShooting.GetRange(bulletRange);
            meshRenderer.enabled=false;
            visuals.gameObject.SetActive(false);
        }

    }
}
