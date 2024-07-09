using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public float totalMoney;
    public int levelBuildIndex;
    public float fireRate;
    public float bulletRange;
    public float moneyIncomeMultiplier;

    public float fireRateUpgradeCost;
    public float fireRateUpgradeCostMultiplier;
    public float fireRateUpgradeAmount;
    public float fireRatelvl;


    public float bulletRangeUpgradeCost;
    public float bulletRangeUpgradeCostMultiplier;
    public float bulletRangeUpgradeAmount;
    public float rangeLvl;

    public float moneyIncomeUpgradeCost;
    public float moneyIncomeUpgradeCostMultiplier;
    public float moneyIncomeUpgradeAmount;
    public float incomeLvl;




    public GameData()
    {
        totalMoney = 0;
        levelBuildIndex = 0;
        fireRate = 0.8f;
        bulletRange = 1;
        moneyIncomeMultiplier = 1f;


        fireRateUpgradeCost = 50;
        fireRateUpgradeCostMultiplier = 1.5f;
        fireRateUpgradeAmount = -0.01f;
        fireRatelvl = 1f;

        bulletRangeUpgradeCost = 50;
        bulletRangeUpgradeCostMultiplier = 1.5f;
        bulletRangeUpgradeAmount = 0.05f;
        rangeLvl = 1f;

        moneyIncomeUpgradeCost = 50;
        moneyIncomeUpgradeCostMultiplier = 1.5f;
        moneyIncomeUpgradeAmount = 0.05f;
        incomeLvl = 1f;
    }
}