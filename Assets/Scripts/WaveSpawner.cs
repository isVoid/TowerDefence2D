using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    private EnemyFactory factory;

    public float timeBetweenWaves = 20f;
    private float countdown = 0f;

    private int waveNum = 1;

	// Use this for initialization
	void Awake () {
		
        factory = EnemyFactory.Instance;

	}
	
	// Update is called once per frame
	void Update () {
		
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            waveNum++;
        }

        countdown -= Time.deltaTime;


	}

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNum; i++)
        {
            factory.spawn(EnemyType.Enemy1);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
