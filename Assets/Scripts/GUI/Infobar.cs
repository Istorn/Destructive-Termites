using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.UI;
public class Infobar : MonoBehaviour {
    Level levelInPlay = null;
	// Use this for initialization
	void Start () {
	
	}
    public void setlevelPlay(Level levelToSet)
    {
        this.levelInPlay = levelToSet;
    }
    public Level getlevelPlay()
    {
        return this.levelInPlay;
    }
    //load at the starting of play
	void Awake()
    {
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "TERMITES AVAILABLE: "+this.levelInPlay.availableTermites;
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
    }
	// Update is called once per frame
	void Update () {
	
	}
    //clicking on an object load its specs
    public void selected(GenericObject selectedObj)
    {
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "MATERIAL: " + selectedObj.GetType();
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "TERMITES: " + selectedObj.counter;
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "INTEGRITY: " + selectedObj.integrity;

    }
    //deselecting an object reload main infos
    public void deselected()
    {
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "TERMITES AVAILABLE: " + this.levelInPlay.availableTermites;
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
    }
}
