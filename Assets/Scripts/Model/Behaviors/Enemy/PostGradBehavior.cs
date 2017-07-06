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
    }


}
