using UnityEngine;
using System.Collections;

public class LevelsManager : MonoBehaviour {

	public int level = 1;

	// Use this for initialization
    void Awake()
    {
        //Application.LoadLevel("Level" + level);
        GameObject livello = Instantiate(Resources.Load("Prefabs/Level", typeof(GameObject))) as GameObject;
        livello.GetComponent<Level>().setLevelManager(gameObject);
        livello.GetComponent<Level>().setLevel(level);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
