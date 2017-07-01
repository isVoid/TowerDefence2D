using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Enemy1, Enemy2, Enemy3, Enemy4 };
public enum TowerType { GuandongTower, MelonTower, PizzaTower, DrinkTower, IceTower }
public enum BallType { GuandongBall, MelonBall, PizzaBall, DrinkBall, IceBall }

public class GameData {

    private static GameData instance;
    private GameData() {}

    public static GameData getInstance() {

        if (instance == null)
        {
            instance = new GameData();
        }
        return instance;
        
    }

    /**

    STATIC DATA
    
    **/

    public int GuandongTowerLevel = 3;
    public int[] GuandongTowerDamage = { 120, 200, 320 };
    public int[] GuandongTowerPrice = { 400, 120, 240 };
    public float[] GuandongTowerRange = { 2.8f, 3f, 3.5f };
    public int[] GuandongTowerMaxTargetNum = { 3, 4, 5 };

    public int MelonTowerLevel = 3;
    public int[] MelonTowerDamage = { 100, 120, 200 };
    public int[] MelonTowerPrice = { 380, 100, 100 };
    public float[] MelonTowerFireInterval = { 2f, 1.8f, 1.6f };

    public int PizzaTowerLevel = 3;
    public int[] PizzaTowerDamage = { 100, 120, 300 };
    public int[] PizzaTowerPrice = { 500, 180, 240 };
    public float[] PizzaTowerBleedTime = { 0f, 1f, 2f };
    public float[] PizzaTowerExplodeRange = { 0.8f, 0.9f, 1.0f };

    public int DrinkTowerLevel = 3;
    public int[] DrinkTowerDamage = { 80, 150, 240 };
    public int[] DrinkTowerPrice = { 120, 100, 200 };
    public float[] DrinkTowerStunTime = { 0f, 1f, 1f };
    public float[] DrinkTowerFireInterval = { 2f, 1.8f, 1.6f };

    public int IceTowerLevel = 3;
    public int[] IceTowerDamage = { 80, 120, 300 };
    public int[] IceTowerPrice = { 200, 80, 220 };
    public float[] IceTowerFireInterval = { 2, 1.8f, 1.6f };
    public float[] IceTowerSlowTime = { 2f, 2f, 2f };
    public float[] IceTowerSlowFactor = { 0.9f, 0.85f, 0.8f };

    public int[] EnemyValue = { 100, 200, 400, 800 };
    public int[] EnemyHP = { 100, 200, 400, 800 };
    public float[] EnemySpeed = { 0.2f, 0.4f, 0.8f, 1.0f};

    public int totalLevel = 1;
    public float[] LevelTime = { 90f };
    public int[] LevelStar = { 0 };

    public List<Wave> waveLists = new List<Wave>(); 

    public void initLevelData (int level) {

        waveLists.Clear();
        if (level == 0)
        {
            List<EnemyType> t0 = new List<EnemyType> {EnemyType.Enemy1, EnemyType.Enemy2, EnemyType.Enemy3};
            Wave wave0 = new Wave(3, t0);
            waveLists.Add(wave0);
        }

    }

    /**

    RUNTIME DATA
    
    **/

    public int balance = 1500;

}
