using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMonitor : MonoBehaviour {

    public float remainTimeOfLevel;
    public WaveSpawner waveSpawner;

    private EnemyFactory enemyFactory;
    private GameSceneController controller;
    private GameData data;

	// Use this for initialization
	void Start () {
        controller = GameSceneController.getInstance();
        controller.setGameMonitor(this);

        enemyFactory = EnemyFactory.getInstance();

        data = GameData.getInstance();
        remainTimeOfLevel = data.LevelTime[controller.getLevel()];
	}
	
	// Check If Game Meets certain rule trigger
	void Update () {

        if (remainTimeOfLevel > 0 && waveSpawner.timeBeforeFirstWave <= 0 && controller.getGameState() == GameState.Running)
        {
            remainTimeOfLevel -= Time.deltaTime;
            controller.updateCountDownUI("Level Remain Time: " + remainTimeOfLevel.ToString("F1") + "s");
        }
        //Win Condition 1: Level Time finish && alive
        //Critical Condition: When current star == 0 and ramain time == 0 is satisfied at the same time, consider as winning.
        else if (remainTimeOfLevel <= 0 && controller.getCurrentStar() >= 0)
        {
            controller.updateCountDownUI("");
            controller.endGame();
        }

        //Win Condition 2: All Waves finished spawning, All Enemy killed, User Health more than 0
        if (waveSpawner.waveFinish() && enemyFactory.allSpriteRecycled() && controller.getCurrentStar() > 0)
        {
            controller.updateCountDownUI("");
            controller.endGame();
        }
        //Fail Condition: User Health equal to 0
        else if (controller.getCurrentStar() == 0)
        {
            controller.updateCountDownUI("");
            controller.failGame();
        }

	}


}
