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
    [SerializeField] Transform fifthBulletSpawnPoint;
    [SerializeField] Transform sixthBulletSpawnPoint;
    [SerializeField] float fireRate;
    [SerializeField] float bulletForwardSpeed;
    [SerializeField] float bulletRange;


    [SerializeField] float bulletCount;



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
            FireBullets();
            Debug.Log(fireRate);
            Debug.Log(bulletRange);

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


    #region FireBulletsIntances
    void FireBullets()
    {
        GameObject firstbulletInstance = Instantiate(bullet, firstBulletSpawnPoint.position, Quaternion.Euler(0, -90, 0));
        firstbulletInstance.gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletForwardSpeed;
        Destroy(firstbulletInstance.gameObject, bulletRange);

        if (bulletCount >= 2)
        {
            GameObject secondBulletInstance = Instantiate(bullet, secondBulletSpawnPoint.position, Quaternion.Euler(0, -90, 0));
            secondBulletInstance.gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletForwardSpeed;
            Destroy(secondBulletInstance.gameObject, bulletRange);
        }
        if (bulletCount >= 3)
        {
            GameObject thirdBulletInstance = Instantiate(bullet, thirdBulletSpawnPoint.position, Quaternion.Euler(0, -90, 0));
            thirdBulletInstance.gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletForwardSpeed;
            Destroy(thirdBulletInstance.gameObject, bulletRange);
        }
        if (bulletCount >= 4)
        {
            GameObject fourthBulletInstance = Instantiate(bullet, fourthBulletSpawnPoint.position, Quaternion.Euler(0, -90, 0));
            fourthBulletInstance.gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletForwardSpeed;
            Destroy(fourthBulletInstance.gameObject, bulletRange);
        }
        if (bulletCount >= 5)
        {
            GameObject fifthBulletInstance = Instantiate(bullet, fifthBulletSpawnPoint.position, Quaternion.Euler(0, -90, 0));
            fifthBulletInstance.gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletForwardSpeed;
            Destroy(fifthBulletInstance.gameObject, bulletRange);
        }
        if (bulletCount >= 6)
        {
            GameObject sixthBulletInstance = Instantiate(bullet, sixthBulletSpawnPoint.position, Quaternion.Euler(0,-90,0));
            sixthBulletInstance.gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletForwardSpeed;
            Destroy(sixthBulletInstance.gameObject, bulletRange);
        }



    }
    #endregion

}
