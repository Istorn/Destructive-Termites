using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeDestructionChallenge : DestructionChallenge {

    private int seconds = 0;

    public TimeDestructionChallenge(List<GenericObject.Model> targetModels, int nTargets, int seconds)
    {
        model = Model.TimeDestruction;
        this.targetModels = targetModels;
        this.nTargets = nTargets;
        this.seconds = seconds;
    }

	public void tick()
    {
        seconds--;
        if (seconds == 0)
            setStatus(Status.Failed);
    }

    public override string getGoal()
    {
        return base.getGoal() + " IN " + seconds + " SECONDS";
    }

    public override string getProgress()
    {
        string leftStr = "";
        int m = seconds / 60;
        int s = seconds - m * 60;
        if (s < 10)
            leftStr = ":0" + s;
        else
            leftStr = ":" + s;

        if (m < 10)
            leftStr = "0" + m + leftStr;
        else
            leftStr = "m" + leftStr;
        return destroyed + "/" + nTargets + "\n" + leftStr;
    }
}
