using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseTowerBehavior : MonoBehaviour {

    public Image mImage;
    public Sprite[] levelImages;
    public Sprite[] levelCannonBallImages;

    protected float fireCountDown;

    protected EnemyFactory enemyFactory;

    public int ID;
    public int StubID;
    public TowerType type;

    public int lv;
    public int value;
    public int nextValue;

    public float range = 2.8f;
    public float interval = 2f;

    public int damage;

    protected GameData d;

    protected Transform target;

    // Use this for initialization
    void Awake () {
        mImage = transform.GetComponent<Image>();
        fireCountDown = interval;
        enemyFactory = EnemyFactory.getInstance();

        d = GameData.getInstance();
        loadTowerProperties();
    }

    // Update is called once per frame
    void Update () {
//        base.Update();

        if (fireCountDown <= 0f)
        {
            fire();
            fireCountDown = interval;
        }

        fireCountDown -= Time.deltaTime;
    }

    protected virtual void fire()
    {
        target = null;
        List<GameObject> enemies = enemyFactory.getAllActiveEnemies();
        foreach (GameObject enemy in enemies)
        {
            Transform loc = enemy.transform;

            if (Vector2.Distance(transform.position, loc.position) <= range)
            {
                target = loc;
                break;
            }
        }
    }

    protected abstract void loadTowerProperties();

    public int getLevel()
    {
        return lv;
    }

    public int valueOf() {
        return value;
    }

    public void setID(int id) {
        ID = id;
    }

    public int getID() {
        return ID;
    }

    public void setStubID(int stubid) {
        StubID = stubid;
    }

    public int getStubID() {
        return StubID;
    }

    public void upgrade() {
        lv++;
        loadTowerProperties();
        mImage.sprite = levelImages[lv];
//        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.1f, 1.1f, 1f));
    }

    public void sell() {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected(){
        float Radius = range;
        Transform T = transform.GetComponent<Transform>();
        Gizmos.color = Color.red;
        float theta = 0;
        float x = Radius*Mathf.Cos(theta);
        float y = Radius*Mathf.Sin(theta);
        Vector3 pos = T.position+new Vector3(x,y,0);
        Vector3 newPos = pos;
        Vector3 lastPos = pos;
        for(theta = 0.1f;theta<Mathf.PI*2;theta+=0.1f){
            x = Radius*Mathf.Cos(theta);
            y = Radius*Mathf.Sin(theta);
            newPos = T.position+new Vector3(x,y,0);
            Gizmos.DrawLine(pos,newPos);
            pos = newPos;
        }
        Gizmos.DrawLine(pos,lastPos);
    }
}
