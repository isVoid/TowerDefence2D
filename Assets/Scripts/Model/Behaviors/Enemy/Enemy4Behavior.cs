using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Behavior : Enemy {

    protected override void loadEnemyData()
    {
        myType = EnemyType.Enemy4;
        hp = data.EnemyHP[3];
        myValue = data.EnemyValue[3];
        mySpeed = data.EnemySpeed[3];
    }
}
