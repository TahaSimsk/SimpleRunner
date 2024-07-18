using UnityEngine;

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


        gameData = SaveSystem.Load(gameData);
    }


    public void SaveGame()
    {
     
        SaveSystem.Save(gameData);
    }
}
