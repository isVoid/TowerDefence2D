using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public UIStarManager starManager;
    public Text countdownUI;
    public Text currentMoneyUI;

    private GameSceneController controller;

	// Use this for initialization
	void Awake () {
        controller = GameSceneController.getInstance();
        controller.setUIManager(this);
	}
	
    public void updateStarView(int stars)
    {
        starManager.updateStarView(stars);
    }

    public void updateStarViewOnGameFinish()
    {
        starManager.updateStarViewOnGameFinish();
    }

    public void updateCountDownUI(float countDownSec)
    {
        if (countDownSec > 0)
            countdownUI.text = "First Wave: " + countDownSec.ToString("F1");
        else
            countdownUI.gameObject.SetActive(false);
    }

    public void updateBalanceValue(int value)
    {
        currentMoneyUI.text = value.ToString();
    }
}
