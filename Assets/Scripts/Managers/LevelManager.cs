using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject inGameUI;
    [SerializeField] GameObject endOfLevelUI;


    public static LevelManager Instance;
    public GameData gameData;


    public bool isDead = false;


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
        //load the level that is currently saved index
        SceneManager.LoadScene(gameData.levelBuildIndex);
    }




    public void TriggerEndOfLevel()
    {
        inGameUI.SetActive(false);
        endOfLevelUI.SetActive(true);
        Time.timeScale = 0f;
        isDead = true;
        MoneyManager.Instance.UpdateEndLevelMoneyText();
        Shop.Instance.UpdateFireRateUpgradeCostAndLvlText();
        Shop.Instance.UpdateRangeUpgradeCostAndLvlText();
        Shop.Instance.UpdateIncomeUpgradeCostAndLvlText();
        
    }

    public void NextLevelButton()
    {

        Time.timeScale = 1;
        inGameUI.SetActive(true);
        endOfLevelUI.SetActive(false);
        isDead = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }



    public void DeleteSave()
    {
        File.Delete(Application.persistentDataPath + "/data.qnd");
    }



}
