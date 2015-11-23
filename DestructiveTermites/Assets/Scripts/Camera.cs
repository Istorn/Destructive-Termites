using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    private float speed = 3.0f;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
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

    private void moveCamera(Vector3 newPosition)
    {
       transform.Translate(new Vector3(
           Mathf.Clamp(newPosition.x, -5, 5),
           Mathf.Clamp(newPosition.y, -5, 5),
           Mathf.Clamp(newPosition.z, -10, 10)));
    }
}
