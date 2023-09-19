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
    [SerializeField] TextMeshProUGUI moneyText;

    public static LevelManager Instance;
    public GameData gameData;

    public float totalMoney;




    private void Awake()
    {

        gameData = SaveSystem.Load();

        totalMoney = gameData.totalMoney;
        moneyText.text = "$" + totalMoney;

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


    }

    public void NextLevelButton()
    {
        SaveLevel();
        SceneManager.LoadScene(gameData.levelBuildIndex);
        Time.timeScale = 1;
        inGameUI.SetActive(true);
        endOfLevelUI.SetActive(false);


        //save the total money when the player touches finishline //or when the character dies/collides with end mannequins
        gameData.totalMoney = totalMoney;
        SaveSystem.Save(gameData);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }



    public void GetMoney(float money)
    {
        totalMoney = money;

        moneyText.text = "$" + totalMoney;
    }


    //save the level if the current scene index is bigger than the index that is saved previously. Meaning if you go the the next lvl the index will be bigger than the current saved index.
    void SaveLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == gameData.levelBuildIndex)
        {
            gameData.levelBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SaveSystem.Save(gameData);
        }

    }

    public void DeleteSave()
    {
        File.Delete(Application.persistentDataPath + "/data.qnd");
    }



}
