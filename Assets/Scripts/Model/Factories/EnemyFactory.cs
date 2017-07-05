using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : System.Object {

    private static EnemyFactory instance;
    public static EnemyFactory getInstance()
    {
        if (instance == null)
            instance = new EnemyFactory();

        return instance;
    }

    public void initEnemySprites(List<GameObject> enemySprites)
    {
        Enemy1 = enemySprites[0];
        Enemy2 = enemySprites[1];
        Enemy3 = enemySprites[2];
        Enemy4 = enemySprites[3];
        PostGrad = enemySprites[4];
        Exchange = enemySprites[5];
    }

    public WaypointManager waypointManager;

    public GameObject Enemy1;
    private List<GameObject> usingEnemy1List = new List<GameObject>();
    private List<GameObject> unusedEnemy1List = new List<GameObject>();

    public GameObject Enemy2;
    private List<GameObject> usingEnemy2List = new List<GameObject>();
    private List<GameObject> unusedEnemy2List = new List<GameObject>();

    public GameObject Enemy3;
    private List<GameObject> usingEnemy3List = new List<GameObject>();
    private List<GameObject> unusedEnemy3List = new List<GameObject>();

    public GameObject Enemy4;
    private List<GameObject> usingEnemy4List = new List<GameObject>();
    private List<GameObject> unusedEnemy4List = new List<GameObject>();

    public GameObject PostGrad;
    private List<GameObject> usingPostGradList = new List<GameObject>();
    private List<GameObject> unusedPostGradList = new List<GameObject>();

    public GameObject Exchange;
    private List<GameObject> usingExchangeList = new List<GameObject>();
    private List<GameObject> unusedExchangeList = new List<GameObject>();

    public void wipeFactory()
    {
        List<GameObject> ListOfAllEnemies = new List<GameObject>();
        ListOfAllEnemies.AddRange(getAllActiveEnemies());
        ListOfAllEnemies.AddRange(getAllUnActiveEnemies());

        foreach (GameObject e in ListOfAllEnemies)
        {
            Camera.Destroy(e);
        }

        usingEnemy1List.Clear();
        unusedEnemy1List.Clear();

        usingEnemy2List.Clear();
        unusedEnemy2List.Clear();

        usingEnemy3List.Clear();
        unusedEnemy3List.Clear();

        usingEnemy4List.Clear();
        unusedEnemy4List.Clear();

        usingPostGradList.Clear();
        unusedPostGradList.Clear();

        usingExchangeList.Clear();
        unusedPostGradList.Clear();

    }

    public void spawn(EnemyType type) {

        Debug.Log("Factory: Spawning " + type );
        switch (type)
        {
            case EnemyType.Enemy1:  
                spawnImpl(Enemy1, usingEnemy1List, unusedEnemy1List);
                break;
            case EnemyType.Enemy2:  
                spawnImpl(Enemy2, usingEnemy2List, unusedEnemy2List);
                break;
            case EnemyType.Enemy3:  
                spawnImpl(Enemy3, usingEnemy3List, unusedEnemy3List);
                break;
            case EnemyType.Enemy4:  
                spawnImpl(Enemy4, usingEnemy4List, unusedEnemy4List);
                break;
            case EnemyType.PostGrad:
                spawnImpl(PostGrad, usingPostGradList, unusedPostGradList);
                break;
            case EnemyType.Exchange:
                spawnImpl(Exchange, usingExchangeList, unusedExchangeList);
                break;
        }

    }

    private void spawnImpl(GameObject Enemy, List<GameObject> usingEnemyList, List<GameObject> unusedEnemyList)
    {
        //If no spawned unactive gameobject, instantiate new.
        if (unusedEnemyList.Count == 0)
        {
            GameObject newEnemy = Camera.Instantiate(Enemy, waypointManager.getStartPos(), Quaternion.identity);
            usingEnemyList.Add(newEnemy);

            newEnemy.SetActive(true);
        }
        else
        {
            GameObject usedEnemy = unusedEnemyList[0];
            usingEnemyList.Add(usedEnemy);
            unusedEnemyList.RemoveAt(0);

            usedEnemy.transform.position = waypointManager.getStartPos();
//            usedEnemy.transform.rotation = waypointManager.getStart().rotation;
            usedEnemy.transform.rotation = Quaternion.identity;
            usedEnemy.SetActive(true);
        }
    }

    public void recycle(GameObject Enemy) {

//        Debug.Log("Recycle: Using: " + usingEnemy1List.Count + " Ununsed: " + unusedEnemy1List.Count);

        EnemyType type = Enemy.GetComponent<Enemy>().myType;
        switch (type)
        {
            case EnemyType.Enemy1:
                recycleImpl(Enemy, usingEnemy1List, unusedEnemy1List);
                break;
            case EnemyType.Enemy2:
                recycleImpl(Enemy, usingEnemy2List, unusedEnemy2List);
                break;
            case EnemyType.Enemy3:
                recycleImpl(Enemy, usingEnemy3List, unusedEnemy3List);
                break;
            case EnemyType.Enemy4:
                recycleImpl(Enemy, usingEnemy4List, unusedEnemy4List);
                break;
            case EnemyType.PostGrad:
                recycleImpl(Enemy, usingPostGradList, unusedPostGradList);
                break;
            case EnemyType.Exchange:
                recycleImpl(Enemy, usingExchangeList, unusedExchangeList);
                break;
        }

    }

    private void recycleImpl(GameObject Enemy, List<GameObject> usingEnemyList, List<GameObject> unusedEnemyList) {
        int index = usingEnemyList.IndexOf(Enemy);

        if (index != -1)
        {
            Enemy.transform.position = new Vector3(11, 5, 0);
            Enemy.SetActive(false);
            usingEnemyList.RemoveAt(index);
            unusedEnemyList.Add(Enemy);
        }
    }

    public List<GameObject> getAllActiveEnemies(){

        List<GameObject> allEnemies = new List<GameObject>();
        allEnemies.AddRange(usingEnemy1List);
        allEnemies.AddRange(usingEnemy2List);
        allEnemies.AddRange(usingEnemy3List);
        allEnemies.AddRange(usingEnemy4List);
        allEnemies.AddRange(usingPostGradList);
        allEnemies.AddRange(usingExchangeList);

        return allEnemies;
    }

    public List<GameObject> getAllUnActiveEnemies()
    {
        List<GameObject> allUnactiveEnemies = new List<GameObject>();

        allUnactiveEnemies.AddRange(unusedEnemy1List);
        allUnactiveEnemies.AddRange(unusedEnemy2List);
        allUnactiveEnemies.AddRange(unusedEnemy3List);
        allUnactiveEnemies.AddRange(unusedEnemy4List);
        allUnactiveEnemies.AddRange(unusedPostGradList);
        allUnactiveEnemies.AddRange(unusedExchangeList);

        return allUnactiveEnemies;

    }

    public bool allSpriteRecycled()
    {
        return getAllActiveEnemies().Count == 0;
    }

    public void applyConstantRangeDamage(Vector2 damagePos, float range, float damage)
    {
        List<GameObject> allEnemies = getAllActiveEnemies();
        foreach (GameObject enemy in allEnemies)
        {
            Vector2 ePos = enemy.transform.position;
            if (Vector2.Distance(damagePos, ePos) <= range)
            {
                enemy.GetComponent<Enemy>().hpMinus(damage);
            }
        }
    }

    public void applyRangeBleedBuf(Vector2 damagePos, float range, float bleedTime, float bleedDamage)
    {
        List<GameObject> allEnemies = getAllActiveEnemies();
        foreach (GameObject enemy in allEnemies)
        {
            Vector2 ePos = enemy.transform.position;
            if (Vector2.Distance(damagePos, ePos) <= range)
            {
                enemy.GetComponent<Enemy>().applyBleedBuf(bleedTime, bleedDamage);
            }
        }
    }
}
