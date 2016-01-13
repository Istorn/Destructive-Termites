using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using UnityEngine.UI;
using CnControls;

public class MainCamera : MonoBehaviour {

    public Canvas messageBox;

   // private Image infoBar;
    
    private float speed = 5.0f;

    private Vector2 point1, point2;

    private int MOUSE_DRAG_BUTTON = 1;

    private Vector3 mousePos;

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


        #if UNITY_IPHONE || UNITY_ANDROID
            Vector2 camMove = new Vector2(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"));
            GetComponent<Rigidbody2D>().AddForce(new Vector2(camMove.x * Costants.CAMERA_MOVEMENT, camMove.y * Costants.CAMERA_MOVEMENT));
        #endif
/*
        if ((Input.GetMouseButtonDown(0)) || ((Input.touchCount == 1)))
        {
            GameManager.getLevelGUI().gameObject.transform.Find("BottomBarPanel/FirstPhasePanel/Instructions").GetComponent<Text>().text = "STOP 0";
            // Construct a ray from the current touch coordinates

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);// (Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(pos.x, pos.y), Vector2.zero, 0f);
            hit.transform.parent.gameObject.GetComponent<GenericObject>().select();*/
            /*if (hit.Length > 0)
            {
                GameObject selected = hit[0].transform.parent.gameObject;
                for (int i = 1; i < hit.Length; i++)
                {
                    GameObject par = hit[i].transform.parent.gameObject;
                    GameManager.getLevelGUI().gameObject.transform.Find("BottomBarPanel/FirstPhasePanel/Instructions").GetComponent<Text>().text = GameManager.getLevelGUI().gameObject.transform.Find("BottomBarPanel/FirstPhasePanel/Instructions").GetComponent<Text>().text +  " " +par.name;

                    if (par.transform.position.z < selected.transform.position.z)
                        selected = par;
                }
                Text t = GameManager.getLevelGUI().gameObject.transform.Find("BottomBarPanel/FirstPhasePanel/Instructions").GetComponent<Text>();
                for(int i = 0; i < selected.transform.Find("Object").GetComponent<PolygonCollider2D>().points.Length;  i++)
                {

                    t.text = t.text + " " + selected.transform.Find("Object").GetComponent<PolygonCollider2D>().points[i];
                }
                t.text = selected.transform.Find("Object").GetComponent<PolygonCollider2D>().points.Length + "";
                selected.GetComponent<GenericObject>().select();
            }*/
            

          /*  if (hit.collider != null) {
                GameManager.getLevelGUI().gameObject.transform.Find("BottomBarPanel/FirstPhasePanel/Instructions").GetComponent<Text>().text = hit.collider.transform.parent.name+ "   " + hit.collider.gameObject.name;
                hit.collider.gameObject.transform.parent.GetComponent<GenericObject>().select();
            }
         }
        else
        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved)
            if (!GameManager.getIsSelectinObject())
            {
                Vector2 touchDeltaPosition = -Input.GetTouch(0).deltaPosition;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(touchDeltaPosition.x * Costants.CAMERA_MOVEMENT, touchDeltaPosition.y * Costants.CAMERA_MOVEMENT));
            }*/
    }

    public void initalize(Vector3 center)
    {
        setCenter(center);
    }

    public void setCenter(Vector3 center)
    {
        transform.position = center;
    }

    void FixedUpdate()
    {
        if (escPressed)
        {
            GameManager.changeGameState();
            escPressed = false;
        }
    }

    public void stopMoving()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
    }
}
