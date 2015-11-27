using UnityEngine;
using System.Collections;
using System;

public class MainCamera : MonoBehaviour {

    private float speed = 5.0f;

    private Vector2 point1, point2;

    private int MOUSE_DRAG_BUTTON = 1;
    private Vector3 mousePos;
    public Texture2D cursorTexture;


    // array for storing if the mouse button is dragging
    bool isDragActive;

    // for remembering if a button was down in previous frame
    bool downInPreviousFrame;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        isDragActive = false;
        downInPreviousFrame = false;
	}
	
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            moveCamera(new Vector3(speed * Time.deltaTime, 0, 0));
        if (Input.GetKey(KeyCode.LeftArrow))
            moveCamera(new Vector3(-speed * Time.deltaTime, 0, 0));
        if (Input.GetKey(KeyCode.DownArrow))
            moveCamera(new Vector3(0, -speed * Time.deltaTime, 0));
        if (Input.GetKey(KeyCode.UpArrow))
            moveCamera(new Vector3(0, speed * Time.deltaTime, 0));

        if (Input.GetMouseButton(MOUSE_DRAG_BUTTON))
        {
            if (downInPreviousFrame)
            {
                if (isDragActive)
                    OnDragging(MOUSE_DRAG_BUTTON);
                else
                {
                    isDragActive = true;
                    OnDraggingStart(MOUSE_DRAG_BUTTON);
                }
            }
            downInPreviousFrame = true;
        }
        else
        {
            if (isDragActive)
            {
                isDragActive = false;
                OnDraggingEnd(MOUSE_DRAG_BUTTON);
            }
            downInPreviousFrame = false;
        }
    }

    private void moveCamera(Vector3 translation)
    {
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
        transform.position = center;
    }

    public virtual void OnDraggingStart(int mouseButton)
    {
        mousePos = Input.mousePosition;
       // Vector2 cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        //Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);//, new Vector2(5, 0), CursorMode.Auto);
        
    }

    public virtual void OnDragging(int mouseButton)
    {
        Vector3 diff = Input.mousePosition - mousePos;
        float dX = Math.Sign(diff.x);
        float dY = Math.Sign(diff.y);

        if (dX > 0)
            moveCamera(new Vector3(speed * Time.deltaTime, 0, 0));
        else
            if (dX < 0)
                moveCamera(new Vector3(-speed * Time.deltaTime, 0, 0));

        if (dY > 0)
            moveCamera(new Vector3(0, speed * Time.deltaTime, 0));
        else
            if (dY < 0)
                moveCamera(new Vector3(0, -speed * Time.deltaTime, 0));
    }

    public virtual void OnDraggingEnd(int mouseButton)
    {
       // Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    /*void OnGUI()
    {

        int cursorSizeX = 50;
        int cursorSizeY = 50;
        //if (isDragActive)
         //   GUI.DrawTexture(new Rect(Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), cursorTexture);
    }*/
}
