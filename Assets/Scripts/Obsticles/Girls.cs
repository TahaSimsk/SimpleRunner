using RDG;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Girls : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] GameObject moneyPrefab;
    [SerializeField] Animator animator;
    [SerializeField] TMP_Text healthText;

    bool hasDropped = false;


    void Start()
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
            Vibration.Vibrate(10, 50);
            if (maxHealth <= 0 && !hasDropped)
            {
                hasDropped = true;
                Destroy(gameObject);
                Vector3 pos = transform.position;
                pos.y = 0.2f;
                Instantiate(moneyPrefab, pos, Quaternion.identity);
            }
        }

        if (other.CompareTag("Player"))
        {
            LevelManager.Instance.TriggerEndOfLevel();
            
        }
    }
}
