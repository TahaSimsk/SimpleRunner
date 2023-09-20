using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girls : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] GameObject moneyPrefab;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            maxHealth--;
            if (maxHealth <= 0)
            {
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
