using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum StubType { FlatGround, ArrowTower, SoldierTower, WizardTower, CannonTower };

public class StubBehavior : MonoBehaviour {
    public Sprite ArrowTowerItem, SoldierTowerItem, WizardTowerItem, CannonTowerItem;

    StubType stubType = StubType.FlatGround;
    Image myImage;

    void Start () {
        myImage = this.gameObject.GetComponent<Image>();
        
    }
	
	void Update () {
        detectKeyboardInput();
	}

    void detectKeyboardInput() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (stubType == StubType.CannonTower) {
                Debug.Log(this.gameObject.name + " Fire");
                Vector2 currPos = new Vector2(this.gameObject.transform.position.x,
                    this.gameObject.transform.position.y  + 0.5f);

                int dirY = Random.Range(-1, 2);
                Debug.Log("dirY " + dirY);
                Vector2 tarPos = new Vector2(this.gameObject.transform.position.x + 1.5f, 
                    this.gameObject.transform.position.y + 1.0f * (float)dirY);
                GameObject cannonBall = CannonBallFactory.getInstance().generateCannonBall(currPos, tarPos);
            }
        }
    }

    public void buildArrowTower() {
        stubType = StubType.ArrowTower;
        myImage.sprite = ArrowTowerItem;
    }

    public void buildSoldierTower() {
        stubType = StubType.SoldierTower;
        myImage.sprite = SoldierTowerItem;
    }

    public void buildWizardTower() {
        stubType = StubType.WizardTower;
        myImage.sprite = WizardTowerItem;
    }

    public void buildCannonTower() {
        stubType = StubType.CannonTower;
        myImage.sprite = CannonTowerItem;
    }
}
