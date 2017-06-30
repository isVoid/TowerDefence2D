using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedBuf : BaseBuf {

    public float timePerTick = 0.1f;
    public float damagePerTick;
    public int lastTick = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();

        int tick = (int)Mathf.Floor(currentTime / timePerTick);
        if (tick > lastTick)
        {
            transform.GetComponent<Enemy>().hp -= damagePerTick;
            lastTick++;
        }
	}

}
