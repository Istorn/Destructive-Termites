﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.UI;
using System;
using System.Collections.Specialized;
public class LevelGUI : MonoBehaviour
{
    private GenericObject selectedObject = null;

    private Colony selectedColony = null;

    private GameObject gameAreaPanel = null;
    private GameObject bottomBarPanel = null;
    private GameObject gamePausedPanel = null;


    private GameObject noInformationPanel = null;
    private GameObject colonyInformationPanel = null;
    private GameObject objectInformationPanel = null;
    private GameObject availableBoostersPanel = null;

    private GameObject[] colonyActiveBoostersIcons = null;

    private Text[] availableBoostersIcons = null;

    private GameObject availableTermitesPanel = null;
    private Text termitesCounter = null;

    private GameObject mapDisplay = null;

    private ChallengeDisplay activeChallengeDisplay = null;

	private int gameplayTime = 0;

    void Awake()
    {
        mapDisplay = GameObject.Find("MapDisplay").gameObject;

        gameAreaPanel = transform.Find("GameAreaPanel").gameObject;
        bottomBarPanel = transform.Find("BottomBarPanel").gameObject;
        gamePausedPanel = transform.Find("GamePausedPanel").gameObject;

        noInformationPanel = bottomBarPanel.transform.Find("SecondPhasePanel/NoInformationPanel").gameObject;
        colonyInformationPanel = bottomBarPanel.transform.Find("SecondPhasePanel/ColonyInformationPanel").gameObject;
        objectInformationPanel = bottomBarPanel.transform.Find("SecondPhasePanel/ObjectInformationPanel").gameObject;
        availableBoostersPanel = bottomBarPanel.transform.Find("SecondPhasePanel/AvailableBoostersPanel").gameObject;

        colonyActiveBoostersIcons = new GameObject[3];
        colonyActiveBoostersIcons[0] = colonyInformationPanel.transform.Find("ActiveBoostersBackground/IronImg").gameObject;
        colonyActiveBoostersIcons[1] = colonyInformationPanel.transform.Find("ActiveBoostersBackground/MaskImg").gameObject;
        colonyActiveBoostersIcons[2] = colonyInformationPanel.transform.Find("ActiveBoostersBackground/ShieldImg").gameObject;

        availableBoostersIcons = new Text[4];
        availableBoostersIcons[0] = availableBoostersPanel.transform.Find("IronImg/IronText").gameObject.GetComponent<Text>();
        availableBoostersIcons[1] = availableBoostersPanel.transform.Find("MaskImg/MaskText").gameObject.GetComponent<Text>();
        availableBoostersIcons[2] = availableBoostersPanel.transform.Find("ShieldImg/ShieldText").gameObject.GetComponent<Text>();
        availableBoostersIcons[3] = availableBoostersPanel.transform.Find("QueenImg/QueenText").gameObject.GetComponent<Text>();

        noInformationPanel.SetActive(true);
        colonyInformationPanel.SetActive(false);
        objectInformationPanel.SetActive(false);

        gamePausedPanel.SetActive(false);
        gameAreaPanel.SetActive(true);
        bottomBarPanel.SetActive(true);

        #if UNITY_IPHONE || UNITY_ANDROID
            bottomBarPanel.transform.Find("AvailableTermitesPanelMobile").gameObject.SetActive(true);
            bottomBarPanel.transform.Find("AvailableTermitesPanelDesktop").gameObject.SetActive(false);
            availableTermitesPanel = bottomBarPanel.transform.Find("AvailableTermitesPanelMobile").gameObject;
            termitesCounter = bottomBarPanel.transform.Find("AvailableTermitesPanelMobile/Number").GetComponent<Text>();
        #else
            bottomBarPanel.transform.Find("AvailableTermitesPanelDesktop").gameObject.SetActive(true);
            bottomBarPanel.transform.Find("AvailableTermitesPanelMobile").gameObject.SetActive(false);
            availableTermitesPanel = bottomBarPanel.transform.Find("AvailableTermitesPanelDesktop").gameObject;
            termitesCounter = bottomBarPanel.transform.Find("AvailableTermitesPanelDesktop/Number").GetComponent<Text>();
        #endif

        activeChallengeDisplay = bottomBarPanel.transform.Find("SecondPhasePanel/CurrentChallengePanel").gameObject.GetComponent<ChallengeDisplay>();

        initChallengesList();
    }

    public float getBottomBarBottomCoord()
    {
        RectTransform tr1 = bottomBarPanel.transform.Find("Anchor1").GetComponent<RectTransform>();
        RectTransform tr2 = bottomBarPanel.transform.Find("Anchor2").GetComponent<RectTransform>();
        Camera c = GameManager.getMainGamera().GetComponent<Camera>();
        return Math.Abs(c.ScreenToWorldPoint(tr1.transform.position).y - c.ScreenToWorldPoint(tr2.transform.position).y);
    }

    public Colony getSelectedColony()
    {
        return selectedColony;
    }

    public GenericObject getSelectedObject()
    {
        return selectedObject;
    }

    private void timer()
    {
        gameplayTime++;
        int hours = gameplayTime / 3600;
        int minutes = (gameplayTime - hours * 3600) / 60;
        int seconds = gameplayTime - hours * 3600 - minutes * 60;

        string timeString = "";
        if (hours < 10)
            timeString = timeString + "0";
        timeString = timeString + hours + ":";

        if (minutes < 10)
            timeString = timeString + "0";
        timeString = timeString + minutes + ":";

        if (seconds < 10)
            timeString = timeString + "0";
        timeString = timeString + seconds;

      
      //  this.transform.Find("BottomBarPanel/TimeText").GetComponent<Text>().text = "TIME: " + timeString;
    }

    IEnumerator refreshInfo()
    {
        while (true)
        {
            timerTick();
            activeChallengeDisplay.updateProgress();
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void enableRefreshTimer()
    {
        StartCoroutine(refreshInfo());
    }

    private void timerTick()
    {
        this.timer();

        updateTermitesCounter();
    }

    public void objectSelected(GenericObject selectedObject)
    {
        if (selectedColony)
            colonyDeselected();
        if (this.selectedObject)
            this.selectedObject.deselect(ObjectSelection.Model.InfoDisplay);
        this.selectedObject = selectedObject;
        selectedObject.select(ObjectSelection.Model.InfoDisplay);

        objectInformationPanel.transform.Find("Title").gameObject.GetComponent<Text>().text = selectedObject.getCategory() + ": " + selectedObject.getName();
        objectInformationPanel.transform.Find("Description").gameObject.GetComponent<Text>().text = selectedObject.getDescription();
        if (selectedObject.getAttacker())
        {
            objectInformationPanel.transform.Find("SelectAttackertButton").gameObject.GetComponent<Button>().interactable = true;
            objectInformationPanel.transform.Find("SelectAttackertButton/Text").gameObject.GetComponent<Text>().text = "ATTACKER";
        }
        else
        {
            objectInformationPanel.transform.Find("SelectAttackertButton").gameObject.GetComponent<Button>().interactable = false;
            objectInformationPanel.transform.Find("SelectAttackertButton/Text").gameObject.GetComponent<Text>().text = "NO ATTACKER";
        }
        
        int integrity = selectedObject.getIntegrity();
        if (integrity < 0)
            integrity = 0;
        objectInformationPanel.transform.Find("Integrity").gameObject.GetComponent<Text>().text = "INTEGRITY: " + integrity + "%";
        
        objectInformationPanel.SetActive(true);
        noInformationPanel.SetActive(false);
    }

    public void objectDeselected()
    {
        selectedObject.deselect(ObjectSelection.Model.InfoDisplay);
        objectInformationPanel.SetActive(false);
        selectedObject = null;
    }

    public void colonySelected(Colony selectedColony)
    {
        if (selectedObject)
            objectDeselected();
        if (this.selectedColony)
            this.selectedColony.deselect();
        this.selectedColony = selectedColony;
        selectedColony.select();

        colonyInformationPanel.transform.Find("Title").gameObject.GetComponent<Text>().text = "COLONY: " + selectedColony.getTermites() + " TERMITES";
        if (selectedColony.getTermites() == 1)
            colonyInformationPanel.transform.Find("Slider/Max").GetComponent<Text>().text = "1";
        else
            colonyInformationPanel.transform.Find("Slider/Max").GetComponent<Text>().text = (selectedColony.getTermites() - 1) + "";

        for (int i = 0; i < 5; i++)
            colonyActiveBoostersIcons[i].SetActive(false);
       /* foreach (Booster booster in selectedColony.boosters)
            colonyActiveBoostersIcons[(int)booster.getModel() - 1].SetActive(true);*/

        colonyInformationPanel.SetActive(true);
        noInformationPanel.SetActive(false);
    }

    public void colonyDeselected()
    {
        selectedColony.deselect();
        this.selectedColony = null;

    }
    public void deselect()
    {
        if (selectedColony)
            colonyDeselected();
        if (selectedObject)
            objectDeselected();
    }

    public void changeTargetAttacker()
    {
        if (selectedObject)
        {
            if (selectedObject.getAttacker())
                colonySelected(selectedObject.getAttacker());
        }
        else     
            if (selectedColony)
                if (selectedColony.getTarget())
                    objectSelected(selectedColony.getTarget());
    }

    public void selectAttacker()
    {
        Colony attacker = selectedObject.getAttacker();
        if (attacker)
            colonySelected(attacker);
    }

    public void selectTarget()
    {
        GenericObject target = selectedColony.getTarget();
        if (target)
            objectSelected(target);
    }

    public void sliderValueChanged()
    {
        float splitRatio = colonyInformationPanel.transform.Find("Slider").GetComponent<Slider>().value;
        selectedColony.split(splitRatio);
        colonySelected(selectedColony);
    }

    public Colony instantiateColony()
    {
        GameObject miniMapCursor = Instantiate(Resources.Load("Circle", typeof(GameObject))) as GameObject;
        miniMapCursor.transform.SetParent(GameObject.Find("/MapsCanvas/Map").transform);
        miniMapCursor.transform.localScale = new Vector3(1, 1, 1);
        miniMapCursor.layer = LayerMask.NameToLayer("Map");

        GameObject colCursor = Instantiate(Resources.Load("Prefabs/Colony", typeof(GameObject))) as GameObject;
        //colCursor.transform.SetParent(gameAreaPanel.transform);
        colCursor.transform.SetParent(bottomBarPanel.transform.Find("MessagePanel").transform);
        Colony colony = colCursor.transform.Find("NotAttackImage").GetComponent<Colony>();
        colCursor.transform.Find("NotAttackImage").gameObject.GetComponent<Button>().onClick.AddListener(() => colonySelected(colony));
        colony.setMiniMapCursor(miniMapCursor);

        return colony;
    }

    public GameObject getGameAreaPanel()
    {
        return gameAreaPanel;
    }

    public StartAttackCursor instantiateStartAttackCursor()
    {
        GameObject startAttackCursor = Instantiate(Resources.Load("Prefabs/GUI/StartAttackCursor", typeof(GameObject))) as GameObject;
        startAttackCursor.transform.SetParent(gameAreaPanel.transform);
        return startAttackCursor.GetComponent<StartAttackCursor>();
    }

    public void initRoomIndicator(Rect miniMapRoomIndicatorRect, Rect mapRoomIndicatorRect, int roomNumber)
    {
        /*GameObject miniMapRoomIndicator = Instantiate(Resources.Load("Prefabs/GUI/RoomIndicator", typeof(GameObject))) as GameObject;
        miniMapRoomIndicator.name = "RoomIndicator" + roomNumber;
        miniMapRoomIndicator.transform.SetParent(transform.Find("MiniMapPanel/MiniMap").transform);
        miniMapRoomIndicator.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        miniMapRoomIndicator.GetComponent<RectTransform>().sizeDelta = miniMapRoomIndicatorRect.size;
        miniMapRoomIndicator.GetComponent<RectTransform>().localPosition = miniMapRoomIndicatorRect.position;
        Color c = miniMapRoomIndicator.GetComponent<Image>().color;
        miniMapRoomIndicator.GetComponent<Image>().color = new Color(c.r, c.g, c.b, 0.8f); 
        miniMapRoomIndicator.GetComponent<Image>().fillAmount = (float)UnityEngine.Random.Range(2, 8) / 10;

        GameObject mapRoomIndicator = Instantiate(Resources.Load("Prefabs/GUI/RoomIndicator", typeof(GameObject))) as GameObject;
        mapRoomIndicator.name = "RoomIndicator" + roomNumber;
        mapRoomIndicator.transform.SetParent(gamePausedPanel.transform.Find("MapPanel/Map").transform);
        mapRoomIndicator.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        mapRoomIndicator.GetComponent<RectTransform>().sizeDelta = mapRoomIndicatorRect.size;
        mapRoomIndicator.GetComponent<RectTransform>().localPosition = mapRoomIndicatorRect.position;
        mapRoomIndicator.GetComponent<Image>().fillAmount = (float)UnityEngine.Random.Range(2, 8) / 10;
        */
        //CREZIONE COORDINATE
       /* Vector2 pos = transform.Find("MiniMapPanel/MiniMap/RoomIndicator (" + roomNumber + ")").GetComponent<RectTransform>().localPosition;
        Vector2 dim = transform.Find("MiniMapPanel/MiniMap/RoomIndicator (" + roomNumber + ")").GetComponent<RectTransform>().rect.size;
        Debug.Log("_rooms.Add(new Rect(" + pos.x.ToString("####0.00") + "f, " + pos.y.ToString("####0.00") + "f, " + dim.x.ToString("####0.00") + "f, " + dim.y.ToString("####0.00") + "f));");*/
;
    }

    public void changeGameState(bool gamePaused)
    {
        //gameAreaPanel.SetActive(!gamePaused);
        bottomBarPanel.SetActive(!gamePaused);
        gamePausedPanel.SetActive(gamePaused);
        mapDisplay.GetComponent<MeshRenderer>().materials[0].color = new Color(1, 1, 1, gamePaused?1:0);
        if (gamePaused)
        {
            foreach(Room r in GameManager.getCurrentLevel().getRooms())
            {
                //GameObject o = gamePausedPanel.transform.Find("MiniMapPanel")
            }
        }
    }

    private void updateTermitesCounter()
    {
        termitesCounter.text = GameManager.getCurrentLevel().getAvailableTermites() + "";
    }

    public void changedGamePhase()
    {
        if (GameManager.getIsInitialPhase())
        {
            availableTermitesPanel.transform.Find("Title").GetComponent<Text>().text = "AVAILABLE";
            bottomBarPanel.transform.Find("FirstPhasePanel").gameObject.SetActive(true);
            bottomBarPanel.transform.Find("SecondPhasePanel").gameObject.SetActive(false);
        }
        else
        {
            availableTermitesPanel.transform.Find("Title").GetComponent<Text>().text = "IN COMBAT";
            bottomBarPanel.transform.Find("FirstPhasePanel").gameObject.SetActive(false);
            bottomBarPanel.transform.Find("SecondPhasePanel").gameObject.SetActive(true);
        }
            
    }

    public bool isGameAreaClicked(Vector3 mousePos)
    {
        RectTransform tr1 = bottomBarPanel.transform.Find("Anchor1").GetComponent<RectTransform>();
        return tr1.transform.position.y - mousePos.y < 0;
    }
    
    public Vector2 getMessageAnchorPoint()
    {
        return bottomBarPanel.transform.Find("MessagePanel/Anchor").gameObject.transform.position;
    }

    public void setMessageEnabled(bool enabled)
    {
        bottomBarPanel.transform.Find("MessagePanel").gameObject.SetActive(enabled);
    }

    private void initChallengesList()
    {
        List<GenericChallenge> challenges = GameManager.initChallengesMonitor();
        GameObject list = gamePausedPanel.transform.Find("ChallengesPanel/ListSpace/List").gameObject;
        foreach (GenericChallenge challenge in challenges)
        {
            GameObject chal = (GameObject)Instantiate(Resources.Load("Prefabs/Challenges/ChallengePauseDisplay", typeof(GameObject))) as GameObject;
            ChallengePauseDisplay cD = chal.GetComponent<ChallengePauseDisplay>();
            chal.transform.SetParent(list.transform);
            chal.transform.localScale = new Vector3(1, 1, 1);
            cD.setChallenge(challenge);
        }
    }

    public ChallengeDisplay getChallengeDisplay()
    {
        return activeChallengeDisplay;
    }

    public void droppedBooster(Booster.Model model)
    {
        availableBoostersIcons[(int)model - 1].text = (Int32.Parse(availableBoostersIcons[(int)model - 1].text) + 1) + "";
    }

    public void usedBooster(Booster.Model model)
    {
        availableBoostersIcons[(int)model - 1].text = (Int32.Parse(availableBoostersIcons[(int)model - 1].text) - 1) + "";
    }
}
