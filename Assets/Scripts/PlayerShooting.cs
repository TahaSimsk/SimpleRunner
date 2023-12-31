using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firstBulletSpawnPoint;
    [SerializeField] Transform secondBulletSpawnPoint;
    [SerializeField] Transform thirdBulletSpawnPoint;
    [SerializeField] Transform fourthBulletSpawnPoint;
    [SerializeField] float fireRate;
    [SerializeField] float bulletForwardSpeed;
    [SerializeField] float bulletRange;


    [SerializeField] float bulletCount;

    private void Start()
    {
        StartCoroutine(Shoot());

    }


    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            FireBullets();

        }

    }



    public void GetFireRate(float passFireRate)
    {

        fireRate -= passFireRate / 1000;
    }

    public void GetRange(float passRange)
    {
        bulletRange += passRange / 100;
    }

    public void GetBulletCount(float passBulletCount)
    {
        bulletCount += passBulletCount;
    }



    void FireBullets()
    {
        GameObject firstbulletInstance = Instantiate(bullet, firstBulletSpawnPoint.position, Quaternion.identity);
        firstbulletInstance.gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletForwardSpeed;
        Destroy(firstbulletInstance.gameObject, bulletRange);

        if (bulletCount >= 2)
        {
            GameObject secondBulletInstance = Instantiate(bullet, secondBulletSpawnPoint.position, Quaternion.identity);
            secondBulletInstance.gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletForwardSpeed;
            Destroy(secondBulletInstance.gameObject, bulletRange);
        }
        if (bulletCount >= 3)
        {
            GameObject thirdBulletInstance = Instantiate(bullet, thirdBulletSpawnPoint.position, Quaternion.identity);
            thirdBulletInstance.gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletForwardSpeed;
            Destroy(thirdBulletInstance.gameObject, bulletRange);
        }
        if (bulletCount >= 4)
        {
            GameObject fourthBulletInstance = Instantiate(bullet, fourthBulletSpawnPoint.position, Quaternion.identity);
            fourthBulletInstance.gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletForwardSpeed;
            Destroy(fourthBulletInstance.gameObject, bulletRange);
        }


    }


}
