using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour
{
    [SerializeField] float moneyMultiplier;
    [SerializeField] float moneyAmount;
    [SerializeField] TextMeshProUGUI moneyText;


    void Start()
    {
        moneyAmount = LevelManager.Instance.totalMoney;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            moneyAmount += moneyMultiplier * (SceneManager.GetActiveScene().buildIndex + 1);
            LevelManager.Instance.GetMoney(moneyAmount);

            Destroy(other.gameObject);
        }

    }



}
