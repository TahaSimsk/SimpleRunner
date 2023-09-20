using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public GameData gameData;

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

    }




    public void SaveGame()
    {
        SaveLevel();
        SaveShop();
        SavePowers();
        SaveMoney();

        SaveSystem.Save(gameData);
    }



    void SaveShop()
    {
        gameData.fireRateUpgradeCost = Shop.Instance.fireRateUpgradeCost;
        gameData.fireRateUpgradeCostMultiplier = Shop.Instance.fireRateUpgradeCostMultiplier;
        gameData.fireRateUpgradeAmount = Shop.Instance.fireRateUpgradeAmount;

        gameData.bulletRangeUpgradeCost = Shop.Instance.bulletRangeUpgradeCost;
        gameData.bulletRangeUpgradeCostMultiplier = Shop.Instance.bulletRangeUpgradeCostMultiplier;
        gameData.bulletRangeUpgradeAmount = Shop.Instance.bulletRangeUpgradeAmount;

        gameData.moneyIncomeUpgradeCost = Shop.Instance.moneyIncomeUpgradeCost;
        gameData.moneyIncomeUpgradeCostMultiplier = Shop.Instance.moneyIncomeUpgradeCostMultiplier;
        gameData.moneyIncomeUpgradeAmount = Shop.Instance.moneyIncomeUpgradeAmount;
    }

    void SavePowers()
    {
        gameData.fireRate = Powers.Instance.fireRate;
        gameData.bulletRange = Powers.Instance.bulletRange;
        gameData.moneyIncomeMultiplier = Powers.Instance.moneyIncomeMultiplier;
    }


    void SaveMoney()
    {
        gameData.totalMoney = MoneyManager.Instance.totalMoney;
    }

    void SaveLevel()
    {
        gameData.levelBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }
}
