using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public EnemyType myType;
    public int myValue;
    public Transform target;
    public EnemyFactory enemyFactory;

    public float hp = 100f;
    public float mySpeed = 10f;

    private int waypointIndex = 0;

	// Use this for initialization
	void Start () {
        target = WaypointManager.waypoints[0];
        enemyFactory = EnemyFactory.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (hp <= 0)
        {
            enemyFactory.recycle(transform.gameObject);
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
            waypointIndex = 0;
            enemyFactory.recycle(transform.gameObject);
        }

        target = WaypointManager.waypoints[waypointIndex];
    }
}
