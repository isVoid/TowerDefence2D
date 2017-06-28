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

    public int GuandongTowerLevel = 3;
    public int[] GuandongTowerDamage = { 120, 200, 320 };
    public int[] GuandongTowerPrice = { 400, 120, 240 };

    public int MelonTowerLevel = 3;
    public int[] MelonTowerDamage = { 100, 120, 200 };
    public int[] MelonTowerPrice = { 380, 100, 100 };

    public int PizzaTowerLevel = 3;
    public int[] PizzaTowerDamage = { 100, 120, 300 };
    public int[] PizzaTowerPrice = { 500, 180, 240 };

    public int DrinkTowerLevel = 3;
    public int[] DrinkTowerDamage = { 80, 150, 240 };
    public int[] DrinkTowerPrice = { 120, 100, 200 };

    public int IceTowerLevel = 3;
    public int[] IceTowerDamage = { 80, 120, 300 };
    public int[] IceTowerPrice = { 200, 80, 220 };

//    public int[] EnemyValue = { 100, 200, 400, 800 };

    public List<Wave> waveLists = new List<Wave>(); 

    public void initLevelData (int level) {

        if (level == 0)
        {
            List<EnemyType> t0 = new List<EnemyType> {EnemyType.Enemy1, EnemyType.Enemy2, EnemyType.Enemy3};
            Wave wave0 = new Wave(3, t0);
            waveLists.Add(wave0);
        }

    }

}
