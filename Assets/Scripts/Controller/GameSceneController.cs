using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : System.Object, UserClickOp, GameFlow, MenuClickOp {
    private static GameSceneController instance;
    private GameStatus myGameStatus;
    private GameModels myGameModels; 
    private UIManager myUIManager;
    private GameMonitor myGameMonitor;

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

    internal void setUIManager(UIManager _myUIManager)
    {
        if (myUIManager == null)
            myUIManager = _myUIManager;
    }

    internal void setGameMonitor(GameMonitor _myGameMonitor)
    {
        if (myGameMonitor == null)
            myGameMonitor = _myGameMonitor;
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
            myUIManager.updateStarViewOnGameFinish();
        }
    }

    public void failGame()
    {
        if (myGameStatus.getGameState() == GameState.Running)
        {
            myGameStatus.switchGameState();
            myGameModels.failGame();
            myUIManager.updateStarViewOnGameFinish();
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

    public void buildIceTower() {
        myGameModels.buildIceTower();
    }

    public void buildDrinkTower() {
        myGameModels.buildDrinkTower();
    }

    public void buildPizzaTower() {
        myGameModels.buildPizzaTower();
    }

    public void buildMelonTower() {
        myGameModels.buildMelonTower();
    }

    public void buildGuandongTower() {
        myGameModels.buildGuandongTower();
    }

    public void sellTower() {
        myGameModels.sellTower();
    }

    public void upgradeTower() {
        myGameModels.upgradeTower();
    }

    public void reward(int value)
    {
        myGameModels.reward(value);
    }

    public void sufferDamage(int num)
    {
        myGameStatus.sufferDamage(num);
        myUIManager.updateStarView(myGameStatus.getCurrentStar());
    }
        
}



