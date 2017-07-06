using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Enemy1, Enemy2, Enemy3, Enemy4, PostGrad, Exchange };
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
    public int[] GuandongTowerPrice = { 450, 200, 360 };
    public float[] GuandongTowerRange = { 2.8f, 3f, 3.5f };
    public int[] GuandongTowerMaxTargetNum = { 3, 4, 5 };

    public int MelonTowerLevel = 3;
    public int[] MelonTowerDamage = { 33, 40, 66 };
    public int[] MelonTowerPrice = { 420, 200, 200 };
    public float[] MelonTowerFireInterval = { 2f, 1.8f, 1.6f };

    public int PizzaTowerLevel = 3;
    public int[] PizzaTowerDamage = { 100, 120, 300 };
    public int[] PizzaTowerPrice = { 500, 240, 480 };
    public float[] PizzaTowerBleedTime = { 0f, 1f, 2f };
    public float[] PizzaTowerExplodeRange = { 0.8f, 0.9f, 1.0f };

    public int DrinkTowerLevel = 3;
    public int[] DrinkTowerDamage = { 80, 150, 240 };
    public int[] DrinkTowerPrice = { 120, 100, 200 };
    public float[] DrinkTowerStunTime = { 0f, 1f, 1f };
    public float[] DrinkTowerFireInterval = { 2f, 1.8f, 1.6f };

    public int IceTowerLevel = 3;
    public int[] IceTowerDamage = { 80, 120, 300 };
    public int[] IceTowerPrice = { 200, 120, 220 };
    public float[] IceTowerFireInterval = { 2, 1.8f, 1.6f };
    public float[] IceTowerSlowTime = { 2f, 2f, 2f };
    public float[] IceTowerSlowFactor = { 0.95f, 0.9f, 0.8f };

    public int[] EnemyValue = { 50, 100, 200, 400, 500, 800 };
    public int[] EnemyHP = { 100, 200, 400, 800, 3000, 3000 };
    public float[] EnemySpeed = { 0.2f, 1.0f, 0.4f, 1.0f, 0.4f, 0.5f };

    public int totalLevel = 3;
    public float[] LevelTime = { 140f, 140f, 140f };
    public int[] LevelStar = { 0, 0, 0 };

    public List<Wave> waveLists = new List<Wave>(); 

    public void initLevelData (int level) {

        waveLists.Clear();
        // First level
        if (level == 0)
        {
            /*
             * Wave 0:
             * Enemy Team: 5 Enemy2;
             * Time to next Wave: 15s;
            */

            List<EnemyType> t0 = new List<EnemyType> {EnemyType.Enemy2};
            List<int> c0 = new List<int> { 5 };
            float sItvl0 = 0.5f;
            float ttnw0 = 15f;
            Wave wave0 = new Wave(c0, t0, sItvl0, ttnw0);
            waveLists.Add(wave0);

            /*
             * Wave 1:
             * Enemy Team: 8 Enemy1; 3 Enemy3;
             * Time to next Wave: 15s;
            */

            List<EnemyType> t1 = new List<EnemyType> {EnemyType.Enemy1, EnemyType.Enemy3};
            List<int> c1 = new List<int> { 8, 3 };
            float sItvl1 = 0.5f;
            float ttnw1 = 20;
            Wave wave1 = new Wave(c1, t1, sItvl1, ttnw1);
            waveLists.Add(wave1);

            /*
             * Wave 2:
             * Enemy Team: 12 Enemy1; 4 Enemy3;
             * Time to next Wave: 15s;
            */

            List<EnemyType> t2 = new List<EnemyType> {EnemyType.Enemy1, EnemyType.Enemy4, EnemyType.Enemy2};
            List<int> c2 = new List<int> { 12, 4, 5 };
            float sItvl2 = 0.5f;
            float ttnw2 = 25;
            Wave wave2 = new Wave(c2, t2, sItvl2, ttnw2);
            waveLists.Add(wave2);


            /*
             * Wave 3 (Boss Wave):
             * Enemy Team: 1 PostGrad; 3 ExchangeStud; 5 Enemy3
             * Time to next Wave: 30s;
            */

            List<EnemyType> t3 = new List<EnemyType> {EnemyType.PostGrad, EnemyType.Exchange, EnemyType.Enemy3};
            List<int> c3 = new List<int> { 1, 3, 5 };
            float sItvl3 = 0.5f;
            float ttnw3 = 30;
            Wave wave3 = new Wave(c3, t3, sItvl3, ttnw3);
            waveLists.Add(wave3);

            /*
             * Wave 4 (Final Wave):
             * Enemy Team: 8 Enemy4
             * Time to next Wave: N/A;
            */

            List<EnemyType> t4 = new List<EnemyType> { EnemyType.Enemy4 };
            List<int> c4 = new List<int> { 8 };
            float sItvl4 = 0.5f;
            float ttnw4 = 9999;
            Wave wave4 = new Wave(c4, t4, sItvl4, ttnw4);
            waveLists.Add(wave4);

        }

        else if (level == 1)
        {
            /*
             * Wave 0:
             * Enemy Team: 5 Enemy2;
             * Time to next Wave: 15s;
            */

            List<EnemyType> t0 = new List<EnemyType> {EnemyType.Enemy1, EnemyType.Enemy2};
            List<int> c0 = new List<int> { 5, 5 };
            float sItvl0 = 0.5f;
            float ttnw0 = 15f;
            Wave wave0 = new Wave(c0, t0, sItvl0, ttnw0);
            waveLists.Add(wave0);

            /*
             * Wave 1:
             * Enemy Team: 12 Enemy3;
             * Time to next Wave: 15s;
            */

            List<EnemyType> t1 = new List<EnemyType> {EnemyType.Enemy3};
            List<int> c1 = new List<int> { 12 };
            float sItvl1 = 0.5f;
            float ttnw1 = 15f;
            Wave wave1 = new Wave(c1, t1, sItvl1, ttnw1);
            waveLists.Add(wave1);

            /*
             * Wave 2:
             * Enemy Team: 12 Enemy3;
             * Time to next Wave: 15s;
            */

            List<EnemyType> t2 = new List<EnemyType> {EnemyType.Exchange};
            List<int> c2 = new List<int> { 5 };
            float sItvl2 = 0.5f;
            float ttnw2 = 25;
            Wave wave2 = new Wave(c2, t2, sItvl2, ttnw2);
            waveLists.Add(wave2);

            /*
             * Wave 3:
             * Enemy Team: 12 Enemy3;
             * Time to next Wave: 15s;
            */

            List<EnemyType> t3 = new List<EnemyType> {EnemyType.Enemy4, EnemyType.PostGrad, EnemyType.Enemy1};
            List<int> c3 = new List<int> { 3, 3, 8 };
            float sItvl3 = 0.5f;
            float ttnw3 = 25;
            Wave wave3 = new Wave(c3, t3, sItvl3, ttnw3);
            waveLists.Add(wave3);

            /*
             * Wave 4:
             * Enemy Team: 12 Enemy3;
             * Time to next Wave: 15s;
            */

            List<EnemyType> t4 = new List<EnemyType> {EnemyType.Enemy3};
            List<int> c4 = new List<int> { 8 };
            float sItvl4 = 0.5f;
            float ttnw4 = 9999;
            Wave wave4 = new Wave(c4, t4, sItvl4, ttnw4);
            waveLists.Add(wave4);

        }

        else if (level == 2)
        {
            /*
             * Wave 0:
             * Enemy Team: 5 Enemy2;
             * Time to next Wave: 15s;
            */

            List<EnemyType> t0 = new List<EnemyType> {EnemyType.Enemy4};
            List<int> c0 = new List<int> { 7 };
            float sItvl0 = 0.5f;
            float ttnw0 = 10f;
            Wave wave0 = new Wave(c0, t0, sItvl0, ttnw0);
            waveLists.Add(wave0);

            List<EnemyType> t1 = new List<EnemyType> {EnemyType.Enemy2, EnemyType.Exchange};
            List<int> c1 = new List<int> { 8, 2 };
            float sItvl1 = 0.5f;
            float ttnw1 = 10f;
            Wave wave1 = new Wave(c1, t1, sItvl1, ttnw1);
            waveLists.Add(wave1);

            List<EnemyType> t2 = new List<EnemyType> {EnemyType.Enemy4, EnemyType.Enemy1};
            List<int> c2 = new List<int> { 5, 15 };
            float sItvl2 = 0.5f;
            float ttnw2 = 15;
            Wave wave2 = new Wave(c2, t2, sItvl2, ttnw2);
            waveLists.Add(wave2);

            List<EnemyType> t3 = new List<EnemyType> {EnemyType.Enemy1, EnemyType.Enemy3, EnemyType.Enemy4};
            List<int> c3 = new List<int> { 8, 8, 4 };
            float sItvl3 = 0.5f;
            float ttnw3 = 20;
            Wave wave3 = new Wave(c3, t3, sItvl3, ttnw3);
            waveLists.Add(wave3);

            List<EnemyType> t4 = new List<EnemyType> {EnemyType.Enemy4, EnemyType.Enemy4, EnemyType.PostGrad, EnemyType.Exchange};
            List<int> c4 = new List<int> { 8, 5, 3, 3 };
            float sItvl4 = 0.5f;
            float ttnw4 = 9999;
            Wave wave4 = new Wave(c4, t4, sItvl4, ttnw4);
            waveLists.Add(wave4);

        }
    }

    /**

    RUNTIME DATA
    
    **/

    public int balance = 1000;

}
