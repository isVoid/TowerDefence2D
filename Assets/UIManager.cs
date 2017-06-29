using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public UIStarManager starManager;

    private GameSceneController controller;

	// Use this for initialization
	void Start () {
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
}
