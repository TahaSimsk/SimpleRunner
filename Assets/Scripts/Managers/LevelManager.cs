using RDG;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject inGameUI;
    [SerializeField] GameObject endOfLevelUI;
    [SerializeField] GameObject mainMenuUI;

    public static LevelManager Instance;


    [HideInInspector] public bool isDead = false;


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

        Application.targetFrameRate = 120;
    }

    private void Start()
    {
        SceneManager.LoadScene(0);
        mainMenuUI.SetActive(true);
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
        Vibration.Vibrate(100, 50);

    }

    public void NextLevelButton()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 1;
        }

        Time.timeScale = 1;
        inGameUI.SetActive(true);
        endOfLevelUI.SetActive(false);
        isDead = false;

        SaveManager.Instance.gameData.levelBuildIndex = nextSceneIndex;
        SceneManager.LoadScene(nextSceneIndex);

        Vibration.Vibrate(50, 50);
    }

    public void DeleteSave()
    {
        File.Delete(Application.persistentDataPath + "/data.qnd");
    }

    public void StartGameButton()
    {

        mainMenuUI.SetActive(false);
        inGameUI.SetActive(true);
        if (SaveManager.Instance.gameData.levelBuildIndex > 0)
        {
            SceneManager.LoadScene(SaveManager.Instance.gameData.levelBuildIndex);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }



}
