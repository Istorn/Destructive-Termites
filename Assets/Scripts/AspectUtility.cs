using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System; 

public class AspectUtility : MonoBehaviour
{
    public GameObject container = null;

    public GameObject anchor = null;
    
    public float screenWidthPercentage = 0.2f;

    public List<GameObject> borders = new List<GameObject>();

    float ratio = 2841f / 1336f;

    void Update()
    {
        float w = Convert.ToSingle(Screen.width * screenWidthPercentage);
        float h = w / ratio;
        float scale = Convert.ToSingle((Screen.height / 2.0) / Camera.main.orthographicSize);
        transform.localScale = new Vector3(w / scale, h / scale, 1);

        float w1 = 1440f * w / Screen.width;
        float h1 = w1 / ratio;
        container.GetComponent<RectTransform>().sizeDelta = new Vector2(w1, h1);
        Vector3 pos = Camera.main.ScreenToWorldPoint(anchor.GetComponent<RectTransform>().position);
        transform.position = new Vector3(pos.x, pos.y, -1);

        if (borders.Count > 0)
        {
            float containerW = borders[0].GetComponent<RectTransform>().sizeDelta.x;
            float containerH = borders[0].GetComponent<RectTransform>().sizeDelta.y;
            float sxW = borders[1].GetComponent<RectTransform>().sizeDelta.x;
            float topH = borders[2].GetComponent<RectTransform>().sizeDelta.y;
            borders[1].GetComponent<RectTransform>().sizeDelta = new Vector2(sxW, containerH);
            borders[2].GetComponent<RectTransform>().sizeDelta = new Vector2(w1, topH);
            borders[3].GetComponent<RectTransform>().sizeDelta = new Vector2(containerW - w1 - sxW, containerH);
            borders[4].GetComponent<RectTransform>().sizeDelta = new Vector2(w1, containerH - h1 - topH);
        }
    }
}
