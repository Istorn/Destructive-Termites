using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
public class GenericChallenge
{
    public enum Model
    {
        [Category("DESTRUCTION CHALLENGE")]
        Destruction = 0,
        [Category("TIME DESTRUCTION CHALLENGE")]
        TimeDestruction = 1,
        [Category("TIME SURVIVE CHALLENGE")]
        TimeSurvive = 2
    }

    public enum Status
    {
        [Category("AVAILABLE")]
        Available = 0,
        [Category("ACTIVE")]
        Active = 1,
        [Category("COMPLETED")]
        Completed = 2,
        [Category("FAILED")]
        Failed = 3
    }

    private int id = 0;
    private ChallengePauseDisplay challengePauseDisplay = null;
    protected Model model = 0;
    protected Status status;
    private Booster.Model boosterReward;
    private int scoreReward;

    public void setChallenge(int id, Booster.Model boosterReward, int scoreReward)
    {
        this.id = id;
        this.boosterReward = boosterReward;
        this.scoreReward = scoreReward;
    }
    
    public virtual string getGoal()
    {
        return "";
    }

    public int getId()
    {
        return id;
    }

    public Status getStatus()
    {
        return status;
    }

    public Booster.Model getBoosterRewards()
    {
        return boosterReward;
    }

    public int getScoreReward()
    {
        return scoreReward;
    }

    public void setStatus(Status status)
    {
        this.status = status;
        if (status == Status.Completed)
        {
            ChallengeManager.challengeCompleted();
            GameManager.getCurrentLevel().dropBooster(boosterReward);
        }
    }

    public void setChallengePauseDisplay(ChallengePauseDisplay challengePauseDisplay)
    {
        this.challengePauseDisplay = challengePauseDisplay;
    }

    public ChallengePauseDisplay getChallengePauseDisplay()
    {
        return challengePauseDisplay;
    }

    public Model getModel()
    {
        return model;
    }

    public virtual string getProgress()
    {
        return "";
    }
}
