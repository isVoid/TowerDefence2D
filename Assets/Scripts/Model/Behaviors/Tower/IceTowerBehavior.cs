using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTowerBehavior : BaseTowerBehavior {

    public float slowTime = 2f;
    public float slowFactor = 0.8f;

    protected override void fire() 
    {
        base.fire();

        if (target != null)
        {       
            Vector2 currPos = new Vector2(this.gameObject.transform.position.x,
            this.gameObject.transform.position.y  + 0.5f);

            Vector2 tarPos = target.position;
            GameObject cannonBall = CannonBallFactory.getInstance().generateCannonBall(currPos, tarPos, BallType.IceBall);
            cannonBall.GetComponent<IceBallBehavior>().target = target.gameObject;
            cannonBall.GetComponent<IceBallBehavior>().damage = damage;
            cannonBall.GetComponent<IceBallBehavior>().slowTime = slowTime;
            cannonBall.GetComponent<IceBallBehavior>().slowFactor = slowFactor;
        }


    }

    protected override void loadTowerProperties()
    {
        slowTime = d.IceTowerSlowTime[lv];
        slowFactor = d.IceTowerSlowFactor[lv];

        interval = d.IceTowerFireInterval[lv];
        damage = d.IceTowerDamage[lv];
        value = (int)Mathf.Floor(d.IceTowerPrice[lv] * 0.5f);
    }
        
}
