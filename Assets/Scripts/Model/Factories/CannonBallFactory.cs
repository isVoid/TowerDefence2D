using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.TowerDefence2d {
    public class CannonBallFactory : System.Object {
        private static CannonBallFactory instance;

        private GameObject GuandongBallItem;
        private List<GameObject> usingGuandongBallList = new List<GameObject>();
        private List<GameObject> unusedGuandongBallList = new List<GameObject>();

        private GameObject MelonBallItem;
        private List<GameObject> usingMelonBallList = new List<GameObject>();
        private List<GameObject> unusedMelonBallList = new List<GameObject>();

        private GameObject PizzaBallItem;
        private List<GameObject> usingPizzaBallList = new List<GameObject>();
        private List<GameObject> unusedPizzaBallList = new List<GameObject>();

        private GameObject IceBallItem;
        private List<GameObject> usingIceBallList = new List<GameObject>();
        private List<GameObject> unusedIceBallList = new List<GameObject>();

        private GameObject DrinkBallItem;
        private List<GameObject> usingDrinkBallList = new List<GameObject>();
        private List<GameObject> unusedDrinkBallList = new List<GameObject>();

        public static CannonBallFactory getInstance() {
            if (instance == null)
                instance = new CannonBallFactory();
            return instance;
        }

        public void initCannonBallItem(List<GameObject> CannonBall) {
            GuandongBallItem = CannonBall[0];
            MelonBallItem = CannonBall[1];
            PizzaBallItem = CannonBall[2];
            IceBallItem = CannonBall[3];
            DrinkBallItem = CannonBall[4];
        }
            
        public GameObject generateCannonBall(Vector2 currentPos, Vector2 targetPos, BallType type) {
            GameObject ball = null;
            switch (type)
            {
                case BallType.GuandongBall:
                    ball = generateImpl(GuandongBallItem, usingGuandongBallList, unusedGuandongBallList);
                    break;
                case BallType.MelonBall:
                    ball = generateImpl(MelonBallItem, usingMelonBallList, unusedMelonBallList);
                    break;
                case BallType.PizzaBall:
                    ball = generateImpl(PizzaBallItem, usingPizzaBallList, unusedPizzaBallList);
                    break;
                case BallType.DrinkBall:
                    ball = generateImpl(DrinkBallItem, usingDrinkBallList, unusedDrinkBallList);
                    break;
                case BallType.IceBall:
                    ball = generateImpl(IceBallItem, usingIceBallList, unusedIceBallList);
                    break;
            }
            if (ball != null)
            {
                ball.GetComponent<BaseBallBehavior>().initTwoPos(currentPos, targetPos);
                ball.GetComponent<BaseBallBehavior>().type = type;
            }
            else
            {
                Debug.Log("Init Ball Error!");
            }
            return ball;
        }

        private GameObject generateImpl(GameObject ball, List<GameObject> usingBallList, List<GameObject> unusedBallList)
        {
            if (unusedBallList.Count == 0) {    //没有存储
                GameObject newCannonBall = Camera.Instantiate(ball);
                usingBallList.Add(newCannonBall);
                return newCannonBall;
            }
            else {                      //有存储 
                GameObject oldCannonBall = unusedBallList[0];
                unusedBallList.RemoveAt(0);
                oldCannonBall.SetActive(true);
                usingBallList.Add(oldCannonBall);
                return oldCannonBall;
            }
        }

        public void recycleCannonBall(GameObject CannonBall) 
        {
            BallType type = CannonBall.GetComponent<BaseBallBehavior>().type;
            switch (type)
            {
                case BallType.GuandongBall:
                    recycleImpl(CannonBall, usingGuandongBallList, unusedGuandongBallList);
                    break;
                case BallType.MelonBall:
                    recycleImpl(CannonBall, usingMelonBallList, unusedMelonBallList);
                    break;
                case BallType.PizzaBall:
                    recycleImpl(CannonBall, usingPizzaBallList, unusedPizzaBallList);
                    break;
                case BallType.DrinkBall:
                    recycleImpl(CannonBall, usingDrinkBallList, unusedDrinkBallList);
                    break;
                case BallType.IceBall:
                    recycleImpl(CannonBall, usingIceBallList, unusedIceBallList);
                    break;
            }
        }

        private void recycleImpl(GameObject ball, List<GameObject> usingBallList, List<GameObject> unusedBallList)
        {
            int index = usingBallList.IndexOf(ball);
            if (index != -1) {
                usingBallList[index].SetActive(false);
                unusedBallList.Add(usingBallList[index]);
                usingBallList.RemoveAt(index);
            }
        }
    }
}
