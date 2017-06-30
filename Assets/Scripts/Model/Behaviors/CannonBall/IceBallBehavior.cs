using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBallBehavior : BaseBallBehavior {

    public float slowTime = 2f;
    public float slowFactor = 0.8f;

    protected override void FixedUpdate() {
        //TODO: Define Shooting behavior

        transform.position = Vector2.MoveTowards(transform.position, targetPos, 4f * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) <= 0.2f)
        {
            target.GetComponent<Enemy>().applySlowBuf(slowTime, slowFactor);
            target.GetComponent<Enemy>().hp -= damage;
            CannonBallFactory.getInstance().recycleCannonBall(this.gameObject);
        }
    }
}
