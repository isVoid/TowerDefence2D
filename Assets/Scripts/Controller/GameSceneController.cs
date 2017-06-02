using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.TowerDefence2d {

    public class GameSceneController : System.Object, UserClickOp {
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

        public void setBuildBtnGroupPos(int stubIndex) {
            myGameModels.setBuildBtnGroupPos(stubIndex);
        }

        public int getChosenStubNum() {
            return myGameStatus.getChosenStubNum();
        }

        public void setClickedStubIndex(int index) {
            myGameStatus.setClickedStubIndex(index);
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
    }
}


