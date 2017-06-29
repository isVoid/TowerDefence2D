using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBuf : BaseBuf {

    float oldSpeed;
	// Use this for initialization
	void Start () {
        oldSpeed = gameObject.GetComponent<Enemy>().mySpeed;
        gameObject.GetComponent<Enemy>().mySpeed = 0;
	}
	
    void OnDestroy() {
        gameObject.GetComponent<Enemy>().mySpeed = oldSpeed;
    }

}
