using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.UI;
public class Infobar : MonoBehaviour {
    private Text text1,text2,text3 = null;
	// Use this for initialization
	void Start () {
	
	}
	void Awake()
    {
        this.text1=this.transform.Find("Background/Text1").GetComponent<Text>();
        this.text2=this.transform.Find("Background/Text2").GetComponent<Text>();
        this.text3 = this.transform.Find("Background/Text3").GetComponent<Text>();
    }
	// Update is called once per frame
	void Update () {
	
	}
    public void selected(GenericObject selectedObj)
    {
        this.transform.Find("Background/Text1").GetComponent<Text>().text="INTEGRITY: "+selectedObj.getIntegrity().
    }
}
