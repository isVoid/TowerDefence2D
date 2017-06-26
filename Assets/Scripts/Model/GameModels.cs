using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModels : MonoBehaviour {
    public GameObject stubManager;
    public GameObject BuildBtnGroup;
    public GameObject CannonBallItem;

    private FinanceManager fm;
    private GameData data;

    private Transform[] stubList;

    int lastClickStubIndex = -1;    //记录上一次点击是哪个

    private GameSceneController gameSceneController;

    void Awake() {

        stubList = new Transform[stubManager.transform.childCount];
        Debug.Log(stubManager.transform.childCount);
        for (int i = 0; i < stubManager.transform.childCount; i++)
        {
            Transform stub = stubManager.transform.GetChild(i);
            stub.GetComponent<Stub>().ID = i;
            stubList[i] = stub;
        }

        CannonBallFactory.getInstance().initCannonBallItem(CannonBallItem);

        fm = FinanceManager.getInstance();
        data = new GameData();
    }

    void Start () {
        gameSceneController = GameSceneController.getInstance();
        gameSceneController.setGameModels(this);

        BuildBtnGroup.SetActive(false);
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

    public void buildArrowTower() {
        Debug.Log("buildArrowTower at " + gameSceneController.getChosenStubNum());

            BuildBtnGroup.SetActive(false);
            stubList[gameSceneController.getChosenStubNum()].GetComponent<StubBehavior>().buildArrowTower();
    }

    public void buildSoldierTower() {
        Debug.Log("buildSoldierTower at " + gameSceneController.getChosenStubNum());
        BuildBtnGroup.SetActive(false);
        stubList[gameSceneController.getChosenStubNum()].GetComponent<StubBehavior>().buildSoldierTower();
    }

    public void buildWizardTower() {
        Debug.Log("buildWizardTower at " + gameSceneController.getChosenStubNum());
        BuildBtnGroup.SetActive(false);
        stubList[gameSceneController.getChosenStubNum()].GetComponent<StubBehavior>().buildWizardTower();
    }

    public void buildCannonTower() {
        if (fm.checkBalanceAgainst(data.CannonTowerPrice[0]))
        {
            fm.useMoney(data.CannonTowerPrice[0]);
            Debug.Log("buildCannonTower at " + gameSceneController.getChosenStubNum());
            BuildBtnGroup.SetActive(false);
            stubList[gameSceneController.getChosenStubNum()].GetComponent<StubBehavior>().buildCannonTower();
        }
    }
}
