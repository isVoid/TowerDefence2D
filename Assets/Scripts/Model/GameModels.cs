using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModels : MonoBehaviour {

    public int level;

    public GameObject enemySpawner;
    public GameObject stubManager;

    public GameObject BuildBtnGroup;
    public GameObject UpgradeBtnGroup;
    public List<GameObject> CannonBallItems;
    public List<GameObject> EnemyItems;

    public GameObject SummaryGUI;
    public GameObject GameMenu;
    public GameObject MenuGUI;

    public WaypointManager waypointManager;
    private FinanceManager fm;
    private GameData data;

    private Transform[] stubList;
    private List<Transform> towerList;

    int lastClickStubIndex = -1;    //记录上一次点击是哪个
    int lastClickTowerIndex = -1;

    private GameSceneController gameSceneController;

    public float timeScale;

    void Awake() {

        stubList = new Transform[stubManager.transform.childCount];
        towerList = new List<Transform>();
        for (int i = 0; i < stubManager.transform.childCount; i++)
        {
            Transform stub = stubManager.transform.GetChild(i);
            stub.GetComponent<Stub>().ID = i;
            stubList[i] = stub;
        }
            
        CannonBallFactory.getInstance().initCannonBallItem(CannonBallItems);
        EnemyFactory.getInstance().initEnemySprites(EnemyItems);
        EnemyFactory.getInstance().waypointManager = waypointManager;

        fm = FinanceManager.getInstance();
        data = GameData.getInstance();

    }

    void Start () {
        gameSceneController = GameSceneController.getInstance();
        gameSceneController.setGameModels(this);

        data.initLevelData(level);

        fm.setBalance(data.balance);

        Time.timeScale = 1;
        timeScale = Time.timeScale;
    }
	
	void Update () {     
        if (gameSceneController.getGameState() == GameState.Running)
        {
            Time.timeScale = timeScale;
        }
	}

    public void pauseGame()
    {
        enemySpawner.SetActive(false);
        GameMenu.SetActive(false);
        MenuGUI.SetActive(true);

        timeScale = Time.timeScale;
        Time.timeScale = 0;

    }

    public void startGame()
    {
        enemySpawner.SetActive(true);
        GameMenu.SetActive(true);
        MenuGUI.SetActive(false);
         
        Time.timeScale = timeScale;
    }

    public void endGame()
    {
        enemySpawner.SetActive(false);
        GameMenu.SetActive(false);
        SummaryGUI.SetActive(true);

        //Calculate Level End Reward
        int stars = gameSceneController.getCurrentStar();

        //TODO: [?] Determine if the player should be rewarded with/or without previous star count?

        if (stars == 3)
            fm.increaseMoney(1000);
        else if (stars == 2)
            fm.increaseMoney(400);
        else if (stars == 1)
            fm.increaseMoney(250);

        //Persist balance into global
        data.balance = fm.getBalance();
        //Persist stars into global
        data.LevelStar[level] = stars;

    }

    public void failGame()
    {
        enemySpawner.SetActive(false);
        GameMenu.SetActive(false);
        SummaryGUI.SetActive(true);
//        Debug.Log(SummaryGUI.transform.GetChild(1).GetComponent<Text>().text);
//        SummaryGUI.transform.GetChild(1).GetComponent<Text>().text = "失败！";
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
        BaseTowerBehavior towerClicked = towerList[towerIndex].GetComponent<BaseTowerBehavior>();
        int value = towerClicked.value;
        int nextValue = towerClicked.nextValue;

        UpdateBtnGroupManager ubgm = UpgradeBtnGroup.GetComponent<UpdateBtnGroupManager>();
        ubgm.sellPrice.text = "+" + value.ToString("D");
        if (nextValue == int.MaxValue)
            ubgm.upgradePrice.text = "N/A";
        else
            ubgm.upgradePrice.text = nextValue.ToString("D");
        
        Vector3 p = towerList[towerIndex].position;
        p.y += 0.5f;
        UpgradeBtnGroup.transform.position = p;
        lastClickTowerIndex = towerIndex;
    }
 
    public void buildIceTower() {
        if (fm.checkBalanceAgainst(data.IceTowerPrice[0]))
        {
            fm.useMoney(data.IceTowerPrice[0]);
            int stubID = gameSceneController.getChosenStubNum();
            Debug.Log("buildIceTower at " + stubID);
            BuildBtnGroup.SetActive(false);        
            Transform tower = stubList[stubID].GetComponent<StubBehavior>().buildIceTower();
            tower.GetComponent<BaseTowerBehavior>().setStubID(stubID);

            int id = towerList.Count;
            tower.GetComponent<BaseTowerBehavior>().setID(id);
            towerList.Add(tower);
        }
    }

    public void buildDrinkTower() {
        if (fm.checkBalanceAgainst(data.DrinkTowerPrice[0]))
        {
            fm.useMoney(data.DrinkTowerPrice[0]);
            int stubID = gameSceneController.getChosenStubNum();
            Debug.Log("buildDrinkTower at " + stubID);
            BuildBtnGroup.SetActive(false);        
            Transform tower = stubList[stubID].GetComponent<StubBehavior>().buildDrinkTower();
            tower.GetComponent<BaseTowerBehavior>().setStubID(stubID);

            int id = towerList.Count;
            tower.GetComponent<BaseTowerBehavior>().setID(id);
            towerList.Add(tower);
        }
    }

    public void buildPizzaTower() {

        if (fm.checkBalanceAgainst(data.PizzaTowerPrice[0]))
        {
            fm.useMoney(data.PizzaTowerPrice[0]);
            int stubID = gameSceneController.getChosenStubNum();
            Debug.Log("buildPizzaTower at " + stubID);
            BuildBtnGroup.SetActive(false);        
            Transform tower = stubList[stubID].GetComponent<StubBehavior>().buildPizzaTower();
            tower.GetComponent<BaseTowerBehavior>().setStubID(stubID);

            int id = towerList.Count;
            tower.GetComponent<BaseTowerBehavior>().setID(id);
            towerList.Add(tower);
        }
    }

    public void buildMelonTower() {
        if (fm.checkBalanceAgainst(data.MelonTowerPrice[0]))
        {
            fm.useMoney(data.MelonTowerPrice[0]);
            int stubID = gameSceneController.getChosenStubNum();
            Debug.Log("buildMelonTower at " + stubID);
            BuildBtnGroup.SetActive(false);        
            Transform tower = stubList[stubID].GetComponent<StubBehavior>().buildMelonTower();
            tower.GetComponent<BaseTowerBehavior>().setStubID(stubID);

            int id = towerList.Count;
            tower.GetComponent<BaseTowerBehavior>().setID(id);
            towerList.Add(tower);
        }
    }

    public void buildGuandongTower() {
        if (fm.checkBalanceAgainst(data.GuandongTowerPrice[0]))
        {
            fm.useMoney(data.GuandongTowerPrice[0]);
            int stubID = gameSceneController.getChosenStubNum();
            Debug.Log("buildCannonTower at " + stubID);
            BuildBtnGroup.SetActive(false);        
            Transform tower = stubList[stubID].GetComponent<StubBehavior>().buildGuandongTower();
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
            if (currentLv < data.GuandongTowerLevel - 1)
            {
                int price = data.GuandongTowerPrice[currentLv + 1];

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

            //After removal, update all tower's id
            //It will be quick. N < 20;
            for (int i = 0; i < towerList.Count; i++)
            {
                towerList[i].GetComponent<BaseTowerBehavior>().ID = i;
            }

        }
        else
        {
            Debug.Log("Cannot find chosen tower!");
        }
    }

    public void reward(int value)
    {
        fm.increaseMoney(value);
    }
        
}
