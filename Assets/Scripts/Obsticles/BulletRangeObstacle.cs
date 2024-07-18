using RDG;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletRangeObstacle : MonoBehaviour
{
    [SerializeField] bool increaseRange;
    [SerializeField] bool decreaseRange;
    [SerializeField] float rangeMultiplier;
    [SerializeField] float bulletRange;

    [SerializeField] GameObject visuals;

    [SerializeField] TMP_Text baseRangeText;
    [SerializeField] TMP_Text rangeMultiplierText;

    [SerializeField] Animator animator;


    private void Start()
    {

        baseRangeText.text = bulletRange.ToString();

        if (increaseRange)
        {
            rangeMultiplierText.text = "+" + rangeMultiplier.ToString();
        }
        if (decreaseRange)
        {
            rangeMultiplierText.text = "-" + rangeMultiplier.ToString();
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            animator.SetTrigger("BulletHit");
            if (increaseRange)
            {
                bulletRange += rangeMultiplier;
            }
            if (decreaseRange)
            {
                bulletRange -= rangeMultiplier;
            }

            baseRangeText.text = bulletRange.ToString();
        }

        PlayerShooting playerShooting = other.GetComponent<PlayerShooting>();

        if (playerShooting != null)
        {
            playerShooting.SetRange(bulletRange);

            visuals.SetActive(false);
        }

    }
}
