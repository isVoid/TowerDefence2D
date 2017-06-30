using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkBallBehavior : BaseBallBehavior {

    public float stunnTime = 1f;

    protected override void FixedUpdate() {
        //TODO: Define Shooting behavior

        transform.position = Vector2.MoveTowards(transform.position, targetPos, 4f * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) <= 0.2f)
        {
            target.GetComponent<Enemy>().applyStunnBuf(stunnTime);
            target.GetComponent<Enemy>().hp -= damage;
            CannonBallFactory.getInstance().recycleCannonBall(this.gameObject);
        }
    }

}
