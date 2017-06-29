using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuandongTowerBehavior : BaseTowerBehavior {

    //This tower fires at multiple target;
    List<Transform> targets = new List<Transform>();
    int maxTargetNum = 3;

    protected override void fire() 
    {
        targets.Clear();
        List<GameObject> enemies = enemyFactory.getAllActiveEnemies();
        //Find multiple targets
        foreach (GameObject enemy in enemies)
        {
            if (targets.Count < maxTargetNum)
            {
                Transform loc = enemy.transform;

                if (Vector2.Distance(transform.position, loc.position) <= range)
                {
                    targets.Add(loc);
                }
            }
            else
            {
                break;
            }
        }
        //Fire at each target
        foreach (Transform target in targets)
        {
            if (target != null)
            {
                Vector2 currPos = new Vector2(this.gameObject.transform.position.x,
                    this.gameObject.transform.position.y + 0.5f);

                Vector2 tarPos = target.position;
                GameObject cannonBall = CannonBallFactory.getInstance().generateCannonBall(currPos, tarPos, BallType.GuandongBall);
                cannonBall.GetComponent<GuandongBallBehavior>().target = target.gameObject;
                cannonBall.GetComponent<GuandongBallBehavior>().damage = damage;

            }
        }
    }

}
