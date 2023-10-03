using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireRateObsticle : MonoBehaviour
{
    [SerializeField] bool increaseFireRate;
    [SerializeField] bool decreaseFireRate;
    [SerializeField] float fireRateMultiplier;
    [SerializeField] float fireRate;
    [SerializeField] GameObject visuals;
    [SerializeField] TMP_Text baseFireRateText;
    [SerializeField] TMP_Text fireRateMultiplierText;
    [SerializeField] Animator animator;


    private void Start()
    {

        baseFireRateText.text = fireRate.ToString();

        if (increaseFireRate)
        {
            fireRateMultiplierText.text = "+" + fireRateMultiplier.ToString();
        }

        if (decreaseFireRate)
        {
            fireRateMultiplierText.text = "-" + fireRateMultiplier.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("BulletHit");
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

            baseFireRateText.text = fireRate.ToString();

        }

        PlayerShooting playerShooting = other.GetComponent<PlayerShooting>();
        if (playerShooting != null)
        {
            playerShooting.GetFireRate(fireRate);

            visuals.SetActive(false);
        }

    }



}
