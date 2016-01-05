using UnityEngine;
using System.Collections;

public class DroppableBooster : MonoBehaviour {

    private Booster booster = null;

    void Awake()
    {
        setModel(Booster.Model.IronDenture);
    }

    public void setModel(Booster.Model model)
    {
        booster = Booster.initFromModel(model);
        gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Boosters/Booster_" + (int)model);
    }
    void OnMouseDown(){
        GameManager.getCurrentLevel().dropBooster(booster);
	}
	
	void FixedUpdate () 
    {
        transform.Rotate(new Vector3 (0, 70, 0) * Time.deltaTime);
    }
}
