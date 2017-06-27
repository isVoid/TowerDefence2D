using Com.TowerDefence2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTowerBehavior : MonoBehaviour, BaseTowerBehavior {

    public CannonTower I;

    private float fireCountDown;

    EnemyFactory enemyFactory;

	// Use this for initialization
	void Awake () {
        I = new CannonTower();
        fireCountDown = I.interval;
        enemyFactory = EnemyFactory.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (fireCountDown <= 0f)
        {
            fire();
            fireCountDown = I.interval;
        }

        fireCountDown -= Time.deltaTime;
	}

    void fire() 
    {
        List<GameObject> enemies = enemyFactory.getAllActiveEnemies();
        foreach (GameObject enemy in enemies)
        {
            Transform loc = enemy.transform;

//            Debug.Log(Vector2.Distance(transform.position, loc.position));

            if (Vector2.Distance(transform.position, loc.position) <= I.range)
            {
                Vector2 currPos = new Vector2(this.gameObject.transform.position.x,
                    this.gameObject.transform.position.y  + 0.5f);

                Vector2 tarPos = loc.position;
                GameObject cannonBall = CannonBallFactory.getInstance().generateCannonBall(currPos, tarPos);
                cannonBall.GetComponent<CannonBallBehavior>().target = enemy;
                break;
            }
        }
    }

    void OnDrawGizmoSelected(){
        //Canvas must be found every frame because we can't get it during Start() or Awake() during edit mode
        Canvas TheCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        Vector3 worldPos;

        RectTransform CanvasTransform = TheCanvas.transform as RectTransform;

        RectTransformUtility.ScreenPointToWorldPointInRectangle(CanvasTransform, transform.position, null, out worldPos);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(worldPos, I.range);
    }

    public void upgrade() {
        I.upgrade();
    }

    public void sell() {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public int valueOf() {
        return I.value;
    }

    public void setID(int id) {
        I.ID = id;
    }

    public int getID() {
        return I.ID;
    }

    public void setStubID(int stubid) {
        I.StubID = stubid;
    }

    public int getStubID() {
        return I.StubID;
    }

}
