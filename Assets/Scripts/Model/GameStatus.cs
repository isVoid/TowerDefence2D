using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {
    private GameSceneController gameSceneController;

    int chosenStubIndex = -1;

    void Start () {
        gameSceneController = GameSceneController.getInstance();
        gameSceneController.setGameStatus(this);
    }
	
	void Update () {
		
	}

    public void setClickedStubIndex(int index) {
        chosenStubIndex = index;
        Debug.Log("setClickedStubIndex " + chosenStubIndex);

        gameSceneController.setBuildBtnGroupPos(chosenStubIndex);
    }

    public int getChosenStubNum() {
        return chosenStubIndex;
    }
}
