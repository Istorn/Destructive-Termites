using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class DestructionChallenge : GenericChallenge {
    //TO SET THE KIND OF DESTRUCTION CHALLENGE
    public enum TypeDestr
    {
        [Category("DESTROY A OBJECT")]
        Single = 0,
        [Category("DESTROY A BUNCH OF OBJECTS")]
        Multiple = 1,
        [Category("DESTROY A BUNCH OF SPECIFIED OBJECTS")]
        MultipleSpec = 2,
        [Category("DESTROY OBJECTS IN A ROOM")]
        RoomDestr = 3
    }
    //TO SET THE KIND OF OBJECT TO DESTROY, WHERE THERE'S
    public enum Model
    {

        [Category("SOFT OBJECT")]
        Soft = 0,
        [Category("HARD OBJECT")]
        Hard = 1,
        [Category("LIVE OBJECT")]
        Live = 2/*,
        [Category("NOT EATABLE"), Description("THIS OBJECT IS NOT EATABLE")]
        NotEatable = 3*/
    }
    private TypeDestr typeDestruction = 0;
    private Model modelObj = 0;
    private int numOfobject=0;
    private int remainedObj = 0;
    
	protected override void Awake()
    {
        this.ChallengeType = 0;
        
    }
    //GENERIC SETTERS AND GETTERS
    public void setDestruction(int destructionType)
    {
        this.typeDestruction = (TypeDestr)destructionType;
    }
    public void setObjectType(int objectType)
    {
        this.modelObj =(Model) objectType;
    }
    public void setNumOfObj(int numOfObjectTodestroy)
    {
        this.numOfobject = numOfObjectTodestroy;
    }
    public int getNumOfObj()
    {
        return this.numOfobject;
    }
    public TypeDestr getTypeOfDestruction()
    {
        return this.typeDestruction;
    }
    public Model getTypeOfObject()
    {
        return this.modelObj;
    }
    public int getRemainedObj()
    {
        return this.remainedObj;
    }

    public void increasesRemainedObj()
    {
        this.remainedObj++;
    }
   public void setDescription()
    {
        String Desc = "";
        //KIND OF DESTRUCTION
        switch ((int)getTypeOfDestruction())
        {
            case 0:
                {
                    Desc += "DESTROY A "+(Utils.GetEnumDescription(this.getTypeOfObject()))+" OBJECT";
                }; break;
            case 1:
                {
                    Desc += "DESTROY "+this.getNumOfObj()+" OBJECTS";
                }; break;
            case 2:
                {
                    Desc += "DESTROY " + this.getNumOfObj()+" "+ (Utils.GetEnumDescription(this.getTypeOfObject())) + " OBJECTS";
                }; break;
        }
        this.Description = Desc;
    }

}
