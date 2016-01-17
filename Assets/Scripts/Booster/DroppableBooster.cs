using UnityEngine;
using System.Collections;

public class DroppableBooster : MonoBehaviour {

    private Booster.Model model;

    void Awake()
    {
        setModel(Booster.Model.IronDenture);
    }

    public void setModel(Booster.Model model)
    {
        this.model = model;
        gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Boosters/Booster_" + (int)model);
    }
    void OnMouseDown(){
        GameManager.getCurrentLevel().dropBooster(model);
	}
	
	void FixedUpdate () 
    {
        transform.Rotate(new Vector3 (0, 70, 0) * Time.deltaTime);
    }
}
