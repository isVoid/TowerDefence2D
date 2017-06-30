using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    public int level;
    public UIStarManager stars;

    float minScale = 1 / 1.5f;

    void Update()
    {
        RectTransform rt = GetComponent<RectTransform>();
        Vector2 screen = Camera.main.WorldToScreenPoint(rt.position);

        float CenDiffX = Mathf.Abs(screen.x - Screen.width / 2);
        float k = (minScale - 1) * (2.0f / Screen.width);
        float s = k * CenDiffX + 1;
        rt.localScale = new Vector3(s, s);
    }
}
