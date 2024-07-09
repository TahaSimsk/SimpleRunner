using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Powers : MonoBehaviour
{
    public static Powers Instance;
    public GameData gameData;


    public float fireRate;
    public float bulletRange;
    public float moneyIncomeMultiplier;

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
        fireRate = gameData.fireRate;
        bulletRange = gameData.bulletRange;
        moneyIncomeMultiplier = gameData.moneyIncomeMultiplier;
    }

}
