using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChallengeManager {

    private static List<GenericChallenge> challenges = new List<GenericChallenge>();
    private static GenericChallenge activeChallenge = null;

    public static GenericChallenge getActiveChallenge()
    {
        return activeChallenge;
    }

    public static void setActiveChallenge(GenericChallenge activeChallenge)
    {
        if (activeChallenge != null)
        {
            GameManager.getLevelGUI().getChallengeDisplay().setChallenge(activeChallenge);
        }
        else
        {
            if (ChallengeManager.activeChallenge != null)
            {
                ChallengeManager.activeChallenge.setStatus(GenericChallenge.Status.Failed);
                removeActiveChallenge();
            }
        }
        foreach (GenericChallenge chal in challenges)
            chal.getChallengePauseDisplay().activeChallengeChanged(activeChallenge);
        ChallengeManager.activeChallenge = activeChallenge;
    }

    private static void removeActiveChallenge()
    {
        int index = 0;
        foreach (GenericChallenge c in challenges)
        {
            if (c.getId() == ChallengeManager.activeChallenge.getId())
            {
                challenges.RemoveAt(index);
                break;
            }
            index++;
        }
    }
  
    public static void challengeCompleted()
    {
        removeActiveChallenge();
        activeChallenge.getChallengePauseDisplay().completed();
        activeChallenge = null;
        foreach (GenericChallenge chal in challenges)
            chal.getChallengePauseDisplay().activeChallengeChanged(activeChallenge);
    }

    public static List<GenericChallenge> getChallenges()
    {
        return challenges;
    }

    public static void objectDestroyed(GenericObject obj)
    {
        if (activeChallenge != null)
            if ((activeChallenge.getModel() == GenericChallenge.Model.Destruction) || (activeChallenge.getModel() == GenericChallenge.Model.TimeDestruction))
                ((DestructionChallenge)activeChallenge).objectDestroyed(obj);
    }

    public static void generateChallenges(int number)
    {
        int id = 0;
        challenges.Clear();
        for (int n = 0; n < number; n++)
        {
            GenericObject.Model[] excludedObjectModels = { GenericObject.Model.Live };
            Booster.Model[] excludedBoosterRewards = { Booster.Model.Mushroom, Booster.Model.GiantTermite };
            GenericChallenge c = null;
            GenericChallenge.Model chal = Utils.RandomEnumValue<GenericChallenge.Model>();
            int pointReward = Random.Range(0, 100);
            Booster.Model boosterReward = Utils.RandomEnumValue<Booster.Model>(excludedBoosterRewards);
            switch (chal)
            {
                case GenericChallenge.Model.Destruction:
                    int nTargets = UnityEngine.Random.Range(1, 11);
                    int nModels = UnityEngine.Random.Range(1, 3);
                    List<GenericObject.Model> objectModels = Utils.RandomEnumValues<GenericObject.Model>(nModels, false, excludedObjectModels);
                    c = new DestructionChallenge(objectModels, nTargets);
                    break;
                case GenericChallenge.Model.TimeDestruction:
                    nTargets = UnityEngine.Random.Range(1, 11);
                    nModels = UnityEngine.Random.Range(1, 3);
                    objectModels = Utils.RandomEnumValues<GenericObject.Model>(nModels, false, excludedObjectModels);
                    int seconds = (int)System.Math.Ceiling((float)UnityEngine.Random.Range(60, 181) / 5) * 5;
                    c = new TimeDestructionChallenge(objectModels, nTargets, seconds);
                    break;
                case GenericChallenge.Model.TimeSurvive:
                    nTargets = UnityEngine.Random.Range(1, 11);
                    nModels = UnityEngine.Random.Range(1, 4);
                    List<LiveObject.Model> menaceModels = Utils.RandomEnumValues<LiveObject.Model>(nModels, true);
                    seconds = (int)System.Math.Ceiling((float)UnityEngine.Random.Range(60, 181) / 5) * 5;
                    c = new TimeSurviveChallenge(menaceModels, seconds);
                    break;
            }
            c.setChallenge(id, boosterReward, pointReward);
            challenges.Add(c);
            id++;
        }
    }
}
