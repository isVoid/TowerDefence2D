using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseTowerBehavior : MonoBehaviour {

    public Image mImage;
    //    public Sprite[] levelImages;

    protected float fireCountDown;

    protected EnemyFactory enemyFactory;

    public int ID;
    public int StubID;

    public int lv;
    public int value;

    public float range = 2.8f;
    public float interval = 2f;

    public int damage;

    GameData d;

    protected Transform target;

    // Use this for initialization
    void Awake () {
        mImage = transform.GetComponent<Image>();
        fireCountDown = interval;
        enemyFactory = EnemyFactory.getInstance();
    }

    // Update is called once per frame
    void Update () {

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

//            Debug.Log(Vector2.Distance(transform.position, loc.position) + " " + range);
            if (Vector2.Distance(transform.position, loc.position) <= range)
            {
                target = loc;
                break;
            }
        }
    }

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
        //        mImage.sprite = levelImages[I.lv];
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.1f, 1.1f, 1f));
    }

    public void sell() {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
