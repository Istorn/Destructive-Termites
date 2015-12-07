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
    //load at the starting of play
	void Awake()
    {
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "";
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "TERMITES: ";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "INTEGRITY: ";
    }
	// Update is called once per frame
	void Update () {
	
	}
    //clicking on an object load its specs
    public void selected(GenericObject selectedObj)
    {
        if (selectedObject)
            selectedObject.deselect();
        this.selectedObject = selectedObj;
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = selectedObj.getType();
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "TERMITES: " + selectedObj.counter;
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "INTEGRITY: " + selectedObj.integrity;
         
    }
    //deselecting an object reload main infos
    public void deselected()
    {
        this.selectedObject = null;
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "TERMITES AVAILABLE: " + this.levelInPlay.availableTermites;
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
    }
}
