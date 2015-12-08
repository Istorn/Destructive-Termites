﻿using System;
using UnityEngine;

public class Booster : MonoBehaviour {
		// set 1 if the prefab is this kind of booster
		public bool ironDenture; 
		public bool mushroom;
		
		// common attributes
		public string Name;
		public string Description;
		public float timeDuration;
		public float timeLeft; //set to private when done with testing
		public bool isHiddenInObject;
		public bool isCollectedFromScene; //set to private when done with testing
		public bool isActivated; //set to private when done with testing
		
		void Start(){
			timeLeft = timeDuration;
		}
		
		void FixedUpdate(){	
			// monitors the remaining activation time of the booster
			if (this.isActivated){
				timeLeft -= Time.deltaTime;
				if ( timeLeft < 0 ){
					Destroy(gameObject);
				}
			}
		}
		
		public void collectBooster() { // collects the booster
			foreach (Transform child in this.transform) {
				GameObject.Destroy(child.gameObject);
			}
			// increment infobar counter			
		}
		
		/*void activateBooster(Colony targetColony){
				// add the booster to the colony arraylist (call ~ colony.addBooster(this) )
				// remove 1 from the infobar place for this kind of booster
				this.isActivated = true;
		}*/
		
		// is called by unity when Destroy(gameobject) is reached.
		void OnDestroy() {
			// remove booster from Colony's ones
			// warns the user about destruction/end booster ?
			Debug.Log("time out booster");
		}
		
	// uncomment when you're sure.
	/*	public Booster (GenericObject attachedObj){
			this.isHiddenInObject = true;
		}
	*/	
	
	// the "oldbooster"
	/*public int Booster(int effectToset, int timeToset) 
    {
        if ((effectToset!=0) && (timeToset != 0))
        {
            this.Effect = effectToset;
            switch (effectToset)
            {
                case 1:
                    {
                        this.EffectStr = "Iron Denture";
                        this.Description = "Feel free to bite hard objects !";
                        return 1;
                    }; break;
                case 2:
                    {
                        this.EffectStr = "Mushroom";
                        this.Description = "Flesh can now be your dinner !";
                        return 1;
                    }; break;
                case 3:
                    {
                        this.EffectStr = "Life Holder";
                        this.Description = "Death? No more!";
                        return 1;
                    }; break;
                case 4:
                    {
                        this.EffectStr = "Termites's Queen";
                        this.Description = "Let your colony grow up!";
                        return 1;
                    }; break;
                case 5:
                    {

                    }
            }
        }
        else
        {
            return -1;
        }
    }*/	
}

