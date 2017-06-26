using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour {

    public static Transform[] waypoints;

    void Awake() {
        waypoints = new Transform[transform.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }

    public Transform getStart() {
        return waypoints[0];
    }

    public Transform getEnd() {
        return waypoints[transform.childCount - 1];
    }

}
