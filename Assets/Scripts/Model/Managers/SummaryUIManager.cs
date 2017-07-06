using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryUIManager : MonoBehaviour {

    public Image winLoseImage;
    public Sprite win, lose;

    public void showWin()
    {
        winLoseImage.sprite = win;
    }
    public void showLose()
    {
        winLoseImage.sprite = lose;
    }
}
