using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStarManager : MonoBehaviour {

    public Sprite UIStar, UIGrayStar;
    public Transform[] UIStars;

    void Awake() {
        UIStars = new Transform[transform.childCount];

        for (int i = 0; i < UIStars.Length; i++)
        {
            UIStars[i] = transform.GetChild(i);
        }
    }

    public void updateStarView(int star)
    {
        if (star > UIStars.Length)
        {
            Debug.Log("Err: Star Num larger than UI Star Num!");
            return;
        }
        for (int i = 0; i < UIStars.Length; i++)
        {
            if (i < star)
            {
                UIStars[i].GetComponent<Image>().sprite = UIStar;
            }
            else
            {
                UIStars[i].GetComponent<Image>().sprite = UIGrayStar;
            }
                
        }

    }

    public void updateStarViewOnGameFinish()
    {
        UIStars[0].parent.GetComponent<RectTransform>().localPosition = new Vector3(0, 160, 0);
    }
}
