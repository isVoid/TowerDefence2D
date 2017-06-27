using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneUtil : MonoBehaviour, SceneClickOp {

    private string titleScene = "GameTitle";
    private string[] levels = {
        "Level1"
    };

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		
	}

    public void loadTitleScene() {
        SceneManager.LoadScene(titleScene, LoadSceneMode.Single);
    }

    public void loadLevel(int level)
    {
        if (level < levels.Length)
            SceneManager.LoadScene(levels[level], LoadSceneMode.Single);
        else
            Debug.Log("Load Scene Failed");
    }
}
