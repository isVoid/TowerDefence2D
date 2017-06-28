using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StubBehavior : MonoBehaviour {
    public GameObject GuandongTower, PizzaTower, DrinkTower, MelonTower, IceTower;

    void Start () {     
    }
	
	void Update () {
	}

    public Transform buildIceTower() {
        GameObject arrowTower = Instantiate(IceTower, transform.position, transform.rotation, transform.parent);
        arrowTower.transform.localScale = transform.localScale;
        this.gameObject.SetActive(false);
        return arrowTower.transform;
    }

    public Transform buildDrinkTower() {
        GameObject arrowTower = Instantiate(DrinkTower, transform.position, transform.rotation, transform.parent);
        arrowTower.transform.localScale = transform.localScale;
        this.gameObject.SetActive(false);
        return arrowTower.transform;
    }

    public Transform buildPizzaTower() {
        GameObject soldierTower = Instantiate(PizzaTower, transform.position, transform.rotation, transform.parent);
        soldierTower.transform.localScale = transform.localScale;
        this.gameObject.SetActive(false);
        return soldierTower.transform;
    }

    public Transform buildMelonTower() {
        GameObject wizardTower = Instantiate(MelonTower, transform.position, transform.rotation, transform.parent);
        wizardTower.transform.localScale = transform.localScale;
        this.gameObject.SetActive(false);
        return wizardTower.transform;
    }

    public Transform buildGuandongTower() {
        GameObject cannonTower = Instantiate(GuandongTower, transform.position, transform.rotation, transform.parent);
        cannonTower.transform.localScale = transform.localScale;
        this.gameObject.SetActive(false);
        return cannonTower.transform;
    }
}
