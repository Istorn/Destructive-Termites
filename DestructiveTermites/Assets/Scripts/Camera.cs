using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    private float speed = 5.0f;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        transform.position = new Vector3(
           Mathf.Clamp(transform.position.x, -5, 5),
           Mathf.Clamp(transform.position.y, -5, 5),
           Mathf.Clamp(transform.position.z, -10, 10));
    }

 
}
