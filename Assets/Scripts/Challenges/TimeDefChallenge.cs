using UnityEngine;
using System.Collections;

public class TimeDefChallenge : DefenseChallenge {

    protected override void Awake()
    {
        this.ChallengeType = (TypeChallenge)3;
    }
    public void decreases()
    {
        if (this.getTime() > 1)
        {

            this.setTime(this.getTime() - 1);
        }
    }
    public bool checkTime()
    {
        if (this.getTime() > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
