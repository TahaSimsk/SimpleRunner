using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fRUpgradeCostButtonText;
    [SerializeField] TextMeshProUGUI rangeUpgradeCostButtonText;
    [SerializeField] TextMeshProUGUI incomeUpgradeCostButtonText;


    [Header("FireRate")]
    public float fireRateUpgradeCost;
    public float fireRateUpgradeCostMultiplier;
    public float fireRateUpgradeAmount;

    [Header("Range")]
    public float bulletRangeUpgradeCost;
    public float bulletRangeUpgradeCostMultiplier;
    public float bulletRangeUpgradeAmount;

    [Header("MoneyIncome")]
    public float moneyIncomeUpgradeCost;
    public float moneyIncomeUpgradeCostMultiplier;
    public float moneyIncomeUpgradeAmount;




    public static Shop Instance;
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
        fireRateUpgradeCost = gameData.fireRateUpgradeCost;
        fireRateUpgradeCostMultiplier = gameData.fireRateUpgradeCostMultiplier;
        fireRateUpgradeAmount = gameData.fireRateUpgradeAmount;

        bulletRangeUpgradeCost = gameData.bulletRangeUpgradeCost;
        bulletRangeUpgradeCostMultiplier = gameData.bulletRangeUpgradeCostMultiplier;
        bulletRangeUpgradeAmount = gameData.bulletRangeUpgradeAmount;

        moneyIncomeUpgradeCost = gameData.moneyIncomeUpgradeCost;
        moneyIncomeUpgradeCostMultiplier = gameData.moneyIncomeUpgradeCostMultiplier;
        moneyIncomeUpgradeAmount = gameData.moneyIncomeUpgradeAmount;
    }


    public void FireRateButton()
    {
        //Upgrade(MoneyManager.Instance.totalMoney, fireRateUpgradeCost, fireRateUpgradeCostMultiplier, Powers.Instance.fireRate, fireRateUpgradeAmount);



        if (MoneyManager.Instance.totalMoney >= fireRateUpgradeCost)
        {
            MoneyManager.Instance.totalMoney -= fireRateUpgradeCost;
            fireRateUpgradeCost *= fireRateUpgradeCostMultiplier;
            Powers.Instance.fireRate += fireRateUpgradeAmount;

            MoneyManager.Instance.UpdateEndLevelMoneyText();
            UpdateFireRateUpgradeCostText();
        }
    }

    public void BulletRangeButton()
    {

        //Upgrade(MoneyManager.Instance.totalMoney, bulletRangeUpgradeCost, bulletRangeUpgradeCostMultiplier, Powers.Instance.bulletRange, bulletRangeUpgradeAmount);
        if (MoneyManager.Instance.totalMoney >= bulletRangeUpgradeCost)
        {
            MoneyManager.Instance.totalMoney -= bulletRangeUpgradeCost;
            bulletRangeUpgradeCost *= bulletRangeUpgradeCostMultiplier;
            Powers.Instance.bulletRange += bulletRangeUpgradeAmount;

            MoneyManager.Instance.UpdateEndLevelMoneyText();
            UpdateRangeUpgradeCostText();
        }
    }


    public void MoneyIncomeButton()
    {
        //Upgrade(MoneyManager.Instance.totalMoney, moneyIncomeUpgradeCost, moneyIncomeUpgradeCostMultiplier, Powers.Instance.moneyIncomeMultiplier, moneyIncomeUpgradeAmount);

        if (MoneyManager.Instance.totalMoney >= moneyIncomeUpgradeCost)
        {
            MoneyManager.Instance.totalMoney -= moneyIncomeUpgradeCost;
            moneyIncomeUpgradeCost *= moneyIncomeUpgradeCostMultiplier;
            Powers.Instance.moneyIncomeMultiplier += moneyIncomeUpgradeAmount;

            MoneyManager.Instance.UpdateEndLevelMoneyText();
            UpdateIncomeUpgradeCostText();
        }

    }


    public void UpdateFireRateUpgradeCostText()
    {
        fRUpgradeCostButtonText.text = "$" + fireRateUpgradeCost;
    }

    public void UpdateRangeUpgradeCostText()
    {
        rangeUpgradeCostButtonText.text = "$" + bulletRangeUpgradeCost;
    }

    public void UpdateIncomeUpgradeCostText()
    {
        incomeUpgradeCostButtonText.text = "$" + moneyIncomeUpgradeCost;
    }
}
