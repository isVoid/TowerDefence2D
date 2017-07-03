using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{ Paused, Running, Win, Fail }

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
        gamePointManager.resetStar();
    }
	
	void Update () {
        
	}

    public GameState getGameState() {
        return gameState;
    }

    public void switchGameState(GameState state) {
        gameState = state;
    }

    public void setClickedStubIndex(int index) {
        chosenStubIndex = index;

        gameSceneController.setBuildBtnGroupPos(chosenStubIndex);
    }

    public void setClickedTowerIndex(int index) {
        chosenTowerIndex = index;

        gameSceneController.setUpgradeBtnGroupPos(chosenTowerIndex);
    }

    public void resetClickedTowerIndex()
    {
        chosenTowerIndex = -1;
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
