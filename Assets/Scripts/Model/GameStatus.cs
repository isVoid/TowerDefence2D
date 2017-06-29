using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{ Paused, Running }

public class GameStatus : MonoBehaviour {
    private GameSceneController gameSceneController;

    GameState gameState;
    GamePointManager gamePointManager;

    int chosenStubIndex = -1;
    int chosenTowerIndex = -1;

    void Start () {
        gameSceneController = GameSceneController.getInstance();
        gameSceneController.setGameStatus(this);

        gameState = GameState.Running;

        gamePointManager = GamePointManager.getInstance();
    }
	
	void Update () {
		
	}

    public GameState getGameState() {
        return gameState;
    }

    public void switchGameState() {
        if (gameState == GameState.Running)
            gameState = GameState.Paused;
        else if (gameState == GameState.Paused)
            gameState = GameState.Running;
    }

    public void setClickedStubIndex(int index) {
        chosenStubIndex = index;

        gameSceneController.setBuildBtnGroupPos(chosenStubIndex);
    }

    public void setClickedTowerIndex(int index) {
        chosenTowerIndex = index;

        gameSceneController.setUpgradeBtnGroupPos(chosenTowerIndex);
    }

    public int getChosenStubNum() {
        return chosenStubIndex;
    }

    public int getChosenTowerNum() {
        return chosenTowerIndex;
    }

    public void sufferDamage(int value)
    {
        gamePointManager.sufferDamage(value);
        if (gamePointManager.starIsZero())
        {
            //TODO: Fail the game
        }
    }

    public int getCurrentStar()
    {
        return gamePointManager.CurrentStar;
    }
}
