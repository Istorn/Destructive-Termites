using UnityEngine;
using System.Collections;

public class LevelsManager : MonoBehaviour {

	public int levelNumber = 1;

	// Use this for initialization
    void Awake()
    {
        GameObject levelGameObject = Instantiate(Resources.Load("Prefabs/Level", typeof(GameObject))) as GameObject;
        levelGameObject.name = "Level";

        

        LevelData levelData = GetComponent("LevelData" + levelNumber) as LevelData;
        levelData.initialize();


        Level level = levelGameObject.GetComponent<Level>();
        level.setLevelData(levelData, levelNumber);
    }
    
    public void changeGameState(bool gamePaused)
    {
        GameManager.changeGameState(gamePaused);
    }
}
