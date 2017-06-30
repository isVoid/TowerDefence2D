using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour {

    UserClickOp userClickOp;
    SceneClickOp sceneClickOp;
    MenuClickOp menuClickOp;

    void Start () {
        userClickOp = GameSceneController.getInstance() as UserClickOp;
        sceneClickOp = GameObject.Find("GameManager").GetComponent<SwitchSceneUtil>() as SceneClickOp;
        menuClickOp = GameSceneController.getInstance() as MenuClickOp;
    }
	
	void Update () {
		
	}

    public void onGUIBtnClick() {
        //Debug.Log("onGUIBtnClick! " + transform.position + " " + this.name);

        if (this.tag.Equals("Stub"))
        {
            int index = transform.GetComponent<Stub>().ID;
            userClickOp.setClickedStubIndex(index);
        }
        else if (this.tag.Equals("BuildBtn"))
        {
            string btnName = this.name;
            if (btnName.Contains("Arrow"))
                userClickOp.buildDrinkTower();
            else if (btnName.Contains("Soldier"))
                userClickOp.buildPizzaTower();
            else if (btnName.Contains("Wizard"))
                userClickOp.buildMelonTower();
            else if (btnName.Contains("Cannon"))
                userClickOp.buildGuandongTower();
            else if (btnName.Contains("Ice"))
                userClickOp.buildIceTower();
        }
        else if (this.tag.Equals("Tower"))
        {
            int index = transform.GetComponent<BaseTowerBehavior>().getID();
            userClickOp.setClickedTowerIndex(index);
        }
        else if (this.tag.Equals("UpgradeBtn"))
        {
            string btnName = this.name;
            if (btnName.Contains("Sell"))
                userClickOp.sellTower();
            else if (btnName.Contains("Upgrade"))
                userClickOp.upgradeTower();
        }
    }

    public void onTitleClickCallBack(string button) {
        if (button == "Start")
        {
//            sceneClickOp.loadLevel(0);
            sceneClickOp.loadLevelSelectScene();
        }
        else if (button == "Quit")
        {
            Application.Quit();
        }
    }

    public void onLevelSelectClickCallBack(string button) {
        if (button == "StartLevel")
        {
            int level = transform.parent.GetChild(1).GetComponent<CardViewManager>().selectedLevel;
            Debug.Log("Starting Lv: " + level);
            sceneClickOp.loadLevel(level);
        }
        else if (button == "ReturnTitle")
        {
            sceneClickOp.loadTitleScene();
        }
    }
       
    public void onSummaryClickCallBack(string button) {
        if (button == "Return")
        {
            sceneClickOp.loadTitleScene();
        }
    }

    public void onMenuClickCallback(string button) {

        if (button == "pauseMenu")
        {
            menuClickOp.pauseGame();
        }
        else if (button == "toTitle")
        {
            sceneClickOp.loadLevel(0);
        }
        else if (button == "cancel")
        {
            menuClickOp.startGame();
        }
    }

}
