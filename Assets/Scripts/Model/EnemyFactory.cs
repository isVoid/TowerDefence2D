using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {Enemy1};

public class EnemyFactory : SingletonScriptableObject<EnemyFactory> {

    public WaypointManager waypointManager;

    public GameObject Enemy1;
    private List<GameObject> usingEnemy1List = new List<GameObject>();
    private List<GameObject> unusedEnemy1List = new List<GameObject>();

    public void spawn(EnemyType type) {

        switch (type)
        {
            case EnemyType.Enemy1:
                if (unusedEnemy1List.Count == 0)
                {
                    GameObject newEnemy1 = Instantiate(Enemy1, waypointManager.getStart().position, waypointManager.getStart().rotation);
                    usingEnemy1List.Add(newEnemy1);
                }
                else
                {
                    GameObject usedEnemy1 = unusedEnemy1List[0];
                    usingEnemy1List.Add(usedEnemy1);
                    unusedEnemy1List.RemoveAt(0);

                    usedEnemy1.transform.position = waypointManager.getStart().position;
                    usedEnemy1.transform.rotation = waypointManager.getStart().rotation;
                    usedEnemy1.SetActive(true);
                }      
                break;
        }

    }

    private void spawnImpl(GameObject Enemy, List<GameObject> usingEnemyList, List<GameObject> unusedEnemyList)
    {
        if (usingEnemyList.Count == 0)
        {
            GameObject newEnemy = Instantiate(Enemy, waypointManager.getStart().position, waypointManager.getStart().rotation);
            usingEnemy1List.Add(newEnemy);

            newEnemy.SetActive(true);
        }
        else
        {
            GameObject usedEnemy = unusedEnemyList[0];
            usingEnemy1List.Add(usedEnemy);
            unusedEnemy1List.RemoveAt(0);

            usedEnemy.transform.position = waypointManager.getStart().position;
            usedEnemy.transform.rotation = waypointManager.getStart().rotation;
            usedEnemy.SetActive(true);
        }
    }

    public void recycle(GameObject Enemy) {

        EnemyType type = Enemy.GetComponent<Enemy>().myType;
        switch (type)
        {
            case EnemyType.Enemy1:
                recycleImpl(Enemy, usingEnemy1List, unusedEnemy1List);
                break;
        }

    }

    private void recycleImpl(GameObject Enemy, List<GameObject> usingEnemyList, List<GameObject> unusedEnemyList) {
        int index = usingEnemyList.IndexOf(Enemy);

        if (index != -1)
        {
            Enemy.SetActive(false);
            usingEnemyList.RemoveAt(index);
            unusedEnemyList.Add(Enemy);
        }
    }

    public List<GameObject> getAllActiveEnemies(){

        List<GameObject> allEnemies = new List<GameObject>();
        allEnemies.AddRange(usingEnemy1List);

        return allEnemies;
    }
        
}
