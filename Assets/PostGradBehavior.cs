using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostGradBehavior : Enemy {

    protected override void loadEnemyData()
    {
        myType = EnemyType.PostGrad;
        hp = data.EnemyHP[4];
        myValue = data.EnemyValue[4];
        mySpeed = data.EnemySpeed[4];
    }


}
