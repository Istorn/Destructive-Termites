using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
public class GenericChallenge : MonoBehaviour
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
    public void setChallenge(int id, int time, String Description, List<Booster> rewards, int score)
    {
        this.id = id;
        this.time = time;
        this.Description = Description;
        this.rewards = rewards;
        this.score = score;
    }
    public TypeChallenge ChallengeType = 0;
    private int id = 0;
    private int time = 0;
    private String Description = "";
    private Boolean completed = false;
    private Boolean active = false;
    private List<Booster> rewards = null;
    private int score = 0;
    public int getId()
    {
        return this.id;
    }
    public int getTime()
    {
        return this.time;
    }
    public String getDescription()
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
    public List<Booster> getRewards()
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
    
}
