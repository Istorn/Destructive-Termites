using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class DestructionChallenge : GenericChallenge {

    protected List<GenericObject.Model> targetModels = null;
    protected int nTargets = 0;
    protected int destroyed = 0;
    
    public DestructionChallenge()
    {
    }

    public DestructionChallenge(List<GenericObject.Model> targetModels, int nTargets)
    {
        model = GenericChallenge.Model.Destruction;
        this.targetModels = targetModels;
        this.nTargets = nTargets;
    }

    public void objectDestroyed(GenericObject obj)
    {
        if (targetModels.Contains(obj.getModel()) || targetModels == null)
            destroyed++;
        if (nTargets == destroyed)
            setStatus(Status.Completed);
    }

    public override string getGoal()
    {
        string goalStr = "";
        if (nTargets == 1)
        {
            goalStr = "DESTROY A ";
            if (targetModels.Count == 1)
                goalStr += Utils.GetEnumCategory(targetModels[0]);
            else
                if (targetModels.Count > 1)
                {
                    goalStr += Utils.GetEnumCategory(targetModels[0]);
                    for (int i = 1; i < targetModels.Count; i++)
                        goalStr += " OR " + Utils.GetEnumCategory(targetModels[i]);
                }
        }
        else
        {
            goalStr = "DESTROY " + nTargets + " ";
            if (targetModels.Count == 1)
                goalStr += Utils.GetEnumCategory(targetModels[0]) + "S";
            else
                if (targetModels.Count > 1)
                {
                    goalStr += Utils.GetEnumCategory(targetModels[0]) + "S";
                    for (int i = 1; i < targetModels.Count; i++)
                        goalStr += " OR " + Utils.GetEnumCategory(targetModels[i]) + "S";
                }
        }
        return goalStr;
    }
    public override string getProgress()
    {
        return destroyed + "/" + nTargets;
    }

}
