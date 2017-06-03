using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.TowerDefence2d {
    public class CannonBallFactory : System.Object {
        private static CannonBallFactory instance;

        private GameObject CannonBallItem;
        private List<GameObject> usingCannonBallList = new List<GameObject>();
        private List<GameObject> unusedCannonBallList = new List<GameObject>();

        public static CannonBallFactory getInstance() {
            if (instance == null)
                instance = new CannonBallFactory();
            return instance;
        }

        public void initCannonBallItem(GameObject CannonBall) {
            CannonBallItem = CannonBall;
        }

        public GameObject generateCannonBall(Vector2 currentPos, Vector2 targetPos) {
            if (unusedCannonBallList.Count == 0) {    //没有存储
                GameObject newCannonBall = Camera.Instantiate(CannonBallItem);
                newCannonBall.GetComponent<CannonBallBehavior>().initTwoPos(currentPos, targetPos);
                usingCannonBallList.Add(newCannonBall);
                return newCannonBall;
            }
            else {                      //有存储 
                GameObject oldCannonBall = unusedCannonBallList[0];
                unusedCannonBallList.RemoveAt(0);
                oldCannonBall.GetComponent<CannonBallBehavior>().initTwoPos(currentPos, targetPos);
                oldCannonBall.SetActive(true);
                usingCannonBallList.Add(oldCannonBall);
                return oldCannonBall;
            }
        }

        public void recycleCannonBall(GameObject CannonBall) {
            int index = usingCannonBallList.IndexOf(CannonBall);
            if (index != -1) {
                usingCannonBallList[index].SetActive(false);
                unusedCannonBallList.Add(usingCannonBallList[index]);
                usingCannonBallList.RemoveAt(index);
            }
        }
    }
}
