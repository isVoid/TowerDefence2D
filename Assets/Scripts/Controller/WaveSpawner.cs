using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    private EnemyFactory factory;
    private GameFlow gameFlow;

    public float timeBetweenWaves = 5f;
    public int spawnNum = 1;
    private float countdown = 0f;

    private int currentWave = 0;
    private int waveNum = 3;

	// Use this for initialization
	void Awake () {
        factory = EnemyFactory.Instance;
        gameFlow = GameSceneController.getInstance() as GameFlow;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (currentWave == waveNum && factory.allSpriteRecycled())
        {
            Debug.Log("Level Finish!");
            gameFlow.endGame();
            return;
        }

        if (currentWave == waveNum)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            currentWave++;
        }

        countdown -= Time.deltaTime;

	}

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < spawnNum; i++)
        {
            factory.spawn(EnemyType.Enemy1);
            yield return new WaitForSeconds(1f);
        }
    }

}
