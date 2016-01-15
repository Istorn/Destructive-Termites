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
    private LiveObject menace = null;

    protected override void Awake()
    {
        this.ChallengeType = (TypeChallenge)1;

    }
    //METODO PER ATTIVARE LE MINACCE
   /* public void setMenace(LiveObject menaceToSet)
    {
        this.menace = menaceToSet;
        this.menaceId = menaceToSet.getId();
        if (menaceToSet.GetType().Equals(typeof(Human)))
        {
            this.menaceText = "HUMAN";
        }
        else if (menaceToSet.GetType().Equals(typeof(Wizard)))
        {
            this.menaceText = "WIZARD";
        }
        else if (menaceToSet.GetType().Equals(typeof(Frog)))
        {
            this.menaceText = "FROG";
        }

    }*/
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
        this.Description = this.Description + " ";//menace
    }
    public override string getDescription()
    {
        return base.getDescription();
    }

}