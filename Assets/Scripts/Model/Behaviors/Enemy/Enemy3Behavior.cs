using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Behavior : Enemy {

    protected override void loadEnemyData()
    {
        myType = EnemyType.Enemy3;
        hp = data.EnemyHP[2];
        myValue = data.EnemyValue[2];
        mySpeed = data.EnemySpeed[2];
    }
}
