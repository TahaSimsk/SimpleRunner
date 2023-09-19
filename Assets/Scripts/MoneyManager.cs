using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;

    public static MoneyManager Instance;
    public GameData gameData;

    public float totalMoney;

    private void Awake()
    {
        gameData = SaveSystem.Load();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        totalMoney = gameData.totalMoney;
    }


    public void GetMoney(float money)
    {
        totalMoney = money;

        gameData.totalMoney = totalMoney;

        SaveSystem.Save(gameData);

        moneyText.text= "$" + totalMoney.ToString();
    }
}
