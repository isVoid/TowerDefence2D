using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour {

    public static Transform[] waypoints;
    public static Transform start;

    void Awake() {
        waypoints = new Transform[transform.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }

        start = GameObject.Find("WayPoint").transform;
    }

    float r = 0.3f;
    public Vector3 getStartPos() {
        return start.position + new Vector3(Random.value + r, Random.value * r + Random.value * r);
    }

    public Transform getEnd() {
        return waypoints[transform.childCount - 1];
    }

}
