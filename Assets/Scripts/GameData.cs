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


    public GameData()
    {
        totalMoney = 100;
        levelBuildIndex = 0;
        fireRate = 0.5f;
        bulletRange = 1;
    }
}
