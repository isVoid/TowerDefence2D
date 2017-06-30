using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaTowerBehavior : BaseTowerBehavior {

    //It cause range damge
    public float explodeRange = 1.5f;
    //It creates range bleed effect
    public float bleedTime = 0f;
    public float bleedDamage = 5f;

    protected override void fire() 
    {
        base.fire();

        if (target != null)
        {
            Vector2 currPos = new Vector2(this.gameObject.transform.position.x,
                this.gameObject.transform.position.y  + 0.5f);

            Vector2 tarPos = target.position;
//            Debug.Log(tarPos);
            GameObject cannonBall = CannonBallFactory.getInstance().generateCannonBall(currPos, tarPos, BallType.PizzaBall);
            cannonBall.GetComponent<PizzaBallBehavior>().target = target.gameObject;
            cannonBall.GetComponent<PizzaBallBehavior>().damage = damage;
            cannonBall.GetComponent<PizzaBallBehavior>().explodeRange = explodeRange;
            cannonBall.GetComponent<PizzaBallBehavior>().bleedTime = bleedTime;
            cannonBall.GetComponent<PizzaBallBehavior>().bleedDamage = bleedDamage;
        }

    }

    protected override void loadTowerProperties()
    {
        explodeRange = d.PizzaTowerExplodeRange[lv];
        bleedTime = d.PizzaTowerBleedTime[lv];
        bleedDamage = d.PizzaTowerDamage[lv];

        damage = d.PizzaTowerDamage[lv];
        value = (int)Mathf.Floor(d.PizzaTowerPrice[lv] * 0.5f);
    }
        
}
