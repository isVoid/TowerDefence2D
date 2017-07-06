using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MelonTowerBehavior : BaseTowerBehavior {

    public int bulletPerRound = 3;
    public float roundInterval = 0.2f;

    protected override void fire() 
    {
        base.fire();

        if (target != null)
        {   
            Vector2 currPos = new Vector2(this.gameObject.transform.position.x,
            this.gameObject.transform.position.y  + 0.5f);

            Vector2 tarPos = target.position;

            StartCoroutine(fireRound(currPos, tarPos));
        }

    }

    IEnumerator fireRound(Vector2 currPos, Vector2 tarPos)
    {
        for (int i = 0; i < bulletPerRound; i++)
        {
            if (target != null)
                if (target.gameObject.activeSelf)
                {
                    GameObject cannonBall = CannonBallFactory.getInstance().generateCannonBall(currPos, tarPos, BallType.MelonBall);
                    cannonBall.GetComponent<MelonBallBehavior>().target = target.gameObject;
                    cannonBall.GetComponent<MelonBallBehavior>().damage = damage;

//                    Debug.Log("Positions: " + target.position + " " + transform.position);
                    Vector2 dir = target.position - transform.position;

                    //            float angle = Vector2.Angle(new Vector2(1, 0), dir);

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

    //                Debug.Log(dir + " " + angle);
                    cannonBall.transform.rotation = Quaternion.Euler(0, 0, angle);

                    yield return new WaitForSeconds(roundInterval);
                }
            }

    }
 
    protected override void loadTowerProperties()
    {
        interval = d.MelonTowerFireInterval[lv];

        damage = d.MelonTowerDamage[lv];
        value = value + (int)Mathf.Floor(d.MelonTowerPrice[lv] * 0.5f);
        if (lv < d.MelonTowerLevel - 1)
        {
            nextValue = d.MelonTowerPrice[lv + 1];
        }
        else
        {
            nextValue = int.MaxValue;
        }
    }

}
