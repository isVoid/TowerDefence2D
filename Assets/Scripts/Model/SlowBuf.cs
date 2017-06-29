using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBuf : BaseBuf {

    public float slowFactor;
    public float oldSpeed;

    void Start() {
        oldSpeed = transform.GetComponent<Enemy>().mySpeed;
        transform.GetComponent<Enemy>().mySpeed *= slowFactor;
    }

	// Update is called once per frame
	void Update () {
        base.Update();

	}

    void OnDestroy() {
        transform.GetComponent<Enemy>().mySpeed = oldSpeed;

    }
}
