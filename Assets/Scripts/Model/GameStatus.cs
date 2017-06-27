using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {
    private GameSceneController gameSceneController;

    int chosenStubIndex = -1;
    int chosenTowerIndex = -1;

    void Start () {
        gameSceneController = GameSceneController.getInstance();
        gameSceneController.setGameStatus(this);
    }
	
	void Update () {
		
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
}
