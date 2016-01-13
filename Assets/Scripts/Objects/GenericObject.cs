using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.UI;
using System;

public class GenericObject : MonoBehaviour {

    public enum Model {
        
        [Category("SOFT OBJECT"), Description("THIS OBJECT IS ALWAYS EATABLE")]
        Soft = 0,
        [Category("HARD OBJECT"), Description("USE 'IRON DENTURE' TO EAT IT")]
        Hard = 1,
        [Category("LIVE OBJECT"), Description("USE 'MUSHROOM' TO ATTACK IT")]
        Live = 2/*,
        [Category("NOT EATABLE"), Description("THIS OBJECT IS NOT EATABLE")]
        NotEatable = 3*/
    }

    protected Model model = Model.Soft;

    private int id = 0;

    protected string _name = "";

    protected float integrity = 100.0f;

    private Colony attacker = null;

    private Room room = null;

    protected GameObject selector = null;

    protected Color color;

    protected virtual void Awake()
    {
        attacker = null;
        selector = transform.Find("Selector").gameObject;
        selector.GetComponent<ObjectSelector>().setObj(this);
        
    }

    public void setRoom(Room room)
    {
        this.room = room;
    }

    public Room getRoom()
    {
        return room;
    }

    public int getId()
    {
        return id;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public int getIntegrity()
    {
        return Convert.ToInt32(integrity);
    }

    public string getName()
    {
        return _name;
    }

    public virtual bool attack(int numberOfAttackers)
    {
        return true;
    }

    public void setAttacker(Colony attacker)
    {
        this.attacker = attacker;
    }

    public Colony getAttacker()
    {
        return attacker;
    }

    public virtual void select()
    {
       /* Color transparentColor = new Color(1, 0, 0, 1);//new Color(color.r, color.g, color.b, 0.5f);
        GetComponent<Renderer>().material.color = transparentColor;*/
    }

    public virtual void deselect()
    {
       /* //Color transparentColor = new Color(color.r, color.g, color.b, 1f);
        GetComponent<Renderer>().material.color = color;*/
    }

    

    public string getCategory()
    {
        return Utils.GetEnumCategory(model);
    }

    public string getDescription()
    {
        return Utils.GetEnumDescription(model);
    }

    public Model getModel()
    {
        return model;
    }

	void dropABooster(){
		int maxDroppableTypes = 2;
        int boosterIdToDrop = UnityEngine.Random.Range(1, maxDroppableTypes + 1);   // creates a number between 1 and maxDroppableTypes
		switch (boosterIdToDrop)
            {
                case 1:
                    {
						GameObject droppedBooster = Instantiate(Resources.Load("Prefabs/Boosters/DroppableBooster", typeof(GameObject))) as GameObject;
						droppedBooster.GetComponent<Transform>().position = this.transform.position;
                        droppedBooster.GetComponent<DroppableBooster>().setModel(Booster.Model.IronDenture);

                    };
                    break;
                case 2:
                    {
                        GameObject droppedBooster = Instantiate(Resources.Load("Prefabs/Boosters/DroppableBooster", typeof(GameObject))) as GameObject;
                        droppedBooster.GetComponent<Transform>().position = this.transform.position;
                        droppedBooster.GetComponent<DroppableBooster>().setModel(Booster.Model.Mushroom);
                    };
                    break;
                // case 3:
                    // {
						
                    // };
                    // break;
                // case 4:
                    // {
						
                    // };
                    // break;
                // case 5:
                    // {
						
                    // };
                    // break;
                // case 6:
                    // {
						
                    // }; break;
            }
	}
}
