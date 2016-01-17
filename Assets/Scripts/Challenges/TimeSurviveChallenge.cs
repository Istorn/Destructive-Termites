using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeSurviveChallenge : GenericChallenge {

    protected List<LiveObject.Model> menaces = null;
    private int seconds = 0;
    
    public TimeSurviveChallenge(List<LiveObject.Model> menaces, int seconds)
    {
        model = GenericChallenge.Model.TimeSurvive;
        this.menaces = menaces;
        this.seconds = seconds;
    }

	public void tick()
    {
        seconds--;
        if (seconds == 0)
            setStatus(Status.Completed);
    }

    public override string getGoal()
    {
        string goalStr = "SURVIVE FOR " + seconds + " SECONDS TO ";

        Dictionary<LiveObject.Model, int> manacesDict = Utils.groupCountList<LiveObject.Model>(menaces);

        foreach(KeyValuePair<LiveObject.Model, int> entry in manacesDict)
        {
            if (entry.Value > 1)
                goalStr += entry.Value + " " + Utils.GetEnumCategory(entry.Key) + "S, ";
            else
                goalStr += entry.Value + " " + Utils.GetEnumCategory(entry.Key) + ", ";
        }
        goalStr = goalStr.Remove(goalStr.Length - 2);
        return goalStr;
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
        return leftStr;
    }
}
