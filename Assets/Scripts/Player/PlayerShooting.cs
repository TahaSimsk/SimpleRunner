using RDG;
using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] Animator animator;

    [SerializeField] float bulletForwardSpeed;
    [SerializeField] float bulletCount;

    PlayerShooting originalPlayer;

    bool IsClone;

    float bulletRotation;
    float fireRate;
    float bulletRange;


    private void Start()
    {
        if (!IsClone)
        {
            fireRate = SaveManager.Instance.gameData.fireRate;
            bulletRange = SaveManager.Instance.gameData.bulletRange;
            originalPlayer = this;
        }


        StartCoroutine(Shoot());
    }

    public void SetOriginalPlayer(PlayerShooting _originalPlayer)
    {
        IsClone = true;
        originalPlayer = _originalPlayer;
    }


    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(originalPlayer.fireRate);
            Vibration.Vibrate(1, 50);
            FireBullets();
        }
    }



    public void SetFireRate(float _amount)
    {

        originalPlayer.fireRate -= _amount / 1000;

        originalPlayer.fireRate = Mathf.Clamp(originalPlayer.fireRate, 0.1f, 2);
    }

    public void SetRange(float _amount)
    {
        originalPlayer.bulletRange += _amount / 100;

        originalPlayer.bulletRange = Mathf.Clamp(originalPlayer.bulletRange, 0.2f, 2);
    }

    public void SetBulletCount(float _amount)
    {
        bulletCount += _amount;
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
            Destroy(bulletInstance, originalPlayer.bulletRange);

            animator.SetTrigger("Fire");
        }


    }

}
