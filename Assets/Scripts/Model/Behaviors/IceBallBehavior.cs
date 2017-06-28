using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBallBehavior : BaseBallBehavior {
    public float duration = 1.0f;
    public float g = -13.0f;       //重力加速度

    private Vector2 speed;        //初速度向量
    private Vector2 gravity;      //重力方向速度

    private float dTime = 0;

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

}
