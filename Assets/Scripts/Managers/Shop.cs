using RDG;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fRUpgradeCostButtonText;
    [SerializeField] TextMeshProUGUI fRButtonLevelText;

    [SerializeField] TextMeshProUGUI rangeUpgradeCostButtonText;
    [SerializeField] TextMeshProUGUI rangeButtonLevelText;

    [SerializeField] TextMeshProUGUI incomeUpgradeCostButtonText;
    [SerializeField] TextMeshProUGUI incomeButtonLevelText;



    public static Shop Instance;

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

    }


    public void FireRateButton()
    {
        if (MoneyManager.Instance.IsAffordable(SaveManager.Instance.gameData.fireRateUpgradeCost))
        {
            MoneyManager.Instance.DecreaseMoney(SaveManager.Instance.gameData.fireRateUpgradeCost);

            SaveManager.Instance.gameData.fireRateUpgradeCost *= SaveManager.Instance.gameData.fireRateUpgradeCostMultiplier;
            SaveManager.Instance.gameData.fireRate += SaveManager.Instance.gameData.fireRateUpgradeAmount;
            SaveManager.Instance.gameData.fireRatelvl++;

            UpdateFireRateUpgradeCostAndLvlText();
            Vibration.Vibrate(50, 50);
        }
    }

    public void BulletRangeButton()
    {
        if (MoneyManager.Instance.IsAffordable(SaveManager.Instance.gameData.bulletRangeUpgradeCost))
        {
            MoneyManager.Instance.DecreaseMoney(SaveManager.Instance.gameData.bulletRangeUpgradeCost);

            SaveManager.Instance.gameData.bulletRangeUpgradeCost *= SaveManager.Instance.gameData.bulletRangeUpgradeCostMultiplier;
            SaveManager.Instance.gameData.bulletRange += SaveManager.Instance.gameData.bulletRangeUpgradeAmount;
            SaveManager.Instance.gameData.rangeLvl++;

            UpdateRangeUpgradeCostAndLvlText();
            Vibration.Vibrate(50, 50);
        }
    }


    public void MoneyIncomeButton()
    {
        if (MoneyManager.Instance.IsAffordable(SaveManager.Instance.gameData.moneyIncomeUpgradeCost))
        {
            MoneyManager.Instance.DecreaseMoney(SaveManager.Instance.gameData.moneyIncomeUpgradeCost);

            SaveManager.Instance.gameData.moneyIncomeUpgradeCost *= SaveManager.Instance.gameData.moneyIncomeUpgradeCostMultiplier;
            SaveManager.Instance.gameData.moneyIncomeMultiplier += SaveManager.Instance.gameData.moneyIncomeUpgradeAmount;
            SaveManager.Instance.gameData.incomeLvl++;

            UpdateIncomeUpgradeCostAndLvlText();
            Vibration.Vibrate(50, 50);
        }

    }




    public void UpdateFireRateUpgradeCostAndLvlText()
    {
        fRUpgradeCostButtonText.text = "$" + Mathf.FloorToInt(SaveManager.Instance.gameData.fireRateUpgradeCost);
        fRButtonLevelText.text = "Level " + SaveManager.Instance.gameData.fireRatelvl;
    }

    public void UpdateRangeUpgradeCostAndLvlText()
    {
        rangeUpgradeCostButtonText.text = "$" + Mathf.FloorToInt(SaveManager.Instance.gameData.bulletRangeUpgradeCost);
        rangeButtonLevelText.text = "Level " + SaveManager.Instance.gameData.rangeLvl;
    }

    public void UpdateIncomeUpgradeCostAndLvlText()
    {
        incomeUpgradeCostButtonText.text = "$" + Mathf.FloorToInt(SaveManager.Instance.gameData.moneyIncomeUpgradeCost);
        incomeButtonLevelText.text = "Level " + SaveManager.Instance.gameData.incomeLvl;
    }
}
