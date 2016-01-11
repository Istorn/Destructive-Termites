using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChallengesMonitor : MonoBehaviour {

    List<GenericChallenge> challengesInGame = null;
    // ADDER/REMOVER FOR CHALLENGES
    /* 
            A T T E N T I O N: IF WILL BE ADDED A DEFENSE/TIME DEFENSE CHALLENGE, HERE WILL BE STARTED THE RELATIVE MENACE!!!!!
        */
    public void addChallenge(GenericChallenge challengeToAdd)
    {
        this.challengesInGame.Add(challengeToAdd);

    }
    public void removeChallenge(GenericChallenge challengeToRemove)
    {
        this.challengesInGame.Remove(challengeToRemove);
    }

    //check if all time challenges are still valid (this means not timed out), if not, will set them as failed!
    public void checkTimeChallenges()
    {
        for (int i=0; i < this.challengesInGame.Count; i++)
        {
            if ( ( ((int)this.challengesInGame[i].getTypeChallenge())==2 ) || ((int)this.challengesInGame[i].getTypeChallenge()) == 3)
            {
                if (this.challengesInGame[i].getTime() == 0)
                {
                    this.challengesInGame[i].setFailed();
                }
            }
        }
    }
    //active a specific challenge in the game
    public void startChallenge(GenericChallenge ChallengeToStart)
    {
        this.challengesInGame[this.challengesInGame.IndexOf(ChallengeToStart)].setActive();
    }

    //remove a challenge and get all the boosters and score
    private List<Booster> boostersWon(GenericChallenge ChallengeCompleted) {
        if (this.challengesInGame[this.challengesInGame.IndexOf(ChallengeCompleted)].getRewards() != null)
        {
            return this.challengesInGame[this.challengesInGame.IndexOf(ChallengeCompleted)].getRewards();
        }
        else
        {
            return null;
        }
    }
    private int scoreWon(GenericChallenge ChallengeCompleted)
    {
        return this.challengesInGame[this.challengesInGame.IndexOf(ChallengeCompleted)].getScore();
    }
    //TO GET BOOSTERS AND SCORE OF THE CHALLENGE COMPLETED, YOU HAVE TO CALL THIS METHOD!!!!!
    public void finishedChallenge(GenericChallenge ChallengeCompleted, List<Booster> boostersWon, int scoreWon)
    {
        boostersWon = this.boostersWon(ChallengeCompleted);
        scoreWon = this.scoreWon(ChallengeCompleted);
        this.challengesInGame[this.challengesInGame.IndexOf(ChallengeCompleted)].setCompleted();
    }
    //METHODS TO CHECK IF DEFENSE/DESTRUCTION CHALLENGES ARE COMPLETED OR EITHER NOT
    public void checkDefenseChallenges()
    {
        for (int i = 0; i < this.challengesInGame.Count; i++)
        {
            if (((int)this.challengesInGame[i].getTypeChallenge()) == 1)
            {

            }
        }
    }

    public void checkDestructionChallenges()
    {

    }

    private void checksingledef()
    {

    }
    private void checksingleatk()
    {

    }
}
