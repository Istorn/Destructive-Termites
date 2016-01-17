using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ChallengePauseDisplay : MonoBehaviour
{
    private GenericChallenge challenge = null;
    public Button activateButton = null;
    public Button giveUpButton = null;
    public Text statusOK = null;
    public Text statusNO = null;
    public Text progress = null;

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

    public void setProgress(string progress)
    {
        this.progress.text = progress;
    }

    public void activate()
    {
        ChallengeManager.setActiveChallenge(challenge);
    }

    public void giveUp()
    {
        giveUpButton.gameObject.SetActive(false);
        progress.gameObject.SetActive(false);
        statusNO.gameObject.SetActive(true);
        ChallengeManager.setActiveChallenge(null);
    }

    public void completed()
    {
        giveUpButton.gameObject.SetActive(false);
        progress.gameObject.SetActive(false);
        statusOK.gameObject.SetActive(true);
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