using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardViewManager : MonoBehaviour {

    public GameObject cardGroup;
	
    GameData data;
    bool clicked = false;
    Vector3 prevMousePos;

    float cardWidth = 380;
    float slotWidth = 400;

    int maxLevel;
    public int selectedLevel = 0;

    float leftMargin;
    float rightMargin;

    void Awake()
    {
        maxLevel = cardGroup.transform.childCount;
        leftMargin = cardWidth / 2;
        rightMargin = -((cardWidth / 2) + slotWidth * (maxLevel-1));

        data = GameData.getInstance();
    }

    void Start()
    {
        UIStarManager[] starManagers = GetComponentsInChildren<UIStarManager>();
        Card[] cards = GetComponentsInChildren<Card>();

        if (starManagers.Length != data.LevelStar.Length)
        {
            Debug.Log("Level Length Inconsistent!");
            return;
        }
        //Update Star Views according to user previous data.
        for (int i = 0; i < starManagers.Length; i++)
        {
            starManagers[i].updateStarView(data.LevelStar[i]);
            if (data.LevelStar[i] != 0)
            {
                cards[i].finishedLogo.SetActive(true);
            }
        }
    }

    void Update()
    {
        if (!clicked)
        {
            float slotCenX = -selectedLevel * slotWidth;
            Vector3 targetPos = new Vector3(slotCenX, 0, 0);
//            Debug.Log(targetPos);
            cardGroup.GetComponent<RectTransform>().localPosition = 
                Vector3.MoveTowards(cardGroup.GetComponent<RectTransform>().localPosition, targetPos, Time.deltaTime * 400f);
        }
    }

    void OnMouseDown()
    {
        prevMousePos = Input.mousePosition;
        clicked = true;
    }

    void OnMouseDrag()
    {
        Vector3 diff = Input.mousePosition - prevMousePos;
        prevMousePos = Input.mousePosition;


        cardGroup.GetComponent<RectTransform>().localPosition += new Vector3(diff.x, 0, 0);

        float x = cardGroup.GetComponent<RectTransform>().localPosition.x;

        if (x > leftMargin)
        {
            cardGroup.GetComponent<RectTransform>().localPosition = new Vector3(leftMargin, 0, 0);
            x = cardGroup.GetComponent<RectTransform>().localPosition.x;
        }

        if (x < rightMargin)
        {
            cardGroup.GetComponent<RectTransform>().localPosition = new Vector3(rightMargin, 0, 0);
            x = cardGroup.GetComponent<RectTransform>().localPosition.x;
        }

        selectedLevel = -(int)Mathf.Round(x / slotWidth);
//        Debug.Log("Selected: " + selectedLevel);
    }

    void OnMouseUp()
    {
        clicked = false;
    }
}
