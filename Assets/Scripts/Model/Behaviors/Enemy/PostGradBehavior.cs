using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostGradBehavior : Enemy {

    protected Animator anim;
    public bool flip = true;
    float jiggleTime = 0.5f;
    public float t;

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
        t = jiggleTime;
    }

    protected override void loadEnemyData()
    {
        myType = EnemyType.PostGrad;
        hp = data.EnemyHP[4];
        myValue = data.EnemyValue[4];
        mySpeed = data.EnemySpeed[4];
    }

    //Special Ability
    public bool flashAvailable = true;
    float flashCoolDownTime = 15f;
    public float currentCoolDownTime = 0f;

    protected override void Update()
    {
        base.Update();

        if (t < 0)
        {
            if (flip)
            {
                anim.SetTrigger("Pos");
            }
            else
            {
                anim.SetTrigger("Neg");
            }
            flip = !flip;
            t = jiggleTime;
        }

        t -= Time.deltaTime;

        if (currentCoolDownTime > 0 && !flashAvailable)
        {
            currentCoolDownTime -= Time.deltaTime;
        }
        else if (currentCoolDownTime <= 0 && !flashAvailable)
        {
            flashAvailable = true;
        }
    }

    public override void hpMinus(float dmg)
    {
        if (!flashAvailable)
            base.hpMinus(dmg);
        else
        {
            flash();
            flashAvailable = false;
            currentCoolDownTime = flashCoolDownTime;
        }

    }

    void flash()
    {
        if (waypointIndex + 1 < WaypointManager.waypoints.Length)
        {
            waypointIndex = waypointIndex + 1;
            transform.position = WaypointManager.waypoints[waypointIndex].position;
            target = WaypointManager.waypoints[waypointIndex + 1].position;
        }
        else
        {
            Debug.Log("Cannot flash to finish. Immune to damage one time.");
        }
    }

}
