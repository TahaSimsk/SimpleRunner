using RDG;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fRUpgradeCostButtonText;
    [SerializeField] TextMeshProUGUI fRButtonLevelText;

    [SerializeField] TextMeshProUGUI rangeUpgradeCostButtonText;
    [SerializeField] TextMeshProUGUI rangeButtonLevelText;

    [SerializeField] TextMeshProUGUI incomeUpgradeCostButtonText;
    [SerializeField] TextMeshProUGUI incomeButtonLevelText;




    [Header("FireRate")]
    public float fireRateUpgradeCost;
    public float fireRateUpgradeCostMultiplier;
    public float fireRateUpgradeAmount;
    public float fireRateLvl;

    [Header("Range")]
    public float bulletRangeUpgradeCost;
    public float bulletRangeUpgradeCostMultiplier;
    public float bulletRangeUpgradeAmount;
    public float rangeLvl;

    [Header("MoneyIncome")]
    public float moneyIncomeUpgradeCost;
    public float moneyIncomeUpgradeCostMultiplier;
    public float moneyIncomeUpgradeAmount;
    public float incomeLvl;





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
        fireRateLvl = gameData.fireRatelvl;

        bulletRangeUpgradeCost = gameData.bulletRangeUpgradeCost;
        bulletRangeUpgradeCostMultiplier = gameData.bulletRangeUpgradeCostMultiplier;
        bulletRangeUpgradeAmount = gameData.bulletRangeUpgradeAmount;
        rangeLvl = gameData.rangeLvl;

        moneyIncomeUpgradeCost = gameData.moneyIncomeUpgradeCost;
        moneyIncomeUpgradeCostMultiplier = gameData.moneyIncomeUpgradeCostMultiplier;
        moneyIncomeUpgradeAmount = gameData.moneyIncomeUpgradeAmount;
        incomeLvl = gameData.incomeLvl;


    }


    public void FireRateButton()
    {
        if (MoneyManager.Instance.totalMoney >= fireRateUpgradeCost)
        {
            MoneyManager.Instance.totalMoney -= fireRateUpgradeCost;
            fireRateUpgradeCost *= fireRateUpgradeCostMultiplier;
            Powers.Instance.fireRate += fireRateUpgradeAmount;
            fireRateLvl++;

            MoneyManager.Instance.UpdateEndLevelMoneyText();
            UpdateFireRateUpgradeCostAndLvlText();
            Vibration.Vibrate(50, 50);
        }
    }

    public void BulletRangeButton()
    {
        if (MoneyManager.Instance.totalMoney >= bulletRangeUpgradeCost)
        {
            MoneyManager.Instance.totalMoney -= bulletRangeUpgradeCost;
            bulletRangeUpgradeCost *= bulletRangeUpgradeCostMultiplier;
            Powers.Instance.bulletRange += bulletRangeUpgradeAmount;
            rangeLvl++;

            MoneyManager.Instance.UpdateEndLevelMoneyText();
            UpdateRangeUpgradeCostAndLvlText();
            Vibration.Vibrate(50, 50);
        }
    }


    public void MoneyIncomeButton()
    {
        if (MoneyManager.Instance.totalMoney >= moneyIncomeUpgradeCost)
        {
            MoneyManager.Instance.totalMoney -= moneyIncomeUpgradeCost;
            moneyIncomeUpgradeCost *= moneyIncomeUpgradeCostMultiplier;
            Powers.Instance.moneyIncomeMultiplier += moneyIncomeUpgradeAmount;
            incomeLvl++;

            MoneyManager.Instance.UpdateEndLevelMoneyText();
            UpdateIncomeUpgradeCostAndLvlText();
            Vibration.Vibrate(50, 50);
        }

    }




    public void UpdateFireRateUpgradeCostAndLvlText()
    {
        fRUpgradeCostButtonText.text = "$" + Mathf.FloorToInt(fireRateUpgradeCost);
        fRButtonLevelText.text = "Level " + fireRateLvl;
    }

    public void UpdateRangeUpgradeCostAndLvlText()
    {
        rangeUpgradeCostButtonText.text = "$" + Mathf.FloorToInt(bulletRangeUpgradeCost);
        rangeButtonLevelText.text = "Level " + rangeLvl;
    }

    public void UpdateIncomeUpgradeCostAndLvlText()
    {
        incomeUpgradeCostButtonText.text = "$" + Mathf.FloorToInt(moneyIncomeUpgradeCost);
        incomeButtonLevelText.text = "Level " + incomeLvl;
    }
}
