using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Enemy1 };
public enum StubType { FlatGround, ArrowTower, SoldierTower, WizardTower, CannonTower };

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

    public int[] CannonTowerPrice = {20, 40, 60, 80, 100};

    public int[] EnemyValue = { 5 };

}
