﻿using UnityEngine;
using System.Collections;


public class GameManager {

    private static MainCamera mainCamera = null;

    private static LevelGUI levelGUI = null;

    private static Level currentLevel = null;

    public static void setMainCamer(MainCamera mainCamera)
    {
        GameManager.mainCamera = mainCamera;
    }

    public static MainCamera getMainGamera()
    {
        return mainCamera;
    }

    public static LevelGUI getLevelGUI()
    {
        if (!levelGUI)
        {
            //GameObject levelGUIGameObject = GameObject.Instantiate(Resources.Load("Prefabs/GUI/LevelGUI", typeof(GameObject))) as GameObject;
            GameObject levelGUIGameObject = GameObject.Find("LevelGUI");
            levelGUIGameObject.name = "LevelGUI";
            levelGUI = levelGUIGameObject.GetComponent<LevelGUI>();
        }
        return levelGUI;
    }

    public static void removeLevelGUI()
    {
        if (levelGUI)
        {
            GameObject.Destroy(levelGUI.gameObject);
            levelGUI = null;
        }   
    }

    public static void setCurrentLevel(Level currentLevel)
    {
        GameManager.currentLevel = currentLevel;
    }

    public static Level getCurrentLevel()
    {
        return currentLevel;
    }

}
