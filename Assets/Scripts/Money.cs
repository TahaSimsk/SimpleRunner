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


    public const string MoneyAmountKey = "MoneyAmountKey";

    void Start()
    {
        moneyAmount = PlayerPrefs.GetFloat(MoneyAmountKey, 100);
        moneyText.text ="$" + moneyAmount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {

            moneyAmount += moneyMultiplier * (SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetFloat(MoneyAmountKey, moneyAmount);
            moneyText.text ="$" + moneyAmount.ToString();
            Destroy(other.gameObject);
        }

    }



}
