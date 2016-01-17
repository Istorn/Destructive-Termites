using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ChallengeDisplay : MonoBehaviour
{
    private GenericChallenge challenge = null;
    public Text goal = null;
    public Text progress = null;
    public Image reward = null;

    private IEnumerator timerCoroutine = null;

    void Start()
    {
        timerCoroutine = timer();
    }

    public void setChallenge(GenericChallenge challenge)
    {
        this.challenge = challenge;
        if (challenge == null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = timer();
            goal.text = "NO ACTIVE CHALLENGE";
            progress.text = "";
            reward.gameObject.SetActive(false);
            
        }
        else
        {
            GameManager.changeGameState(false);
            goal.text = challenge.getGoal();
            int b = (int)challenge.getBoosterRewards();
            reward.sprite = Resources.LoadAll<Sprite>("GUI/Boosters/Booster_" + b)[0];
            reward.gameObject.SetActive(true);
            StartCoroutine(timerCoroutine);
        }
    }

    public void updateProgress()
    {
        if (challenge != null)
        {
            if (challenge.getStatus() == GenericChallenge.Status.Completed)
            {
                progress.color = new Color(0, 1, 0.14f, 1);
                progress.text = "COMPLETED";
            }
            else
                if (challenge.getStatus() == GenericChallenge.Status.Failed)
                {
                    progress.color = new Color(1, 0, 0, 1);
                    progress.text = "FAILED";
                }
                else
                {
                    progress.color = new Color(1, 1, 1, 1);
                    this.progress.text = challenge.getProgress();
                }
                    

        }
            
    }

    public void activate()
    {
        ChallengeManager.setActiveChallenge(challenge);
      /* if (challenge.getModel() == GenericChallenge.Model.TimeDestruction || challenge.getModel() == GenericChallenge.Model.TimeSurvive)
            StartCoroutine(timerCoroutine);*/
    }

    private IEnumerator timer()
    {
        while (true)
        {
            if (challenge.getModel() == GenericChallenge.Model.TimeSurvive)
                ((TimeSurviveChallenge)challenge).tick();
            else
                if (challenge.getModel() == GenericChallenge.Model.TimeDestruction)
                    ((TimeDestructionChallenge)challenge).tick();

            if (challenge.getStatus() == GenericChallenge.Status.Failed)
            {
                //giveUp();
                Debug.Log("OVER");
                StopCoroutine(timerCoroutine);
                break;
            }
            yield return new WaitForSeconds(1);
        }
    }


    
}