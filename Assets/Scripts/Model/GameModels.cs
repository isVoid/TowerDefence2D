using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModels : MonoBehaviour {
    public GameObject stubManager;
    public GameObject BuildBtnGroup;
    public GameObject UpgradeBtnGroup;
    public GameObject CannonBallItem;

    private FinanceManager fm;
    private GameData data;

    private Transform[] stubList;
    private List<Transform> towerList;

    int lastClickStubIndex = -1;    //记录上一次点击是哪个
    int lastClickTowerIndex = -1;

    private GameSceneController gameSceneController;

    void Awake() {

        stubList = new Transform[stubManager.transform.childCount];
        towerList = new List<Transform>();
        for (int i = 0; i < stubManager.transform.childCount; i++)
        {
            Transform stub = stubManager.transform.GetChild(i);
            stub.GetComponent<Stub>().ID = i;
            stubList[i] = stub;
        }

        CannonBallFactory.getInstance().initCannonBallItem(CannonBallItem);

        fm = FinanceManager.getInstance();
        data = GameData.getInstance();
    }

    void Start () {
        gameSceneController = GameSceneController.getInstance();
        gameSceneController.setGameModels(this);
    }
	
	void Update () {
		
	}

    public void setBuildBtnGroupPos(int stubIndex) {
        if (!BuildBtnGroup.activeInHierarchy) {
            BuildBtnGroup.SetActive(true);
        }
        else {
            if (lastClickStubIndex == stubIndex) {    //两次点击同一个则消失
                BuildBtnGroup.SetActive(false);
                return;
            }
        }
        BuildBtnGroup.transform.position = stubList[stubIndex].position;
        lastClickStubIndex = stubIndex;
    }

    public void setUpgradeBtnGroupPos(int towerIndex) {
        if (!UpgradeBtnGroup.activeInHierarchy) {
            UpgradeBtnGroup.SetActive(true);
        }
        else {
            if (lastClickTowerIndex == towerIndex) {    //两次点击同一个则消失
                UpgradeBtnGroup.SetActive(false);
                return;
            }
        }

        UpgradeBtnGroup.transform.position = towerList[towerIndex].position;
        lastClickTowerIndex = towerIndex;
    }

    public void buildArrowTower() {
        int stubID = gameSceneController.getChosenStubNum();
        Debug.Log("buildArrowTower at " + stubID);
        BuildBtnGroup.SetActive(false);
        Transform tower = stubList[stubID].GetComponent<StubBehavior>().buildArrowTower();
        tower.GetComponent<BaseTowerBehavior>().setStubID(stubID);

        int id = towerList.Count;
        //TODO: Set ID in tower

        towerList.Add(tower);
    }

    public void buildSoldierTower() {

        int stubID = gameSceneController.getChosenStubNum();
        Debug.Log("build SoldierTower at " + stubID);
        BuildBtnGroup.SetActive(false);
        Transform tower = stubList[stubID].GetComponent<StubBehavior>().buildSoldierTower();
        tower.GetComponent<BaseTowerBehavior>().setStubID(stubID);

        int id = towerList.Count;
        //TODO: Set ID in tower

        towerList.Add(tower);
    }

    public void buildWizardTower() {
        int stubID = gameSceneController.getChosenStubNum();
        Debug.Log("build WizardTower at " + stubID);
        BuildBtnGroup.SetActive(false);
        Transform tower = stubList[stubID].GetComponent<StubBehavior>().buildWizardTower();
        tower.GetComponent<BaseTowerBehavior>().setStubID(stubID);

        int id = towerList.Count;
        //TODO: Set ID in tower

        towerList.Add(tower);
    }

    public void buildCannonTower() {
        if (fm.checkBalanceAgainst(data.CannonTowerPrice[0]))
        {
            fm.useMoney(data.CannonTowerPrice[0]);
            int stubID = gameSceneController.getChosenStubNum();
            Debug.Log("buildCannonTower at " + stubID);
            BuildBtnGroup.SetActive(false);        
            Transform tower = stubList[stubID].GetComponent<StubBehavior>().buildCannonTower();
            tower.GetComponent<BaseTowerBehavior>().setStubID(stubID);

            int id = towerList.Count;
            tower.GetComponent<BaseTowerBehavior>().setID(id);
            towerList.Add(tower);
        }
    }

    public void upgradeTower() {
        int id = gameSceneController.getChosenTowerNum();
        Debug.Log("Upgrading!" + id + "th Tower!");
        Transform chosenTower = null;
        for (int i = 0; i < towerList.Count; i++)
        {
            if (towerList[id].GetComponent<BaseTowerBehavior>().getID() == id)
                chosenTower = towerList[id];
        }
        if (chosenTower != null)
        {
            int currentLv = chosenTower.GetComponent<BaseTowerBehavior>().getLevel();
            if (currentLv < data.CannonTowerLevel - 1)
            {
                int price = data.CannonTowerPrice[currentLv + 1];

                if (fm.checkBalanceAgainst(price))
                {
                    fm.useMoney(price);
                    chosenTower.GetComponent<BaseTowerBehavior>().upgrade();
                    UpgradeBtnGroup.SetActive(false);
                }
                else
                {
                    Debug.Log("Not enough Money!");
                }
            }
            else
            {
                Debug.Log("Level Max out!");
            }
        }
        else
        {
            Debug.Log("Cannot find chosen tower!");
        }

    }

    public void sellTower() {

        int id = gameSceneController.getChosenTowerNum();
        Transform chosenTower = null;
        for (int i = 0; i < towerList.Count; i++)
        {
            if (towerList[id].GetComponent<BaseTowerBehavior>().getID() == id)
                chosenTower = towerList[id];
        }
        if (chosenTower != null)
        {
            int stubid = chosenTower.GetComponent<BaseTowerBehavior>().getStubID();
            int value = chosenTower.GetComponent<BaseTowerBehavior>().valueOf();
            fm.increaseMoney(value);

            chosenTower.GetComponent<BaseTowerBehavior>().sell();
            towerList.Remove(chosenTower);

            UpgradeBtnGroup.SetActive(false);
            stubList[stubid].gameObject.SetActive(true);

        }
        else
        {
            Debug.Log("Cannot find chosen tower!");
        }
    }
}
