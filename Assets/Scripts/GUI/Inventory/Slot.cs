using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Slot : MonoBehaviour {
	private Stack<Booster> boosters;
	public Text stackTxt;
	public Sprite emptySlot;
	public Sprite highlightedEmptySlot;
	
	// Use this for initialization
	void Start () {
		boosters = new Stack<Booster>();
		RectTransform slotRect = GetComponent<RectTransform>(); // ref to the Slot RectTransform
		RectTransform txtRect = GetComponent<RectTransform>();
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
	}
	
	public void AddBooster(Booster booster){
		boosters.Push(booster);
		if(boosters.Count > 1){
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
	
	
	
}
