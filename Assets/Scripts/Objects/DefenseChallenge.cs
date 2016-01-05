using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class DefenseChallenge : GenericChallenge {
    private int menaceId = 0;
    private String menaceText = "";
    protected override void Awake()
    {
        this.ChallengeType = (TypeChallenge) 1;

    }
    public void setMenace(int menaceID, String menaceText)
    {
        this.menaceId = menaceID;
        this.menaceText = menaceText;
    }
}
