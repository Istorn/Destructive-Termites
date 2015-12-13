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
	private bool isDragging;
	
	
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
	
	// Update is called once per frame
	void Update () {
		if (isDragging){
			//suivre le curseur
		}
	}
	
	public void AddBooster(Booster booster){
		boosters.Push(booster);
		if(boosters.Count > 0){
			stackTxt.text = boosters.Count.ToString();
		}
		ChangeSprite(booster.spriteNeutral, booster.spriteHighlighted);
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
	
	// void OnMouseDrag() {
		// // le logo suit la souris
		// Debug.Log("mouseDrag");
	// }
	// void OnMouseDown() {
		// Debug.Log("MouseDown");
	// }
	
	void OnGUI(){ // TO DO : DEBUG CHECKING IF THE POINTER IS ON THE CURRENT SLOT AND NOT IN A RANDOM PLACE
		if (EventSystem.current.IsPointerOverGameObject() && Event.current.type == EventType.MouseDown) {
			isDragging = true;
		}
		if (Event.current.type == EventType.MouseUp) {
			isDragging = false;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			// Casts the ray and get the first game object hit
			Physics.Raycast(ray, out hit);
			Vector3 hitpoint = hit.point;
			Debug.Log("hey");

		}
		
	}
	
	 // void OnGUI()
 // {
     // if(this.Contains(Event.current.mousePosition))
     // {
         // if(Event.current.type == EventType.MouseDown)
         // {
             // buttonPressed = true;
         // }
         // if(Event.current.type == EventType.MouseUp)
         // {
             // buttonPressed = false;
         // }
     // }
     // if(buttonPressed && Event.current.type == EventType.MouseDrag)
     // {
         // buttonRect.x += Event.current.delta.x;
         // buttonRect.y += Event.current.delta.y;
     // }
     // GUI.Button(buttonRect, "Draggable Button");
 // }
}
