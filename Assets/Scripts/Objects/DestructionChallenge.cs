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
    public TypeDestr typeDestruction = 0;
    public Model modelObj = 0;
    public int numOfobject=0;
	protected override void Awake()
    {
        this.ChallengeType = 0;
        
    }
    //GENERIC SETTERS AND GETTERS
    public void setDestruction(TypeDestr destructionType)
    {
        this.typeDestruction = destructionType;
    }
    public void setObjectType(Model objectType)
    {
        this.modelObj = objectType;
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
}
