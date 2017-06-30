using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behavior : Enemy {

    protected override void loadEnemyData()
    {
        myType = EnemyType.Enemy1;
        hp = data.EnemyHP[0];
        myValue = data.EnemyValue[0];
        mySpeed = data.EnemySpeed[0];
    }
}
