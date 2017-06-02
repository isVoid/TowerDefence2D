using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour {

    UserClickOp userClickOp;

    void Start () {
        userClickOp = GameSceneController.getInstance() as UserClickOp;

    }
	
	void Update () {
		
	}

    public void onGUIBtnClick() {
        //Debug.Log("onGUIBtnClick! " + transform.position + " " + this.name);

        if (this.tag.Equals("Stub")) {
            string stubName = this.name;
            int index = stubName[stubName.Length - 1] - '0' - 1;
            userClickOp.setClickedStubIndex(index);
        }
        else if (this.tag.Equals("BuildBtn")) {
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
    }
}
