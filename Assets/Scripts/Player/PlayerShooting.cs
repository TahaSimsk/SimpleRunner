using RDG;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;

    [SerializeField] Animator animator;

    [SerializeField] float fireRate;
    [SerializeField] float bulletForwardSpeed;
    [SerializeField] float bulletRange;


    [SerializeField] float bulletCount;

    float bulletRotation;

    private void Start()
    {
        fireRate = Powers.Instance.fireRate;
        bulletRange = Powers.Instance.bulletRange;

        StartCoroutine(Shoot());
    }


    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            Vibration.Vibrate(1, 50);
            FireBullets();
        }
    }



    public void GetFireRate(float passFireRate)
    {

        fireRate -= passFireRate / 1000;

        fireRate = Mathf.Clamp(fireRate, 0.1f, 2);
    }

    public void GetRange(float passRange)
    {
        bulletRange += passRange / 100;

        bulletRange = Mathf.Clamp(bulletRange, 0.2f, 2);
    }

    public void GetBulletCount(float passBulletCount)
    {
        bulletCount += passBulletCount;
    }



    void FireBullets()
    {
        bulletRotation = 0;
        for (int i = 0; i < bulletCount; i++)
        {

            if (i % 2 == 0)
            {

                bulletRotation = -bulletRotation;
            }
            else
            {
                bulletRotation = -bulletRotation + 1.5f;
            }


            GameObject bulletInstance = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.Euler(0, bulletRotation, 0));
            
            bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletForwardSpeed);
            bulletInstance.transform.rotation = Quaternion.Euler(0, 90, 0);
            Destroy(bulletInstance, bulletRange);

            animator.SetTrigger("Fire");
        }


    }

}
