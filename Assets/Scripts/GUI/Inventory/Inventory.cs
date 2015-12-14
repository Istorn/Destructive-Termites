using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	private RectTransform inventoryRect;
	private float inventoryWidth, inventoryHeight;
	public int slots; 		// number of slots
	public int rows; 		// number of slot rows
	public float slotPaddingLeft, slotPaddingTop; // Left-Top space between each slot
	public float slotSize;	// size of each slot
	public GameObject slotPrefab;
	private List<GameObject> allSlots; //containing all slots of the inventory
	private int emptySlot; // how many empty slots we have in the inventory
	
	void Start(){ 
		CreateLayOut();
	}
	
	private void CreateLayOut(){ // creates the inventory with the given number of slots, with their size
		int columns = slots/rows;
		emptySlot = slots;
		
		allSlots = new List<GameObject>();
		// -> adjust the size to the slots
		// inventoryWidth = columns * (slotSize + slotPaddingLeft) + slotPaddingLeft*0;
		// inventoryHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop*8; // should be slotPaddingTop but too short and can't understand why. If too many rows, still bugs.
		// inventoryRect = GetComponent<RectTransform>();
		// inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
		// inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHeight);
		
		// OR 
		inventoryWidth = 100;
		inventoryHeight = 30;
		slotPaddingTop = (inventoryHeight-slotSize)/2; 				// given by the user but bypass it
		slotPaddingLeft = (inventoryWidth-(slotSize*slots))/slots;	// given by the user but bypass it
		inventoryRect = GetComponent<RectTransform>();
		inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
		inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHeight);
		
		for (int y=0 ; y < rows ; y++){
			for (int x=0 ; x < columns ; x++){
				GameObject newSlot = (GameObject)Instantiate(slotPrefab);
				RectTransform slotRect = newSlot.GetComponent<RectTransform>();
				newSlot.name = "Slot";
				newSlot.transform.SetParent(this.transform.parent); // set inventory's parent (=canvas) as parent of the slot
				slotRect.localPosition = inventoryRect.localPosition + new Vector3(slotPaddingLeft * (x+1) + (slotSize*x), -slotPaddingTop * (y+1) - (slotSize*y));
				slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
				slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);
				allSlots.Add(newSlot);
			}
		}
	}
		
	public bool AddBooster(Booster bToAdd){ // for each created slot, check if it contains the same booster type or add it in an empty slot
		foreach(GameObject slot in allSlots){
			Slot tmp = slot.GetComponent<Slot>();
			if (!tmp.IsEmpty){
				if (tmp.CurrentBooster.type == bToAdd.type){
					tmp.AddBooster(bToAdd);
					return true;
				}
			}
			else{
				PlaceEmpty(bToAdd);
				return true;
			}
		}
		return false;
	}
	
	private bool PlaceEmpty(Booster booster){ // place a booster in an empty slot
		if (emptySlot > 0){
			foreach(GameObject slot in allSlots){
				Slot tmp = slot.GetComponent<Slot>();
				if (tmp.IsEmpty){
					tmp.AddBooster(booster);
					emptySlot--;
					return true;
				}
			}
		}
		return false; //couldnt find any place to place the booster
	}
	
	
}
