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
	public float iconWidth = 1;
	public float iconHeight = 1;
	public Vector3 iconPosition = new Vector3( 10, 5, 0 );
 
   
	
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
			// boosterIcon.GetComponent<SpriteRenderer>().enabled = true; 
			// set the position
//boosterIcon = Input.mousePosition;
			//suivre le curseur
		}
	}
	
	public void AddBooster(Booster booster){
		boosters.Push(booster);
		if(boosters.Count > 0){
			stackTxt.text = boosters.Count.ToString();
		}
		ChangeSprite(booster.spriteNeutral, booster.spriteHighlighted);
		// stores the icon for a future dragging
		boosterIcon = booster.spriteNeutral;
		// boosterIcon.GetComponent<SpriteRenderer>().enabled = false;

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
	
	public void OnDrag(PointerEventData eventData){
        // cursor.transform.position = Input.mousePosition;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Debug.Log("jesuislà");
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
			// // if ( hitT.parent is Booster){
				// // Debug.Log("booster hitted");
			// // }
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
