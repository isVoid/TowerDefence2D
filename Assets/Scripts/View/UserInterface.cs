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
                userClickOp.buildArrowTower();
            else if (btnName.Contains("Soldier"))
                userClickOp.buildSoldierTower();
            else if (btnName.Contains("Wizard"))
                userClickOp.buildWizardTower();
            else if (btnName.Contains("Cannon"))
                userClickOp.buildCannonTower();
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
            sceneClickOp.loadLevel(0);
        }
        else if (button == "Quit")
        {
            Application.Quit();
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
