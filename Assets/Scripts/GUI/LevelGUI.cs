using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.UI;
using System;
using System.Collections.Specialized;
using UnityEngine;
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

    private GameObject[] colonyActiveBoostersIcons = null;

	private int gameplayTime = 0;

    void Awake()
    {
        gameAreaPanel = transform.Find("GameAreaPanel").gameObject;
        bottomBarPanel = transform.Find("BottomBarPanel").gameObject;
        gamePausedPanel = transform.Find("GamePausedPanel").gameObject;

        noInformationPanel = bottomBarPanel.transform.Find("NoInformationPanel").gameObject;
        colonyInformationPanel = bottomBarPanel.transform.Find("ColonyInformationPanel").gameObject;
        objectInformationPanel = bottomBarPanel.transform.Find("ObjectInformationPanel").gameObject;

        colonyActiveBoostersIcons = new GameObject[6];
        colonyActiveBoostersIcons[0] = colonyInformationPanel.transform.Find("ActiveBoostersBackground/IronImg").gameObject;
        colonyActiveBoostersIcons[1] = colonyInformationPanel.transform.Find("ActiveBoostersBackground/MushImg").gameObject;
        colonyActiveBoostersIcons[2] = colonyInformationPanel.transform.Find("ActiveBoostersBackground/GiantImg").gameObject;
        colonyActiveBoostersIcons[3] = colonyInformationPanel.transform.Find("ActiveBoostersBackground/MaskImg").gameObject;
        colonyActiveBoostersIcons[4] = colonyInformationPanel.transform.Find("ActiveBoostersBackground/ShieldImg").gameObject;

        noInformationPanel.SetActive(true);
        colonyInformationPanel.SetActive(false);
        objectInformationPanel.SetActive(false);

        gamePausedPanel.SetActive(false);
        gameAreaPanel.SetActive(true);
        bottomBarPanel.SetActive(true);

        StartCoroutine(refreshInfo());
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
            this.timer();
            yield return new WaitForSeconds(1F);
        }
    }

    public void objectSelected(GenericObject selectedObject)
    {
        if (selectedColony)
            colonyDeselected();
        if (this.selectedObject)
            this.selectedObject.deselect();
        this.selectedObject = selectedObject;
        selectedObject.select();

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
        selectedObject.deselect();
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
        colonyInformationPanel.transform.Find("Slider/Max").GetComponent<Text>().text = selectedColony.getTermites() + "";

        for (int i = 0; i < 5; i++)
            colonyActiveBoostersIcons[i].SetActive(false);
        foreach (Booster booster in selectedColony.boosters)
            colonyActiveBoostersIcons[(int)booster.getModel() - 1].SetActive(true);

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
        int newSize = Convert.ToInt32(colonyInformationPanel.transform.Find("Slider").GetComponent<Slider>().value);
        selectedColony.split(newSize);
        //Refresh info
        colonySelected(selectedColony);
    }

    public Colony instantiateColony()
    {
        GameObject colCursor = Instantiate(Resources.Load("Prefabs/Colony", typeof(GameObject))) as GameObject;
        colCursor.transform.parent = gameAreaPanel.transform;
        Colony colony = colCursor.GetComponent<Colony>();
        colCursor.GetComponent<Button>().onClick.AddListener(() => colonySelected(colony));
        return colony;
    }

    public StartAttackCursor instantiateStartAttackCursor()
    {
        GameObject startAttackCursor = Instantiate(Resources.Load("Prefabs/GUI/StartAttackCursor", typeof(GameObject))) as GameObject;
        startAttackCursor.transform.parent = gameAreaPanel.transform;
        return startAttackCursor.GetComponent<StartAttackCursor>();
    }

    public void initRoomIndicator(Rect miniMapRoomIndicatorRect, Rect mapRoomIndicatorRect, int roomNumber)
    {
        GameObject miniMapRoomIndicator = Instantiate(Resources.Load("Prefabs/GUI/RoomIndicator", typeof(GameObject))) as GameObject;
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

        //CREZIONE COORDINATE
       /* Vector2 pos = transform.Find("MiniMapPanel/MiniMap/RoomIndicator (" + roomNumber + ")").GetComponent<RectTransform>().localPosition;
        Vector2 dim = transform.Find("MiniMapPanel/MiniMap/RoomIndicator (" + roomNumber + ")").GetComponent<RectTransform>().rect.size;
        Debug.Log("_rooms.Add(new Rect(" + pos.x.ToString("####0.00") + "f, " + pos.y.ToString("####0.00") + "f, " + dim.x.ToString("####0.00") + "f, " + dim.y.ToString("####0.00") + "f));");*/
;
    }

    public void changeGameState(bool gamePaused)
    {
        gameAreaPanel.SetActive(!gamePaused);
        bottomBarPanel.SetActive(!gamePaused);
        gamePausedPanel.SetActive(gamePaused);
        if (gamePaused)
        {
            foreach(Room r in GameManager.getCurrentLevel().rooms)
            {
                //GameObject o = gamePausedPanel.transform.Find("MiniMapPanel")
            }
        }
    }
    
}
