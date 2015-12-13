using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour {
	private Stack<Booster> boosters;
	public Text stackTxt;
	public Sprite emptySlot;
	public Sprite highlightedEmptySlot;
	public Sprite boosterIcon;
	private bool isDragging;
	private Draggable draggableComponent;
 
   
	// Use this for initialization
	void Start () {
		boosters = new Stack<Booster>();
		RectTransform slotRect = GetComponent<RectTransform>(); // ref to the Slot RectTransform
		RectTransform txtRect = stackTxt.GetComponent<RectTransform>();
		// calculate the scale transform
		int txtScaleFactor = (int) (slotRect.sizeDelta.x * 0.60); // text will be 60% of the slotSize
		// setting min/max text size
		stackTxt.resizeTextMaxSize = txtScaleFactor;
		stackTxt.resizeTextMinSize = txtScaleFactor; 
		txtRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotRect.sizeDelta.x);
		txtRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotRect.sizeDelta.y);
	}
	
	void FixedUpdate () {
		if (IsEmpty && draggableComponent != null){
			Destroy(draggableComponent); // the slot is no more draggable
		}
	}
	
	public void AddBooster(Booster booster){
		if(boosters.Count == 0){
		ChangeSprite(booster.spriteNeutral, booster.spriteHighlighted);
		// stores the icon for a future "clean" dragging
		boosterIcon = booster.spriteNeutral;
		}
		boosters.Push(booster);
		if(boosters.Count > 0){
			stackTxt.text = boosters.Count.ToString();
		}
		draggableComponent = gameObject.AddComponent<Draggable>();; // now the slot can be dragged
	}
	
	private void ChangeSprite(Sprite neutral, Sprite highlight){
		GetComponent<Image>().sprite = neutral;
		SpriteState st = new SpriteState();
		st.highlightedSprite = highlight;
		st.pressedSprite = neutral;
		GetComponent<Button>().spriteState = st;
	}
	
	public bool IsEmpty{
		get{return boosters.Count == 0;}
	}
	
	public Booster CurrentBooster{
		get {return boosters.Peek();}
	}
	
	public Booster GetBoosterFromSlot{
		get {
			if (boosters.Count>0){
				if (boosters.Count ==1){ // if the stack will be empty
					ChangeSprite(emptySlot, highlightedEmptySlot); // change the sprite to an empty one
					stackTxt.text = null;
					// dont destroy Draggable here, or the slot won't come home (in the inventory)
				}else{ // if there will still be a booster in the stack
					stackTxt.text = (boosters.Count-1).ToString();
				}
				return boosters.Pop(); // return a booster from the stack
			}else{
				return null;
			}
		}
		
	}
		
	void OnGUI(){ // TO DO : DEBUG CHECKING IF THE POINTER IS ON THE CURRENT SLOT AND NOT IN A RANDOM PLACE
		if (EventSystem.current.IsPointerOverGameObject() && Event.current.type == EventType.MouseDown) {
			isDragging = true;
		}
		if (Event.current.type == EventType.MouseUp) {
			isDragging = false;
			// Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			// RaycastHit hit;
			// // Casts the ray and get the first game object hit
			// Physics.Raycast(ray, out hit);
			// Transform hitT = hit.transform;
			// Debug.Log(hitT);		
// // on recup le truc en dessous, si c'est un obj c'est cool appel de truc, sinon rien (msg pr lui dire que trompé ?)
// // if released on a colony/object : 
// // Colony targettedCol = targettedObj.getAttacker();
// // targettedCol.applyBooster( % Stacks<Boosters>.Pop() )
		}
		
	}
	
	 // void OnGUI()
 // {
     // if(this.Contains(Event.current.mousePosition)){
         // if(Event.current.type == EventType.MouseDown){
             // buttonPressed = true;
         // }
         // if(Event.current.type == EventType.MouseUp){
             // buttonPressed = false;
         // }
     // }
     // if(buttonPressed && Event.current.type == EventType.MouseDrag){
         // buttonRect.x += Event.current.delta.x;
         // buttonRect.y += Event.current.delta.y;
     // }
     // GUI.Button(buttonRect, "Draggable Button");
 // }
}
