using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Wave
{
    public int enemyCount;
    public List<EnemyType> enemyType;

    public Wave(int c, List<EnemyType> t) 
    {
        enemyCount = c;
        enemyType = t;
    }
}

public class WaveSpawner : MonoBehaviour {

    private EnemyFactory factory;
    private GameFlow gameFlow;

    public float timeBetweenWaves = 10f;
    public int spawnNum = 1;
    public float countdown = 0f;

    public int currentWave = 0;

    private List<Wave> waves;

	// Use this for initialization
	void Awake () {
        factory = EnemyFactory.getInstance();
        gameFlow = GameSceneController.getInstance() as GameFlow;
        waves = GameData.getInstance().waveLists;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (currentWave == waves.Count && factory.allSpriteRecycled())
        {
            Debug.Log("Level Finish!");
            gameFlow.endGame();
            return;
        }

        if (currentWave == waves.Count)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;

        }

        countdown -= Time.deltaTime;

	}

    IEnumerator SpawnWave()
    {
        Debug.Log(waves[currentWave].enemyCount);
        for (int i = 0; i < waves[currentWave].enemyCount; i++)
        {
            Debug.Log("Spawning: " + waves[currentWave].enemyType[i]);
            switch (waves[currentWave].enemyType[i])
            {
                case EnemyType.Enemy1:
                    factory.spawn(EnemyType.Enemy1);
                    break;
                case EnemyType.Enemy2:
                    factory.spawn(EnemyType.Enemy2);
                    break;
                case EnemyType.Enemy3:
                    factory.spawn(EnemyType.Enemy3);
                    break;
                case EnemyType.Enemy4:
                    factory.spawn(EnemyType.Enemy4);
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
            
        currentWave++;
    }

    public bool waveFinish()
    {
        return currentWave == waves.Count;
    }
}
