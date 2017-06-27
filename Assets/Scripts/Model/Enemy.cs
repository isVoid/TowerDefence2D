using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public EnemyType myType;
    public Transform target;
    public EnemyFactory enemyFactory;
    private FinanceManager fm;

    public float hp = 100f;
    public float mySpeed = 10f;
    public int myValue = 5;

    private int waypointIndex = 0;

	// Use this for initialization
	void Start () {
        target = WaypointManager.waypoints[0];
        enemyFactory = EnemyFactory.Instance;
        fm = FinanceManager.getInstance();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (hp <= 0)
        {
            destroy();
            //Reward
            fm.increaseMoney(myValue);

        }

        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * mySpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

	}

    void GetNextWaypoint()
    {
        waypointIndex++;

        if (waypointIndex >= WaypointManager.waypoints.Length)
        {
            destroy();
        }

        target = WaypointManager.waypoints[waypointIndex];
    }

    void destroy(){
        //Reset
        hp = 100;
        waypointIndex = 0;
        //Recycle
        enemyFactory.recycle(transform.gameObject);
    }
}
