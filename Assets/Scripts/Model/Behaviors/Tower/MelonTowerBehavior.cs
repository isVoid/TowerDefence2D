using Com.TowerDefence2d;
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
            GameObject cannonBall = CannonBallFactory.getInstance().generateCannonBall(currPos, tarPos, BallType.MelonBall);
            cannonBall.GetComponent<MelonBallBehavior>().target = target.gameObject;
            cannonBall.GetComponent<MelonBallBehavior>().damage = damage;
            yield return new WaitForSeconds(roundInterval);
        }
    }
 
    protected override void loadTowerProperties()
    {
        interval = d.MelonTowerFireInterval[lv];

        damage = d.MelonTowerDamage[lv];
        value = (int)Mathf.Floor(d.MelonTowerPrice[lv] * 0.5f);
    }

}
