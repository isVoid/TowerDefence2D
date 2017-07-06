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

    public List<Wave> waves;

    bool spawning = false;

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

        //Currently We do not support spawning 2 waves intercepting each other.
        if (countdown <= 0f && !spawning)
        {
            StartCoroutine(SpawnWave(false));
            countdown = waves[currentWave].timeToNextWave;
            spawning = true;
        }

        countdown -= Time.deltaTime;

	}

    void OnEnable()
    {
        if (spawning)
        {
            StartCoroutine(SpawnWave(true));
        }
    }

    public int i = 0;
    public int j = 0;
    IEnumerator SpawnWave(bool cont)
    {
        if (!cont)
        {
            for (i = 0; i < waves[currentWave].enemyType.Count; i++)
            {
                for (j = 0; j < waves[currentWave].enemyCount[i]; j++)
                {
                    int w = j + 1;
                    Debug.Log("Spawning: " + w + "/" + waves[currentWave].enemyCount[i] + " of " + waves[currentWave].enemyType[i]);
                    factory.spawn(waves[currentWave].enemyType[i]);
                    yield return new WaitForSeconds(waves[currentWave].spawnInterval);
                }
            }

            currentWave++;
            spawning = false;
        }
        else
        {
            for (; i < waves[currentWave].enemyType.Count; i++)
            {
                for (; j < waves[currentWave].enemyCount[i]; j++)
                {
                    int w = j + 1;
                    Debug.Log("Spawning: "+ w + "/" + waves[currentWave].enemyCount[i] + " of " + waves[currentWave].enemyType[i]);
                    factory.spawn(waves[currentWave].enemyType[i]);
                    yield return new WaitForSeconds(waves[currentWave].spawnInterval);
                }
            }

            currentWave++;
            spawning = false;
            i = j = 0;
        }
    }

    public bool waveFinish()
    {
        return currentWave == waves.Count;
    }
}
