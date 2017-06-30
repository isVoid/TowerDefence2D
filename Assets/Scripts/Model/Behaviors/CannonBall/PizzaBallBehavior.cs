using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBallBehavior : BaseBallBehavior {
    public float g = -13.0f;       //重力加速度

    private Vector2 gravity;      //重力方向速度

    private float dTime = 0;

    public float explodeRange;
    public float bleedTime;
    public float bleedDamage;

    protected override void FixedUpdate() {
        dTime += Time.fixedDeltaTime;
        gravity.y = g * dTime;    //v=g*t
        //模拟位移
        this.gameObject.transform.Translate(speed * Time.fixedDeltaTime);
        this.gameObject.transform.Translate(gravity * Time.fixedDeltaTime);

        //当处于下落状态，且y方向位置低于target位置，则视为炮弹落地
        if (this.gameObject.transform.position.y < targetPos.y
            && abs(speed.y) < abs(gravity.y))
        {
            //            target.GetComponent<Enemy>().hp -= damage;
            explode();
            CannonBallFactory.getInstance().recycleCannonBall(this.gameObject);
        }
    }


    //取绝对值
    float abs(float a) {
        return a > 0 ? a : -a;
    }

    //初始化当前位置和目标位置
    public override void initTwoPos(Vector2 _currentPos, Vector2 _targetPos) {
        currentPos = _currentPos;
        targetPos = _targetPos;
        gameObject.transform.position = currentPos;

        speed = new Vector2((targetPos.x - currentPos.x) / duration,
            (targetPos.y - currentPos.y) / duration - 0.5f * g * duration);
        gravity = Vector2.zero;

        dTime = 0;
    }

    void explode()
    {
        enemyFactory.applyConstantRangeDamage(transform.position, explodeRange, damage);
        Debug.Log("Applying BleedBuf." + bleedTime);
        enemyFactory.applyRangeBleedBuf(transform.position, explodeRange, bleedTime, bleedDamage);
    }


    void OnDrawGizmosSelected(){
        float Radius = explodeRange;
        Transform T = transform.GetComponent<Transform>();
        Gizmos.color = Color.yellow;
        float theta = 0;
        float x = Radius*Mathf.Cos(theta);
        float y = Radius*Mathf.Sin(theta);
        Vector3 pos = T.position+new Vector3(x,y,0);
        Vector3 newPos = pos;
        Vector3 lastPos = pos;
        for(theta = 0.1f;theta<Mathf.PI*2;theta+=0.1f){
            x = Radius*Mathf.Cos(theta);
            y = Radius*Mathf.Sin(theta);
            newPos = T.position+new Vector3(x,y,0);
            Gizmos.DrawLine(pos,newPos);
            pos = newPos;
        }
        Gizmos.DrawLine(pos,lastPos);
    }
}
