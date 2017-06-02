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
