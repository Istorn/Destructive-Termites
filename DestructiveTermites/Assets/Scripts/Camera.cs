using UnityEngine;
using System.Collections;
using System;

public class Camera : MonoBehaviour {

    private float speed = 5.0f;
    private GameObject border;
    private Vector3 center;
    private Vector2 point1, point2;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        border = Instantiate(Resources.Load("Prefabs/Test", typeof(GameObject))) as GameObject;
	}
	

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveCamera(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveCamera(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveCamera(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveCamera(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }

    private void moveCamera(Vector3 translation)
    {
        /*Debug.Log("OLD: " + translation);
        float l = cameraSpriteRenderer.bounds.min.x + translation.x;
        float r = cameraSpriteRenderer.bounds.max.x + translation.x;

        float t = cameraSpriteRenderer.bounds.max.y + translation.y;
        float b = cameraSpriteRenderer.bounds.min.y + translation.y;

        Debug.Log(l + " | " + r + "|" + t + "|" + b);
        if (l < borderSpriteRenderer.bounds.min.x)
            translation.x = 0; //borderRect.rect.xMin - cameraRect.rect.xMin;
        else
            if (r > borderSpriteRenderer.bounds.max.x)
                translation.x = 0; // borderRect.rect.xMax - cameraRect.rect.xMax;
      /*  if (t < border.transform.position.y + borderRect.rect.height/2)
            translation.y = translation.y - Math.Abs(t - borderRect.rect.yMax);
        else
            if (b < border.transform.position.y - borderRect.rect.height/2)
                translation.y = translation.y + Math.Abs(b - borderRect.rect.yMin);
        Debug.Log("NEW: " + translation);
        */
       transform.Translate(new Vector3(
           Mathf.Clamp(translation.x, -5, 5 ),
           Mathf.Clamp(translation.y, -5, 5),
           Mathf.Clamp(translation.z, -10, 10)));

       transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, point1.x, point2.x),
          Mathf.Clamp(transform.position.y, point1.y, point2.y),
          Mathf.Clamp(transform.position.z, -10.0f, 10.0f));
    }

    public void setBouds(Vector2 point1, Vector2 point2)
    {
        this.point1 = point1;
        this.point2 = point2;
    }

    public void setCenter(Vector3 center)
    {
        this.center = center;
        transform.position = center;
    }
}
