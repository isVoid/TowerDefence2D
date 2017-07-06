using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeBehavior : Enemy {

    protected override void loadEnemyData()
    {
        myType = EnemyType.Exchange;
        hp = data.EnemyHP[5];
        myValue = data.EnemyValue[5];
        mySpeed = data.EnemySpeed[5];
    }

    //Special Ability
    public bool isGodMode = false;
    public bool godIsAvailable = true;
    public float godModeTime = 5f;
    public float currentGodModeTime = 5f;
    public float godCoolDownTime = 20f + 5f;
    public float currentCoolDownTime;

    protected override void Update()
    {
        base.Update();
        if (currentCoolDownTime > 0 && !godIsAvailable)
        {
            currentCoolDownTime -= Time.deltaTime;
        }
        else if (currentCoolDownTime <= 0 && !godIsAvailable)
        {
            godIsAvailable = true;
        }

        if (currentGodModeTime <= 0 && isGodMode)
        {
            UNGODMODE();
            currentGodModeTime = godModeTime;
        }
        else if (isGodMode)
        {
            currentGodModeTime -= Time.deltaTime;
        }

    }

    public override void hpMinus(float dmg)
    {
        if (!isGodMode && !godIsAvailable)
            base.hpMinus(dmg);
        else if (godIsAvailable)
        {
            GODMODE();
            godIsAvailable = false;
            currentCoolDownTime = godCoolDownTime;
        }
    }

    void GODMODE()
    {
        isGodMode = true;
//        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
//        Debug.Log(GetComponent<SpriteRenderer>().color);
        GetComponent<Animator>().SetTrigger("GodModeEnter");
    }

    void UNGODMODE()
    {
        isGodMode = false;
//        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<Animator>().SetTrigger("GodModeExit");
    }

//    //Updating Tint needs global buf info
//    protected override void updateBufTint()
//    {
//        SpriteRenderer sr = GetComponent<SpriteRenderer>();
//        if (GetComponents<BaseBuf>().Length > 0)
//        {
//            Color mixed = Color.white;
//            //Has Buf, Mix Color
//            if (GetComponent<SlowBuf>() != null)
//            {
//                mixed = Color.Lerp(mixed, Color.blue, 0.2f);
//            }
//            if (GetComponent<BleedBuf>() != null)
//            {
//                mixed = Color.Lerp(mixed, Color.red, 0.2f);
//            }
//            if (GetComponent<StunBuf>() != null)
//            {
//                mixed = Color.Lerp(mixed, Color.black, 0.2f);
//            }
//
//            sr.color = mixed;
//        }
//        else if (!isGodMode)
//        {
//            //Has no buf, reset color
//            sr.color = Color.white;
//        }
//        else
//        {
//            sr.color = Color.black;
//        }
//
//    }
}
