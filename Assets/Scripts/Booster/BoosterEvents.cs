using UnityEngine;
using System.Collections;

public class BoosterEvents : MonoBehaviour {
	void OnMouseDown(){
		transform.parent.gameObject.GetComponent<Booster>().collectBooster();
	}
	
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {	
	}
}
