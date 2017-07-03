using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Wave
{
    public List<int> enemyCount;
    public List<EnemyType> enemyType;
    public float spawnInterval;
    public float timeToNextWave;

    public Wave(List<int> c, List<EnemyType> t, float itvl, float ttnw) 
    {
        enemyCount = c;
        enemyType = t;
        spawnInterval = itvl;
        timeToNextWave = ttnw;
    }
}

public class WaveSpawner : MonoBehaviour {

    private EnemyFactory factory;
    private GameFlow gameFlow;
    private GameSceneController controller;

    public float timeBeforeFirstWave = 10f;

    public float timeBetweenWaves = 10f;
    public float countdown = 0f;

    public int currentWave = 0;

    private List<Wave> waves;

	// Use this for initialization
	void Awake () {
        factory = EnemyFactory.getInstance();
        gameFlow = GameSceneController.getInstance() as GameFlow;
        controller = GameSceneController.getInstance();

	}
	
    void Start()
    {
        waves = GameData.getInstance().waveLists;

        Debug.Log(waves.Count + " waves to spawn.");

    }

	// Update is called once per frame
	void Update () {
		
        if (timeBeforeFirstWave > 0)
        {
            timeBeforeFirstWave -= Time.deltaTime;
            controller.updateCountDownUI("First Wave: " + timeBeforeFirstWave.ToString("F1") + "s");
            return;
        }

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
            countdown = waves[currentWave].timeToNextWave;

        }

        countdown -= Time.deltaTime;

	}

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waves[currentWave].enemyType.Count; i++)
        {
            Debug.Log(waves[currentWave].enemyType.Count);
            for (int j = 0; j < waves[currentWave].enemyCount[i]; j++)
            {
                Debug.Log("Spawning: "+ j + "/" + waves[currentWave].enemyCount[i] + " of " + waves[currentWave].enemyType[i]);
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
                yield return new WaitForSeconds(waves[currentWave].spawnInterval);
            }
        }
            
        currentWave++;
    }

    public bool waveFinish()
    {
        return currentWave == waves.Count;
    }
}
