using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBallBehavior : MonoBehaviour {

    public BallType type;

    public GameObject target;
    protected EnemyFactory enemyFactory;

    protected Vector2 currentPos, targetPos;

    public float duration = 1.0f;
    protected Vector2 speed;        //初速度向量

    public float damage = 20f;

    void Awake() {
        currentPos = Vector2.zero;
        targetPos = Vector2.zero;

        enemyFactory = EnemyFactory.getInstance();
    }

    protected virtual void OnEnable(){
    }

    protected virtual void Start() {
    }

    protected virtual void FixedUpdate() {
        //TODO: Define Shooting behavior

        transform.position = Vector2.MoveTowards(transform.position, targetPos, 4f * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) <= 0.2f)
        {
            target.GetComponent<Enemy>().hpMinus(damage);
            CannonBallFactory.getInstance().recycleCannonBall(this.gameObject);
        }
    }

    //初始化当前位置和目标位置
    public virtual void initTwoPos(Vector2 _currentPos, Vector2 _targetPos) {
        currentPos = _currentPos;
        targetPos = _targetPos;
        gameObject.transform.position = currentPos;

        speed = targetPos - currentPos ;

    }

}
