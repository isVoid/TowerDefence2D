using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : System.Object, UserClickOp, GameFlow, MenuClickOp {
    private static GameSceneController instance;
    private GameStatus myGameStatus;
    private GameModels myGameModels; 

    public static GameSceneController getInstance() {
        if (instance == null)
            instance = new GameSceneController();
        return instance;
    }

    internal void setGameStatus(GameStatus _myGameStatus) {
        if (myGameStatus == null) {
            myGameStatus = _myGameStatus;
        }
    }

    internal void setGameModels(GameModels _myGameModels) {
        if (myGameModels == null) {
            myGameModels = _myGameModels;
        }
    }

    public void startGame()
    {
        if (myGameStatus.getGameState() == GameState.Paused)
        {
            myGameStatus.switchGameState();
            myGameModels.startGame();
        }
    }

    public void pauseGame()
    {
        if (myGameStatus.getGameState() == GameState.Running)
        {
            myGameStatus.switchGameState();
            myGameModels.pauseGame();
        }
    }

    public void endGame()
    {
        if (myGameStatus.getGameState() == GameState.Running)
        {
            myGameStatus.switchGameState();
            myGameModels.endGame();
        }
    }

    public void setBuildBtnGroupPos(int stubIndex) {
        myGameModels.setBuildBtnGroupPos(stubIndex);
    }

    public void setUpgradeBtnGroupPos(int towerIndex) {
        myGameModels.setUpgradeBtnGroupPos(towerIndex);
    }

    public int getChosenStubNum() {
        return myGameStatus.getChosenStubNum();
    }

    public int getChosenTowerNum() {
        return myGameStatus.getChosenTowerNum();
    }

    public void setClickedStubIndex(int index) {
        myGameStatus.setClickedStubIndex(index);
    }

    public void setClickedTowerIndex(int index) {
        myGameStatus.setClickedTowerIndex(index);
    }

    public void buildArrowTower() {
        myGameModels.buildArrowTower();
    }

    public void buildSoldierTower() {
        myGameModels.buildSoldierTower();
    }

    public void buildWizardTower() {
        myGameModels.buildWizardTower();
    }

    public void buildCannonTower() {
        myGameModels.buildCannonTower();
    }

    public void sellTower() {
        myGameModels.sellTower();
    }

    public void upgradeTower() {
        myGameModels.upgradeTower();
    }
}



