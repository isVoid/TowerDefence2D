using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public UIStarManager starManager;
    public SummaryUIManager summaryManager;
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

    public void updateOnWin()
    {
        updateStarViewOnGameFinish();
        summaryManager.showWin();
    }

    public void updateOnLose()
    {
        updateStarViewOnGameFinish();
        summaryManager.showLose();
    }

    public void updateStarViewOnGameFinish()
    {
        starManager.updateStarViewOnGameFinish();
    }

    public void updateCountDownUI(string countdownInfo)
    {
//        if (countDownSec > 0)
//            countdownUI.text = "First Wave: " + countDownSec.ToString("F1");
//        else
//            countdownUI.gameObject.SetActive(false);
        countdownUI.text = countdownInfo;
    }

    public void updateBalanceValue(int value)
    {
        currentMoneyUI.text = value.ToString();
    }
}
