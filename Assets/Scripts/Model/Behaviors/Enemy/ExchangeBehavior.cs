using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeBehavior : Enemy {

    protected override void loadEnemyData()
    {
        myType = EnemyType.Exchange;
        hp = data.EnemyHP[5];
        myValue = data.EnemyValue[5];
        mySpeed = data.EnemySpeed[5];
    }
}
