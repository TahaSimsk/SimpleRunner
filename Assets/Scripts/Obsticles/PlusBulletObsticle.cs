using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlusBulletObsticle : MonoBehaviour
{
    [SerializeField] float bulletsHitDivider;
    [SerializeField] TMP_Text bulletCountText;
    [SerializeField] Animator animator;

    float bulletsHit;
    float bulletCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            animator.SetTrigger("BulletHit");
            bulletsHit++;
            if (bulletsHit / bulletsHitDivider >= 1)
            {

                bulletCount++;
                bulletCountText.text = bulletCount.ToString();

                bulletsHit = 0;
            }
        }

        PlayerShooting playerShooting = other.gameObject.GetComponent<PlayerShooting>();
        if (playerShooting != null)
        {
            playerShooting.GetBulletCount(bulletCount);
            Destroy(gameObject);
        }

    }


}
