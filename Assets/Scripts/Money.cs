using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour
{
    [SerializeField] float baseMoneyMultiplier;
    [SerializeField] TextMeshProUGUI moneyText;


    void Start()
    {
        MoneyManager.Instance.UpdateInGameMoneyText();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            MoneyManager.Instance.totalMoney += (baseMoneyMultiplier + SceneManager.GetActiveScene().buildIndex * 2) * Powers.Instance.moneyIncomeMultiplier;

            MoneyManager.Instance.UpdateInGameMoneyText();

            Destroy(other.gameObject);
        }

    }



}
