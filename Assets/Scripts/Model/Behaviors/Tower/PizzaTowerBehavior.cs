﻿using System.Collections;
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
//            cannonBall.transform.localScale = new Vector3(0.5f, 0.5f, 76.8f);
            cannonBall.GetComponent<PizzaBallBehavior>().target = target.gameObject;
            cannonBall.GetComponent<PizzaBallBehavior>().damage = damage;
            cannonBall.GetComponent<PizzaBallBehavior>().explodeRange = explodeRange;
            cannonBall.GetComponent<PizzaBallBehavior>().bleedTime = bleedTime;
            cannonBall.GetComponent<PizzaBallBehavior>().bleedDamage = bleedDamage;
            Debug.Log(cannonBall.GetComponent<PizzaBallBehavior>().bleedDamage);
        }

    }

    protected override void loadTowerProperties()
    {
        explodeRange = d.PizzaTowerExplodeRange[lv];
        bleedTime = d.PizzaTowerBleedTime[lv];

        damage = d.PizzaTowerDamage[lv];
        value = value +  (int)Mathf.Floor(d.PizzaTowerPrice[lv] * 0.5f);

        if (lv < d.PizzaTowerLevel - 1)
        {
            nextValue = d.PizzaTowerPrice[lv + 1];
        }
        else
        {
            nextValue = int.MaxValue;
        }
    }
        
}
