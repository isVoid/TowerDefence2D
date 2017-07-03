using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    public EnemyType myType;
    public Transform target;
    public EnemyFactory enemyFactory;
    private GameSceneController controller;
    protected GameData data;

    public GameObject healthBarPrefab;
    private HealthBar healthBar;

    protected float fullHP;
    protected float hp;

    public float mySpeed;
    public int myValue;

    private int waypointIndex = 0;

    void Awake()
    {
        GameObject hb = Instantiate(healthBarPrefab, transform);
        hb.transform.localPosition = new Vector3(0, 0.4f, -1);

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
        
        target = WaypointManager.waypoints[0];
        healthBar.hideHealthBar();

	}
	
	// Update is called once per frame
	void Update () {
		
        if (hp <= 0)
        {
            killed();
        }

        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * mySpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        updateBufTint();

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

    public void hpMinus(float dmg)
    {
        sethp(hp - dmg);
    }

    public void hpPlus(float health)
    {
        sethp(hp + health);
    }

    protected abstract void loadEnemyData();

    void GetNextWaypoint()
    {
        waypointIndex++;

        if (waypointIndex >= WaypointManager.waypoints.Length)
        {
            damage();
        }

        target = WaypointManager.waypoints[waypointIndex];
    }

    void destroy(){
        //Reset
        hp = fullHP;
        waypointIndex = 0;

        if (GetComponent<BleedBuf>() != null)
            Destroy(GetComponent<BleedBuf>());
        if (GetComponent<SlowBuf>() != null)
            Destroy(GetComponent<SlowBuf>());
        if (GetComponent<StunBuf>() != null)
            Destroy(GetComponent<StunBuf>());

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
    void updateBufTint()
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
