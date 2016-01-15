using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
public class GenericChallenge
{
    public enum TypeChallenge
    {
        [Category("DESTRUCTION CHALLENGE")]
        Destruction = 0,
        [Category("DEFENSE CHALLENGE")]
        Defense = 1,
        [Category("TIME DESTRUCTION CHALLENGE")]
        TimeDestruction = 2,
        [Category("TIME DEFENSE CHALLENGE")]
        TimeDefense = 3
    }
    //SET VALUES FOR THE CHALLENGE
    public void setChallenge(int id, int time, String Description, Booster.Model rewards, int score, TypeChallenge typeChl)
    {
        this.id = id;
        this.time = time;
        this.Description = Description;
        this.rewards = rewards;
        this.score = score;
        this.ChallengeType = typeChl;
    }
    //ATTRIBUTES
    public TypeChallenge ChallengeType = 0;
    private int id = 0;
    private int time = 0;
    public String Description = "";
    private Boolean completed = false;
    private Boolean active = false;
    private Booster.Model rewards= 0;
    private int score = 0;
    private bool failed = false;

    //GENERAL GETTERS
    public int getId()
    {
        return this.id;
    }
    public int getTime()
    {
        return this.time;
    }
    
    public virtual String getDescription()
    {
        return this.Description;
    }
    public Boolean getCompleted()
    {
        return this.completed;
    }
    public Boolean getActive()
    {
        return this.completed;
    }
    public Booster.Model getRewards()
    {
        return this.rewards;
    }
    public int getScore()
    {
        return this.score;
    }
    public TypeChallenge getTypeChallenge()
    {
        return this.ChallengeType;
    }

    //SETTERS
    public virtual void setDescription(String DescriptionToSet)
    {
        this.Description = DescriptionToSet;
    }
    public void setCompleted()
    {
        this.completed = true;
    }
    public void setActive()
    {
        active = true;
    }
    protected virtual void Awake()
    {
        active = false;

    }
    public void setTime(int timeToset)
    {
        this.time = timeToset;
    }
    public void setFailed()
    {
        this.failed = true;
    }
}
