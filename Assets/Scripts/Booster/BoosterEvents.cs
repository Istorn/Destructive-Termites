using UnityEngine;
using System.Collections;

public class BoosterEvents : MonoBehaviour {
	void OnMouseDown(){
		transform.parent.gameObject.GetComponent<Booster>().collectBooster();
	}
	
	void FixedUpdate () 
    {
        transform.Rotate (new Vector3 (0, 70, 0) * Time.deltaTime);
    }
	
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {	
	}
}
