using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Behavior : Enemy {

    protected override void loadEnemyData()
    {
        myType = EnemyType.Enemy2;
        hp = data.EnemyHP[1];
        myValue = data.EnemyValue[1];
        mySpeed = data.EnemySpeed[1];
    }
}
