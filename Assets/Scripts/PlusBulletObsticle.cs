using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusBulletObsticle : MonoBehaviour
{
    [SerializeField] float bulletsHitDivider;

    float bulletsHit;
    float bulletCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            bulletsHit++;
            if (bulletsHit / bulletsHitDivider >= 1)
            {
                bulletCount++;
                bulletsHit = 0;
                Debug.Log(bulletCount);
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
