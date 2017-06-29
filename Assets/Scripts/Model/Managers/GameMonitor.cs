using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMonitor : MonoBehaviour {

    public WaveSpawner waveSpawner;

    private EnemyFactory enemyFactory;
    private GameStatus gameStatus;
    private GameSceneController controller;

	// Use this for initialization
	void Start () {
        controller = GameSceneController.getInstance();
        controller.setGameMonitor(this);

        enemyFactory = EnemyFactory.getInstance();
        gameStatus = transform.GetComponent<GameStatus>();
	}
	
	// Check If Game Meets certain rule trigger
	void Update () {

        //Win Condition: All Waves finished spawning, All Enemy killed, User Health more than 0
        if (waveSpawner.waveFinish() && enemyFactory.allSpriteRecycled() && gameStatus.getCurrentStar() > 0)
        {
            controller.endGame();
        }
        //Fail Condition: User Health equal to 0
        else if (gameStatus.getCurrentStar() == 0)
        {
            controller.failGame();
        }

	}


}
