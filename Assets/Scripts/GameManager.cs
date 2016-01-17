using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager {

    private static MainCamera mainCamera = null;

    private static LevelGUI levelGUI = null;

    private static Level currentLevel = null;

    private static bool isGamePaused = false;

    private static bool isInitialPhase = true;

    private static int nMessages = 0;

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

    public static void changeGameState()
    {
        isGamePaused = !isGamePaused;
        changeGameState(isGamePaused);
    }

    public static void changeGameState(bool gamePaused)
    {
        GameManager.isGamePaused = gamePaused;
        if (gamePaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
        getLevelGUI().changeGameState(gamePaused);
    }

    public static bool getIsGamePaused()
    {
        return isGamePaused;
    }

    public static bool getIsInitialPhase()
    {
        return isInitialPhase;
    }

    public static void setIsInitialPhase(bool isInitialPhase)
    {
        GameManager.isInitialPhase = isInitialPhase;
    }

    public static void gameOver()
    {

    }

    public static void gameWon()
    {

    }

    public static void gameEnd()
    {

    }
    
    public static void addMessage()
    {
        nMessages++;
        if (nMessages == 1)
            levelGUI.setMessageEnabled(true);
    }

    public static void removeMessage()
    {
        nMessages--;
        if (nMessages == 0)
            levelGUI.setMessageEnabled(false);
    }

    public static List<GenericChallenge> initChallengesMonitor()
    {
        ChallengeManager.generateChallenges(20);
        return ChallengeManager.getChallenges();
    }
}
