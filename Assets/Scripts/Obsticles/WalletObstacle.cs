using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletObstacle : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] TMP_Text healthText;
    [SerializeField] GameObject wallet;
    [SerializeField] Transform walletSpawnPoint;
    [SerializeField] Animator animator;

    bool hasDied;

    private void Start()
    {
        healthText.text = maxHealth.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            animator.SetTrigger("BulletHit");
            maxHealth--;
            healthText.text = maxHealth.ToString();
            if (maxHealth <= 0 && !hasDied)
            {
                hasDied = true;
                Instantiate(wallet, walletSpawnPoint.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
