using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ChallengePauseDisplay : MonoBehaviour
{
    private GenericChallenge challenge = null;
    public Button activateButton = null;
    public Button giveUpButton = null;

    public void setChallenge(GenericChallenge challenge)
    {
        this.challenge = challenge;
        challenge.setChallengePauseDisplay(this);
        setGoal(challenge.getGoal());
        setReward(challenge.getBoosterRewards());
    }

    private void setReward(Booster.Model booster)
    {
        int b = (int)booster;
        transform.Find("Reward").GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("GUI/Boosters/Booster_" + b)[0];
    }

    private void setGoal(string goal)
    {
        transform.Find("Goal").GetComponent<Text>().text = goal;
    }

    public void activate()
    {
        ChallengeManager.setActiveChallenge(challenge);
    }

    public void giveUp()
    {
        ChallengeManager.setActiveChallenge(null);
    }

    public void activeChallengeChanged(GenericChallenge challenge)
    {
        if (challenge != null)
        {
            if (this.challenge.getId().Equals(challenge.getId()))
            {
                activateButton.gameObject.SetActive(false);
                giveUpButton.gameObject.SetActive(true);
            }
            else
            {
                activateButton.gameObject.SetActive(false);
                giveUpButton.gameObject.SetActive(false);
            }
        }
        else
        {
            activateButton.gameObject.SetActive(true);
            giveUpButton.gameObject.SetActive(false);
        }
    }
}