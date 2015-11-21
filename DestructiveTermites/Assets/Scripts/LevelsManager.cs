using UnityEngine;
using System.Collections;

public class LevelsManager : MonoBehaviour {

	public int level = 1;

	// Use this for initialization
	void Start () {
        Application.LoadLevel("Level" + level);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
