using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI inGameMoneyText;
    [SerializeField] TextMeshProUGUI endLevelMoneyText;

    public static MoneyManager Instance;


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

    private void Start()
    {
        UpdateInGameMoneyText();
        UpdateEndLevelMoneyText();
    }


    public bool IsAffordable(float amount)
    {
        if (SaveManager.Instance.gameData.totalMoney >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DecreaseMoney(float amount)
    {
        SaveManager.Instance.gameData.totalMoney -= amount;
        UpdateInGameMoneyText();
        UpdateEndLevelMoneyText();
    }

    public void AddMoney(float amount)
    {
        SaveManager.Instance.gameData.totalMoney += amount;
        UpdateInGameMoneyText();
        UpdateEndLevelMoneyText();
    }




    void UpdateInGameMoneyText()
    {
        inGameMoneyText.text = "$" + Mathf.FloorToInt(SaveManager.Instance.gameData.totalMoney);
    }

    public void UpdateEndLevelMoneyText()
    {
        endLevelMoneyText.text = "$" + Mathf.FloorToInt(SaveManager.Instance.gameData.totalMoney);
    }
}
