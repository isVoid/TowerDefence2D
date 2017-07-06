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
                cannonBall.GetComponent<SpriteRenderer>().sprite = levelCannonBallImages[lv];

                Vector2 dir = target.position - transform.position;
                float angle;
                if (dir.x == 0)
                {
                    if (dir.y > 0)
                        angle = 90;
                    else if (dir.y < 0)
                        angle = -90;
                    else
                        angle = 0;
                }
                else
                {
                    angle = Mathf.Atan(Mathf.Abs(dir.y/dir.x)) * 57.29f;

                    if (dir.x > 0 && dir.y > 0)
                    {
                        //angle = angle;
                    }
                    else if (dir.x <= 0 && dir.y > 0)
                    {
                        angle = 180 - angle;
                    }
                    else if (dir.x <= 0 && dir.y <= 0)
                    {
                        angle = 180 + angle;
                    }
                    else if (dir.x > 0 && dir.y <= 0)
                    {
                        angle = 360 - angle;
                    }
                }
                cannonBall.transform.rotation = Quaternion.Euler(0, 0, angle);

            }
        }
    }

    protected override void loadTowerProperties()
    {
        maxTargetNum = d.GuandongTowerMaxTargetNum[lv];
        range = d.GuandongTowerRange[lv];

        damage = d.GuandongTowerDamage[lv];
        value = value + (int)Mathf.Floor(d.GuandongTowerPrice[lv] * 0.5f);
        if (lv < d.GuandongTowerLevel - 1)
        {
            nextValue = d.GuandongTowerPrice[lv + 1];
        }
        else
        {
            nextValue = int.MaxValue;
        }

    }


}
