using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBallBehavior : MonoBehaviour {

    public BallType type;

    public GameObject target;

    protected Vector2 currentPos, targetPos;

    public float damage = 20f;

    void Awake() {
        currentPos = Vector2.zero;
        targetPos = Vector2.zero;
    }

    protected virtual void FixedUpdate() {
        //TODO: Define Shooting behavior

        transform.position = Vector2.MoveTowards(transform.position, targetPos, 4f * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) <= 0.2f)
        {
            target.GetComponent<Enemy>().hp -= damage;
            CannonBallFactory.getInstance().recycleCannonBall(this.gameObject);
        }
    }

    //初始化当前位置和目标位置
    public abstract void initTwoPos(Vector2 _currentPos, Vector2 _targetPos);

}
