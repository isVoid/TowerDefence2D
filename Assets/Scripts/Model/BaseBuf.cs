using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuf : MonoBehaviour {
    public float lifeTime;
    public float currentTime = 0;

    protected void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > lifeTime)
        {
            Destroy(this);
        }
    }
}