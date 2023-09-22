using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateObsticle : MonoBehaviour
{
    [SerializeField] bool increaseFireRate;
    [SerializeField] bool decreaseFireRate;
    [SerializeField] float fireRateMultiplier;
    [SerializeField] float fireRate;
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
            if (increaseFireRate)
            {
                fireRate += fireRateMultiplier;
            }
            if (decreaseFireRate)
            {
                fireRate -= fireRateMultiplier;
            }
        }

        PlayerShooting playerShooting = other.GetComponent<PlayerShooting>();
        if (playerShooting != null)
        {
            playerShooting.GetFireRate(fireRate);
            meshRenderer.enabled = false;
            visuals.gameObject.SetActive(false);
        }

    }



}
