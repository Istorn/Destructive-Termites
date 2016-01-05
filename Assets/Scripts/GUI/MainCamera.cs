using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.ImageEffects;
using System.Threading;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour {

    public Canvas messageBox;

   // private Image infoBar;
    
    private float speed = 5.0f;

    private Vector2 point1, point2;

    private int MOUSE_DRAG_BUTTON = 1;

    private Vector3 mousePos;
    public Texture2D cursorTexture;

    private bool gamePaused = false;
    private bool escPressed = false;

	// Use this for initialization
	void Awake () {
        GameManager.setMainCamer(this);

        GameManager.getLevelGUI();

        GetComponent<BoxCollider2D>().size = OrthographicBounds(GetComponent<Camera>());
	}

    public static Vector2 OrthographicBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        return new Vector2(cameraHeight * screenAspect, cameraHeight);
    }

    void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Costants.CAMERA_MOVEMENT, 0));
        if (Input.GetKey(KeyCode.LeftArrow))
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-Costants.CAMERA_MOVEMENT, 0));
        if (Input.GetKey(KeyCode.DownArrow))
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -Costants.CAMERA_MOVEMENT));
        if (Input.GetKey(KeyCode.UpArrow))
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Costants.CAMERA_MOVEMENT));

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            escPressed = true;
        }

        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(touchDeltaPosition.x * Costants.CAMERA_MOVEMENT, touchDeltaPosition.y * Costants.CAMERA_MOVEMENT));
        }
    }

    public void initalize(Vector3 center)
    {
        setCenter(center);
    }

    public void setCenter(Vector3 center)
    {
        transform.position = center;
    }

    private void changeGameState()
    {
        if (gamePaused)
        {
            GetComponent<Blur>().enabled = true;
            GetComponent<Tonemapping>().enabled = true;
            Time.timeScale = 0f;
        }
        else
        {
            GetComponent<Tonemapping>().enabled = false;
            GetComponent<Blur>().enabled = false;
        }
        GameManager.getLevelGUI().changeGameState(gamePaused);
        gamePaused = !gamePaused;
    }

    void FixedUpdate()
    {
        if (escPressed)
        {
            changeGameState();
            escPressed = false;
        }
    }
}
