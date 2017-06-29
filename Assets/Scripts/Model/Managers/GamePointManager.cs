using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePointManager : System.Object {

    private static GamePointManager instance;
    private GamePointManager() {

    }
    public static GamePointManager getInstance()
    {
        if (instance == null)
        {
            instance = new GamePointManager();
        }
        return instance;
    }

    public int CurrentStar = 3;

    public bool starIsZero()
    {
        return CurrentStar == 0;
    }

    public void sufferDamage(int num)
    {
        if (CurrentStar - num >= 0)
            CurrentStar -= num;
        else
            Debug.Log("Current Star Less than zero!");
    }

}
