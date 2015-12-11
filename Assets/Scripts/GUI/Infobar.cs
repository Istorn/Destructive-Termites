using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.UI;
public class Infobar : MonoBehaviour {
    public Level levelInPlay = null;
    private GenericObject selectedObject = null;
	// Use this for initialization
	void Start () {
	
	}
    public void setlevelPlay(Level levelToSet)
    {
        this.levelInPlay = levelToSet;
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "TERMITES AVAILABLE: " + this.levelInPlay.availableTermites;
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
    }
    public Level getlevelPlay()
    {
        return this.levelInPlay;
    }
    public void setTermitesOnBar()
    {

        this.transform.Find("BackGround/AvailableText").GetComponent<Text>().text = "available: "+this.levelInPlay.availableTermites;
        this.transform.Find("BackGround/CombatText").GetComponent<Text>().text = "in combat: " + this.levelInPlay.usedTermites;
    }
    //load at the starting of play
	void Awake()
    {
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "";
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "TERMITES: ";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "INTEGRITY: ";
        this.transform.Find("Background/IronImg/IronText").GetComponent<Text>().text = "0";
        this.transform.Find("Background/GiantImg/GiantText").GetComponent<Text>().text = "0";
        this.transform.Find("Background/MushImg/MushText").GetComponent<Text>().text = "0";
        this.transform.Find("Background/MaskImg/MaskText").GetComponent<Text>().text = "0";
        this.transform.Find("Background/ShieldImg/ShieldText").GetComponent<Text>().text = "0";
        this.transform.Find("Background/QueenImg/QueenText").GetComponent<Text>().text = "0";
        //splitter is not visible
        this.transform.Find("Background/SliderColony").GetComponent<Slider>().enabled = false;
        this.transform.Find("Background/SliderColony/MinSlideText").GetComponent<Text>().enabled = false;
        this.transform.Find("Background/SliderColony/MaxSlideText").GetComponent<Text>().enabled = false;

    }
    // Update is called once per frame
    void Update () {
	
	}
    //clicking on an object load its specs
    public void selectedObj(GenericObject selectedObj)
    {
        if (selectedObject)
            selectedObject.deselect();
        this.selectedObject = selectedObj;
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = selectedObj.getType();
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "TERMITES: " + selectedObj.counter;
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "INTEGRITY: " + selectedObj.integrity;
         
    }
    //deselecting an object reload main infos
    public void deselectedObj()
    {
        this.selectedObject = null;
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "TERMITES AVAILABLE: " + this.levelInPlay.availableTermites;
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
    }
    //select and deselect colony
    public void selectedColony(Colony colonyselected)
    {
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = colonyselected.
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "TERMITES: " + selectedObj.counter;
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "INTEGRITY: " + selectedObj.integrity;

    }
    public void delesectColony()
    {
        this.selectedObject = null;
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "TERMITES AVAILABLE: " + this.levelInPlay.availableTermites;
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
    }
    //set booster on screen by type of the level
    
}
