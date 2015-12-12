using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.UI;
using System.Collections.Specialized;
using UnityEngine;
public class Infobar : MonoBehaviour
{
    public Level levelInPlay = null;
    private GenericObject selectedObject = null;
    private Colony selectedColony = null;
    private IEnumerator refreshCoroutine = null;
    // Use this for initialization
    void Start()
    {

    }

    public Colony getSelectedColony()
    {
        return selectedColony;
    }

    public GenericObject getSelectedObject()
    {
        return selectedObject;
    }

    //refresh infos
    IEnumerator refreshInfo()
    {
        while (true)
        {
            if (this.levelInPlay)
            {
                this.transform.Find("Background/CombatText").GetComponent<Text>().text = this.levelInPlay.usedTermites + "in combat";
                this.transform.Find("Background/AvailableText").GetComponent<Text>().text = this.levelInPlay.availableTermites + " available";

            }
            if (this.selectedColony)
            {
                List<int> boosterColony = new List<int>();
               
                for (int i = 0; i < 6; i++)
                {
                    boosterColony.Add(0);
                }
                this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "TERMITES AVAILABLE: " + this.selectedColony.getTermites();
                this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
                this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "SPLIT COLONY";
                //splitter is  visible
                this.transform.Find("Background/SliderColony").GetComponent<Slider>().transform.localScale = new Vector3(1000.0F, 0);
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
                this.transform.Find("Background/IronImg/IronText").GetComponent<Text>().text = "" + boosterColony[0];
                this.transform.Find("Background/GiantImg/GiantText").GetComponent<Text>().text = "" + boosterColony[1];
                this.transform.Find("Background/MushImg/MushText").GetComponent<Text>().text = "" + boosterColony[2];
                this.transform.Find("Background/MaskImg/MaskText").GetComponent<Text>().text = "" + boosterColony[3];
                this.transform.Find("Background/ShieldImg/ShieldText").GetComponent<Text>().text = "" + boosterColony[4];
                this.transform.Find("Background/QueenImg/QueenText").GetComponent<Text>().text = "" + boosterColony[5];
            }
            else if (this.selectedObject)
            {
                
                this.transform.Find("Background/ColObjText").GetComponent<Text>().text = "OBJECT INFO";
                this.transform.Find("Background/MaterialText").GetComponent<Text>().text = this.selectedObject.getType();
                this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "TERMITES: " + this.selectedObject.counter;
                this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "INTEGRITY: " + (int)this.selectedObject.integrity+"%";
            }
            yield return new WaitForSeconds(1F);
        }
    }
    public void setlevelPlay(Level levelToSet)
    {
        List<int> boosterColony = new List<int>();
        this.levelInPlay = levelToSet;
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "";
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
        this.transform.Find("Background/CombatText").GetComponent<Text>().text = levelToSet.usedTermites + "in combat";
        this.transform.Find("Background/AvailableText").GetComponent<Text>().text = levelToSet.availableTermites + " available";
        //scan booster of level and divide by type: in the end, refresh indicators on the bar
        List<Booster> levelBoosters = this.levelInPlay.collectedBoosters;
        foreach (Booster booster in levelBoosters)
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
        //showing num of booster available in level
        this.transform.Find("Background/BoosterSpecText").GetComponent<Text>().text = "COLLECTED BOOSTERS";
        this.transform.Find("Background/IronImg/IronText").GetComponent<Text>().text = "" + boosterColony[0];
        this.transform.Find("Background/GiantImg/GiantText").GetComponent<Text>().text = "" + boosterColony[1];
        this.transform.Find("Background/MushImg/MushText").GetComponent<Text>().text = "" + boosterColony[2];
        this.transform.Find("Background/MaskImg/MaskText").GetComponent<Text>().text = "" + boosterColony[3];
        this.transform.Find("Background/ShieldImg/ShieldText").GetComponent<Text>().text = "" + boosterColony[4];
        this.transform.Find("Background/QueenImg/QueenText").GetComponent<Text>().text = "" + boosterColony[5];
    }
    public Level getlevelPlay()
    {
        return this.levelInPlay;
    }
    public void setTermitesOnBar()
    {
        this.transform.Find("BackGround/AvailableText").GetComponent<Text>().text = this.levelInPlay.availableTermites + "available: ";
        this.transform.Find("BackGround/CombatText").GetComponent<Text>().text = this.levelInPlay.usedTermites + "in combat: ";
    }
    //load at the starting of play
    void Awake()
    {
        
        this.transform.Find("Background/BtnChoose").GetComponent<Button>().transform.localScale = new Vector3(0.0001F, 0);

        Button but = this.transform.Find("Background/BtnChoose").GetComponent<Button>();
        but.onClick.AddListener(() => this.changeTargetAttacker());

        this.transform.Find("Background/CombatText").GetComponent<Text>().text ="0 in combat";
        this.transform.Find("Background/AvailableText").GetComponent<Text>().text ="0 available";
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "";
        this.transform.Find("Background/BoosterSpecText").GetComponent<Text>().text = "COLLECTED BOOSTERS";
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = " ";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
        this.transform.Find("Background/CombatText").GetComponent<Text>().text = "";
        this.transform.Find("Background/AvailableText").GetComponent<Text>().text = "";
        this.transform.Find("Background/ColObjText").GetComponent<Text>().text = "";
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
    void Update()
    {

    }
    //clicking on an object load its specs
    public void objectSelected(GenericObject selectedObject)
    {
        deselect();

        selectedObject.select();

        this.refreshCoroutine = refreshInfo();
        StartCoroutine(refreshCoroutine);
        this.selectedObject = selectedObject;
        this.transform.Find("Background/ColObjText").GetComponent<Text>().text = "OBJECT INFO";
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = this.selectedObject.getType();
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "TERMITES: " + this.selectedObject.counter;
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "INTEGRITY: " + (int)this.selectedObject.integrity+"%";
        //button visible
        //move the button
        this.transform.Find("Background/BtnChoose").GetComponent<Button>().enabled = true;
        this.transform.Find("Background/BtnChoose").GetComponent<Button>().transform.position.Set(-115, 35, 0);
        this.transform.Find("Background/BtnChoose").GetComponent<Button>().transform.localScale = new Vector3(1, 1);
        this.transform.Find("Background/BtnChoose").transform.Find("Text").GetComponent<Text>().text = "ATTACKER";

    }
    //deselecting an object reload main infos
    public void objectDeselected()
    {
        selectedObject.deselect();
        this.transform.Find("Background/BtnChoose").GetComponent<Button>().transform.localScale = new Vector3(0.0001F, 0);

        this.transform.Find("Background/BtnChoose").GetComponent<Button>().enabled = false;
        this.selectedObject = null;
        this.transform.Find("Background/ColObjText").GetComponent<Text>().text = "";
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "";
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
    }
    //select and deselect colony
    public void colonySelected(Colony selectedColony)
    {
        deselect();

        selectedColony.select();
        this.refreshCoroutine = refreshInfo();
        StartCoroutine(refreshCoroutine);
        this.selectedColony = selectedColony;
        this.transform.Find("Background/ColObjText").GetComponent<Text>().text = "COLONY INFO";
        List<int> boosterColony = new List<int>();
     
        for (int i = 0; i < 6; i++)
        {
            boosterColony.Add(0);
        }
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "TERMITES AVAILABLE: " + this.selectedColony.getTermites();
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "SPLIT COLONY";
        //button visible
        this.transform.Find("Background/BtnChoose").GetComponent<Button>().enabled = true;
        this.transform.Find("Background/BtnChoose").GetComponent<Button>().transform.localScale = new Vector3(1, 1);
        this.transform.Find("Background/BtnChoose").transform.Find("Text").GetComponent<Text>().text = "TARGET";
        //move the button
        this.transform.Find("Background/BtnChoose").GetComponent<Button>().transform.position.Set(-275, 35, 0);
        //splitter is  visible
        this.transform.Find("Background/SliderColony").GetComponent<Slider>().transform.localScale = new Vector3(1, 1);
        this.transform.Find("Background/SliderColony").GetComponent<Slider>().enabled = true;
        this.transform.Find("Background/SliderColony/MinSlideText").GetComponent<Text>().enabled = true;
        this.transform.Find("Background/SliderColony/MaxSlideText").GetComponent<Text>().enabled = true;
        this.transform.Find("Background/MaxSlideText").GetComponent<Text>().text = "" + (this.selectedColony.getTermites()-1);
        this.transform.Find("Background/MinSlideText").GetComponent<Text>().text = "1";
        this.transform.Find("background/SliderColony").GetComponent<Slider>().minValue = 1;
        this.transform.Find("background/SliderColony").GetComponent<Slider>().maxValue = (this.selectedColony.getTermites() - 1);

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
        this.transform.Find("Background/IronImg/IronText").GetComponent<Text>().text = "" + boosterColony[0];
        this.transform.Find("Background/GiantImg/GiantText").GetComponent<Text>().text = "" + boosterColony[1];
        this.transform.Find("Background/MushImg/MushText").GetComponent<Text>().text = "" + boosterColony[2];
        this.transform.Find("Background/MaskImg/MaskText").GetComponent<Text>().text = "" + boosterColony[3];
        this.transform.Find("Background/ShieldImg/ShieldText").GetComponent<Text>().text = "" + boosterColony[4];
        this.transform.Find("Background/QueenImg/QueenText").GetComponent<Text>().text = "" + boosterColony[5];
    }

    public void colonyDeselected()
    {
        selectedColony.deselect();
        this.selectedColony = null;
        this.transform.Find("Background/ColObjText").GetComponent<Text>().text = "";
        this.transform.Find("Background/BoosterSpecText").GetComponent<Text>().text = "COLLECTED BOOSTERS";
        this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "";
        this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
        this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
        //button not visible
        this.transform.Find("Background/BtnChoose").GetComponent<Button>().enabled = false;
        this.transform.Find("Background/BtnChoose").GetComponent<Button>().transform.localScale = new Vector3(0.0001F, 0);
        //splitter is not visible
        this.transform.Find("Background/SliderColony").GetComponent<Slider>().transform.localScale = new Vector3(0.0001F, 0);
        this.transform.Find("Background/SliderColony").GetComponent<Slider>().enabled = false;
        this.transform.Find("Background/MinSlideText").GetComponent<Text>().enabled = false;
        this.transform.Find("Background/MaxSlideText").GetComponent<Text>().enabled = false;
        this.transform.Find("Background/MinSlideText").GetComponent<Text>().text = "";
        this.transform.Find("Background/MaxSlideText").GetComponent<Text>().text = "";

        //set booster on screen by type of the level
        if (this.levelInPlay)
        {
            List<int> boosterColony = new List<int>();
            this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "";
            this.transform.Find("Background/TermitesText").GetComponent<Text>().text = "";
            this.transform.Find("Background/IntegrityText").GetComponent<Text>().text = "";
            this.transform.Find("Background/CombatText").GetComponent<Text>().text = this.levelInPlay.usedTermites + "in combat";
            this.transform.Find("Background/AvailableText").GetComponent<Text>().text = this.levelInPlay.availableTermites + " available";
            //scan booster of level and divide by type: in the end, refresh indicators on the bar
            List<Booster> levelBoosters = this.levelInPlay.collectedBoosters;
            foreach (Booster booster in levelBoosters)
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
        } 
    }
    void deselect()
    {
        if (refreshCoroutine != null)
        {
            StopCoroutine(refreshCoroutine);
            refreshCoroutine = null;
        }
        
        if (selectedColony)
            colonyDeselected();
        if (selectedObject)
            objectDeselected();
    }

    public void changeTargetAttacker()
    {
        Debug.Log("CLIC");
        if (selectedObject)
            colonySelected(selectedObject.getAttacker());
        if (selectedColony)
            objectSelected(selectedColony.getTarget());
    }
    //method to handle the sliding and next splitting of the colony selected
    public void onSplitting()
    {
        //when you slide, the value on the left will be refreshed
        this.transform.Find("Background/MinSlideText").GetComponent<Text>().text = ""+this.transform.Find("Background/SliderColony").GetComponent<Slider>().value;
            //if user raise up the button, i handle the splitting

        if (Input.GetMouseButtonUp(0))
        {
            //refresh num of termite in new colony and old one
            int numOfSplitted = (int)this.transform.Find("Background/SliderColony").GetComponent<Slider>().value;
            this.selectedColony.addTermites(-numOfSplitted);
            this.transform.Find("Background/MaterialText").GetComponent<Text>().text = "TERMITES AVAILABLE: " + this.selectedColony.getTermites();



        }
    }
}
