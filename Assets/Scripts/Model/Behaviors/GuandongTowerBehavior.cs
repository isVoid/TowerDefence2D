using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuandongTowerBehavior : BaseTowerBehavior {

    protected override void fire() 
    {
        base.fire();

        if (target != null)
        {
            Vector2 currPos = new Vector2(this.gameObject.transform.position.x,
                this.gameObject.transform.position.y  + 0.5f);

            Vector2 tarPos = target.position;
            GameObject cannonBall = CannonBallFactory.getInstance().generateCannonBall(currPos, tarPos, BallType.GuandongBall);
            cannonBall.GetComponent<GuandongBallBehavior>().target = target.gameObject;
            cannonBall.GetComponent<GuandongBallBehavior>().damage = damage;

        }
         
    }

}
