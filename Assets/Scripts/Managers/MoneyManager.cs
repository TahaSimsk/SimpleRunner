using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inGameMoneyText;
    [SerializeField] TextMeshProUGUI endLevelMoneyText;

    public static MoneyManager Instance;
    public GameData gameData;

    public float totalMoney;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        gameData = SaveSystem.Load();

        totalMoney = gameData.totalMoney;

    }


    public void UpdateInGameMoneyText()
    {
        inGameMoneyText.text = "$" + totalMoney;
    }

    public void UpdateEndLevelMoneyText()
    {
        endLevelMoneyText.text = "$" + totalMoney;
    }
}
