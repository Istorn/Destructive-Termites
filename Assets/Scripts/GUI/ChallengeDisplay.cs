using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ChallengeDisplay : MonoBehaviour
{
    private GenericChallenge challenge = null;

    public void setChallenge(GenericChallenge challenge)
    {
        this.challenge = challenge;
        setGoal(challenge.getDescription());
        setReward(challenge.getRewards());
    }

    private void setReward(Booster.Model booster)
    {
        transform.Find("Reward").GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("GUI/Boosters/Booster_" + (int)booster)[0];
    }

    private void setGoal(string goal)
    {
        transform.Find("Goal").GetComponent<Text>().text = goal;
    }

    void FixedUpdate()
    {

    }
}