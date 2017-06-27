using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : BaseTower {

    private GameData d;

    public float range = 2.8f;
    public float interval = 2f;

    public CannonTower() {
        d = GameData.getInstance();
    }

    public void upgrade() {
        lv++;
    }

}
