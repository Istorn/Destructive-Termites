using UnityEngine;
using System.Collections;

public class LevelsManager : MonoBehaviour {

	public int levelNumber = 1;

	// Use this for initialization
    void Awake()
    {
        //Application.LoadLevel("Level" + level);
        GameObject levelGameObject = Instantiate(Resources.Load("Prefabs/Level", typeof(GameObject))) as GameObject;
        Level level = levelGameObject.GetComponent<Level>();
        level.setLevelManager(gameObject);
        level.setLevel(levelNumber);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
