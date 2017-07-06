﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    public EnemyType myType;
    public Vector3 target;
    public EnemyFactory enemyFactory;
    private GameSceneController controller;
    protected GameData data;

    public GameObject healthBarPrefab;
    private HealthBar healthBar;

    protected float fullHP;
    protected float hp;

    public float mySpeed;
    public int myValue;

    protected int waypointIndex = 0;

    protected virtual void Awake()
    {
        GameObject hb = Instantiate(healthBarPrefab, transform);
        hb.transform.localPosition = new Vector3(0, 0.7f, -1);

        healthBar = GetComponentInChildren<HealthBar>();

        enemyFactory = EnemyFactory.getInstance();
        controller = GameSceneController.getInstance();

        data = GameData.getInstance();

        loadEnemyData();

        fullHP = hp;
        healthBar.FullHealth = fullHP;
    }

	// Use this for initialization
	void OnEnable () {
        
        target = WaypointManager.waypoints[0].position;
        healthBar.hideHealthBar();

	}
        
	// Update is called once per frame
    protected virtual void Update () {
		
        if (hp <= 0)
        {
            killed();
        }
            
        Vector3 dir = target - transform.position;

        transform.Translate(dir.normalized * mySpeed * ((Random.value * 0.2f) + 0.9f) * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target) <= 0.2f)
        {
            GetNextWaypoint();
        }

        updateBufTint();

	}

    float r = 0.3f;
    void GetNextWaypoint()
    {
        waypointIndex++;

        if (waypointIndex >= WaypointManager.waypoints.Length)
        {
            damage();
        }

        target = WaypointManager.waypoints[waypointIndex].position;
        Vector3 rand = new Vector3(Random.value * r, Random.value * r + Random.value * r);
        target += rand;
    }

    public float getHP()
    {
        return hp;
    }

    public void sethp(float _hp)
    {
        hp = _hp;
        healthBar.updateHealthBar(hp);
    }

    public virtual void hpMinus(float dmg)
    {
        sethp(hp - dmg);
    }

    public void hpPlus(float health)
    {
        sethp(hp + health);
    }

    protected abstract void loadEnemyData();



    void destroy(){
        //Reset
        hp = fullHP;
        waypointIndex = 0;

        BaseBuf[] list = GetComponents<BaseBuf>();
        if (list.Length > 0)
        {
//            Debug.Log("Enemy Has Buf, removing before destroy");
            for (int i = 0; i < list.Length; i++)
            {
                Destroy(list[i]);
            }
        }
        GetComponent<SpriteRenderer>().color = Color.white; //Reset Color.
//        if (GetComponent<BleedBuf>() != null)
//            Destroy(GetComponent<BleedBuf>());
//        if (GetComponent<SlowBuf>() != null)
//            Destroy(GetComponent<SlowBuf>());
//        if (GetComponent<StunBuf>() != null)
//            Destroy(GetComponent<StunBuf>());

        //Recycle
        enemyFactory.recycle(transform.gameObject);
    }

    void killed()
    {
        controller.reward(myValue);
        destroy();
    }

    void damage()
    {
        controller.sufferDamage(1);
        destroy();
    }

    public void applyBleedBuf(float bleedTime, float bleedDamage)
    {
        if (bleedTime > 0)
        {
            BleedBuf b = transform.GetComponent<BleedBuf>();
            if (b == null)
            {
                b = gameObject.AddComponent<BleedBuf>();
                b.damagePerTick = bleedDamage;
                b.lifeTime = bleedTime;
            }
        }

    }

    public void applyStunnBuf(float stunTime)
    {
        if (stunTime > 0)
        {
            StunBuf b = transform.GetComponent<StunBuf>();
            if (b == null)
            {
                b = gameObject.AddComponent<StunBuf>();
                b.lifeTime = stunTime;
            }
        }
    }

    public void applySlowBuf(float slowTime, float slowFactor)
    {
        if (slowTime > 0)
        {
            SlowBuf b = transform.GetComponent<SlowBuf>();
            if (b == null)
            {
                b = gameObject.AddComponent<SlowBuf>();
                b.lifeTime = slowTime;
                b.slowFactor = slowFactor;
            }
        }
    }

    //Updating Tint needs global buf info
    protected virtual void updateBufTint()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (GetComponents<BaseBuf>().Length > 0)
        {
            Color mixed = Color.white;
            //Has Buf, Mix Color
            if (GetComponent<SlowBuf>() != null)
            {
                mixed = Color.Lerp(mixed, Color.blue, 0.2f);
            }
            if (GetComponent<BleedBuf>() != null)
            {
                mixed = Color.Lerp(mixed, Color.red, 0.2f);
            }
            if (GetComponent<StunBuf>() != null)
            {
                mixed = Color.Lerp(mixed, Color.black, 0.2f);
            }

            sr.color = mixed;
        }
        else
        {
            //Has no buf, reset color
            sr.color = Color.white;
        }

    }

}
