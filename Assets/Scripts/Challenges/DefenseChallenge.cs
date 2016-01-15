using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class DefenseChallenge : GenericChallenge
{
    private int menaceId = 0;
    private String menaceText = "";
    private LiveObject.Model menace = 0;

    protected override void Awake()
    {
        this.ChallengeType = (TypeChallenge)1;

    }
    //METODO PER ATTIVARE LE MINACCE
    public void setMenace(LiveObject.Model menaceToSet)
    {
        this.menace = menaceToSet;
        this.menaceText =(string) Utils.GetEnumDescription(menaceToSet);

    }
    public LiveObject.Model getMenace()
    {
        return this.menace;
    }
    public String getMenaceText()
    {
        return this.menaceText;
    }
    public Type getTypeOfMenace()
    {
        return this.menace.GetType();
    }

    public override void setDescription(string DescriptionToSet)
    {
        base.setDescription(DescriptionToSet);
        this.Description = this.Description + " " + this.menaceText;
    }
    public override string getDescription()
    {
        return base.getDescription();
    }

}