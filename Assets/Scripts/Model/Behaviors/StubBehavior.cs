using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StubBehavior : MonoBehaviour {
    public GameObject CannonTower, ArrowTower, SoldierTower, WizardTower;

    void Start () {     
    }
	
	void Update () {
	}

    public Transform buildArrowTower() {
        GameObject arrowTower = Instantiate(ArrowTower, transform.position, transform.rotation, transform.parent);
        arrowTower.transform.localScale = transform.localScale;
        this.gameObject.SetActive(false);
        return arrowTower.transform;
    }

    public Transform buildSoldierTower() {
        GameObject soldierTower = Instantiate(SoldierTower, transform.position, transform.rotation, transform.parent);
        soldierTower.transform.localScale = transform.localScale;
        this.gameObject.SetActive(false);
        return soldierTower.transform;
    }

    public Transform buildWizardTower() {
        GameObject wizardTower = Instantiate(WizardTower, transform.position, transform.rotation, transform.parent);
        wizardTower.transform.localScale = transform.localScale;
        this.gameObject.SetActive(false);
        return wizardTower.transform;
    }

    public Transform buildCannonTower() {
        GameObject cannonTower = Instantiate(CannonTower, transform.position, transform.rotation, transform.parent);
        cannonTower.transform.localScale = transform.localScale;
        this.gameObject.SetActive(false);
        return cannonTower.transform;
    }
}
