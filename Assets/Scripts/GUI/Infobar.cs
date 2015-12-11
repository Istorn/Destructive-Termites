﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.UI;
using System.Collections.Specialized;
using UnityEngine;
public class Infobar : MonoBehaviour {
    public Level levelInPlay = null;
    private GenericObject selectedObject = null;
    private Colony selectedColony = null;
	// Use this for initialization
	void Start () {
	
	}
    public void setlevelPlay(Level levelToSet)
    {
        this.levelInPlay = levelToSet;
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "";
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
        this.transform.Find("Background/CombatText").GetComponent<Text>().text = levelToSet.usedTermites+"in combat";
        this.transform.Find("Background/AvailableText").GetComponent<Text>().text = levelToSet.availableTermites+" available";

    }
    public Level getlevelPlay()
    {
        return this.levelInPlay;
    }
    public void setTermitesOnBar()
    {
        this.transform.Find("BackGround/AvailableText").GetComponent<Text>().text =this.levelInPlay.availableTermites + "available: " ;
        this.transform.Find("BackGround/CombatText").GetComponent<Text>().text = this.levelInPlay.usedTermites + "in combat: ";
    }
    //load at the starting of play
	void Awake()
    {
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "";
        this.transform.Find("Background/BoosterSpecText").GetComponent<Text>().text = "COLLECTED BOOSTERS";
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = " ";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
        this.transform.Find("Background/CombatText").GetComponent<Text>().text = "";
        this.transform.Find("Background/AvailableText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IronImg/IronText").GetComponent<Text>().text = "0";
        this.transform.Find("Background/GiantImg/GiantText").GetComponent<Text>().text = "0";
        this.transform.Find("Background/MushImg/MushText").GetComponent<Text>().text = "0";
        this.transform.Find("Background/MaskImg/MaskText").GetComponent<Text>().text = "0";
        this.transform.Find("Background/ShieldImg/ShieldText").GetComponent<Text>().text = "0";
        this.transform.Find("Background/QueenImg/QueenText").GetComponent<Text>().text = "0";
        //splitter is not visible
        this.transform.Find("Background/SliderColony").GetComponent<Slider>().transform.localScale = new Vector3(0.0001F, 0);
        this.transform.Find("Background/SliderColony/MinSlideText").GetComponent<Text>().enabled = false;
        this.transform.Find("Background/SliderColony/MaxSlideText").GetComponent<Text>().enabled = false;

    }
    // Update is called once per frame
    void Update () {
	
	}
    //clicking on an object load its specs
    public void objectSelected(GenericObject selectedObject)
    {
        if (selectedColony)
            colonyDeselected();

        this.selectedObject = selectedObject;
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = this.selectedObject.getType();
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "TERMITES: " + this.selectedObject.counter;
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "INTEGRITY: " + this.selectedObject.integrity;
         
    }
    //deselecting an object reload main infos
    public void objectDeselected()
    {
        selectedObject.deselect();

        this.selectedObject = null;
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "";
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
    }
    //select and deselect colony
    public void colonySelected(Colony selectedColony)
    {
        if (selectedObject)
            objectDeselected();

        Debug.Log("INFOBAR_SELECT");
        this.selectedColony = selectedColony;
        List<int> boosterColony= new List<int>();
        this.transform.Find("Background/SliderColony").GetComponent<Slider>().transform.localScale = new Vector3(1.0F, 0);
        for (int i = 0; i < 6; i++)
        {
            boosterColony.Add(0);
        }
        this.transform.Find("Background/BoosterSpecText").GetComponent<Text>().text = "";
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "TERMITES AVAILABLE: " + this.selectedColony.getTermites();
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
        //splitter is  visible
        this.transform.Find("Background/SliderColony").GetComponent<Slider>().enabled = true;
        this.transform.Find("Background/SliderColony/MinSlideText").GetComponent<Text>().enabled = true;
        this.transform.Find("Background/SliderColony/MaxSlideText").GetComponent<Text>().enabled = true;
        this.transform.Find("Background/SliderColony/MaxSlideText").GetComponent<Text>().text = "" + this.selectedColony.getTermites();
        this.transform.Find("Background/SliderColony/MinSlideText").GetComponent<Text>().text = "0";
        //scan booster of colony and divide by type: in the end, refresh indicators on the bar
        List<Booster> colonyBoosters = this.selectedColony.boosters;
        foreach (Booster booster in colonyBoosters)
        {
            switch ((int)booster.type)
            {
                case 1:
                    {
                        boosterColony[0]++;
                    };
                    break;
                case 2:
                    {

                        boosterColony[1]++;
                    };
                    break;
                case 3:
                    {

                        boosterColony[2]++;
                    };
                    break;
                case 4:
                    {

                        boosterColony[3]++;
                    };
                    break;
                case 5:
                    {

                        boosterColony[4]++;
                    };
                    break;
                case 6:
                    {

                        boosterColony[5]++;
                    }; break;

                
            }
        }
        //showing num of booster available in colony
        this.transform.Find("Background/BoosterSpecText").GetComponent<Text>().text = "BOOSTERS OF COLONY";
        this.transform.Find("Background/IronImg/IronText").GetComponent<Text>().text = ""+boosterColony[0];
        this.transform.Find("Background/GiantImg/GiantText").GetComponent<Text>().text = "" + boosterColony[1];
        this.transform.Find("Background/MushImg/MushText").GetComponent<Text>().text = "" + boosterColony[2];
        this.transform.Find("Background/MaskImg/MaskText").GetComponent<Text>().text = "" + boosterColony[3];
        this.transform.Find("Background/ShieldImg/ShieldText").GetComponent<Text>().text = "" + boosterColony[4];
        this.transform.Find("Background/QueenImg/QueenText").GetComponent<Text>().text = "" + boosterColony[5];
    }

    public void colonyDeselected()
    {
        selectedColony.deselect();

        this.transform.Find("Background/BoosterSpecText").GetComponent<Text>().text = "COLLECTED BOOSTERS";
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "";
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
        //splitter is not visible
        this.transform.Find("Background/SliderColony").GetComponent<Slider>().enabled = false;
        this.transform.Find("Background/SliderColony/MinSlideText").GetComponent<Text>().enabled = false;
        this.transform.Find("Background/SliderColony/MaxSlideText").GetComponent<Text>().enabled = false;
    }
    //set booster on screen by type of the level
    
}
