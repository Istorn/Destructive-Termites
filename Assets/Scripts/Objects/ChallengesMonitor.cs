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
    //METHOD TO GET ALL THE CHALLENGES
    public List<GenericChallenge> getChallenges()
    {
        return this.challengesInGame;
    }
    //METHOD TO GENERATE 20 CHALLENGES
    public void generateChallenges()
    {
        if (challengesInGame != null)
        {
            challengesInGame = null;
            //creation of destruction challenges
            for (int i = 0; i < 5; i++)
            {
                DestructionChallenge chl = new DestructionChallenge();
                int TypeDestr =(int) Mathf.Round(Random.Range(0.0F, 2.0F));
                int TypeObj = (int)Mathf.Round(Random.Range(0.0F, 2.0F));
                chl.setDestruction(TypeDestr);
                chl.setObjectType(TypeObj);
                List<Booster> boost = null;
                boost.Add(new IronDenture());
                if ((int)chl.getTypeOfDestruction() > 0)
                {
                    chl.setNumOfObj((int)Mathf.Round(Random.Range(2.0F, 5.0F)));
                }
                else
                {
                    chl.setNumOfObj(1);
                }
                chl.setChallenge(i, 0, chl.getDescription(), boost , (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl.getTypeChallenge());
                this.challengesInGame.Add(chl);
            }
            //creation of time destruction
            for (int i = 0; i < 5; i++)
            {
                DestructionChallenge chl = new DestructionChallenge();
                int TypeDestr = (int)Mathf.Round(Random.Range(0.0F, 2.0F));
                int TypeObj = (int)Mathf.Round(Random.Range(0.0F, 2.0F));
                chl.setDestruction(TypeDestr);
                chl.setObjectType(TypeObj);
                List<Booster> boost = null;
                boost.Add(new Mushroom());
                if ((int)chl.getTypeOfDestruction() > 0)
                {
                    chl.setNumOfObj((int)Mathf.Round(Random.Range(2.0F, 5.0F)));
                }
                else
                {
                    chl.setNumOfObj(1);
                }
                chl.setChallenge(i+5, (((int)chl.getNumOfObj()*2)*40), chl.getDescription(), boost, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl.getTypeChallenge());
                this.challengesInGame.Add(chl);
            }
            //creation of defense challenge
           //humans
            for (int i = 0; i < 1; i++)
            {
                DefenseChallenge chl = new DefenseChallenge();
                chl.setMenace(new Human());

                List<Booster> boost = null;
                boost.Add(new Mushroom());

                chl.setDescription();
                chl.setChallenge(i+10, 0, chl.getDescription(), boost, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl.getTypeChallenge());
                this.challengesInGame.Add(chl);
            }
            //mage
            for (int i = 0; i < 1; i++)
            {
                DefenseChallenge chl = new DefenseChallenge();
                chl.setMenace(new Wizard());

                List<Booster> boost = null;
                boost.Add(new IronDenture());
                boost.Add(new Mushroom());
                chl.setDescription();
                chl.setChallenge(i + 12, 0, chl.getDescription(), boost, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl.getTypeChallenge());
                this.challengesInGame.Add(chl);
            }
            //frog
            DefenseChallenge chl2 = new DefenseChallenge();
            chl2.setMenace(new Wizard());

            List<Booster> boost2 = null;
            boost2.Add(new IronDenture());

            chl2.setDescription();
            chl2.setChallenge(14, 0, chl2.getDescription(), boost2, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl2.getTypeChallenge());
            this.challengesInGame.Add(chl2);
            //TIMED CHALLENGE DEFENSE
            //humans
            for (int i = 0; i < 1; i++)
            {
                DefenseChallenge chl = new DefenseChallenge();
                chl.setMenace(new Human());

                List<Booster> boost = null;
                boost.Add(new Mushroom());
                boost.Add(new IronDenture());

                chl.setDescription();
                chl.setChallenge(i + 15, 180, chl.getDescription(), boost, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl.getTypeChallenge());
                this.challengesInGame.Add(chl);
            }
            //mage
            for (int i = 0; i < 1; i++)
            {
                DefenseChallenge chl = new DefenseChallenge();
                chl.setMenace(new Wizard());

                List<Booster> boost = null;
                boost.Add(new IronDenture());
                boost.Add(new Mushroom());
                chl.setDescription();
                chl.setChallenge(i + 12, 360, chl.getDescription(), boost, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl.getTypeChallenge());
                this.challengesInGame.Add(chl);
            }
            //frog
            chl2 = null;
            chl2.setMenace(new Wizard());

             boost2 = null;
            boost2.Add(new IronDenture());
            boost.Add(new Mushroom());
            chl2.setDescription();
            chl2.setChallenge(14, 240, chl2.getDescription(), boost2, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl2.getTypeChallenge());
            this.challengesInGame.Add(chl2);
        }
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
        if (this.challengesInGame.IndexOf(ChallengeCompleted) == -1)
        {
            if (this.challengesInGame[this.challengesInGame.IndexOf(ChallengeCompleted)].getCompleted())
            {
                boostersWon = this.boostersWon(ChallengeCompleted);
                scoreWon = this.scoreWon(ChallengeCompleted);
                this.challengesInGame[this.challengesInGame.IndexOf(ChallengeCompleted)].setCompleted();
            }
        }
       
       
    }
    //METHODS TO REFRESH DESTRUCTION CHALLENGE
    public void refreshDestruction(GenericObject ObjectDestroyed)
    {
        for (int i=0; i < this.challengesInGame.Count; i++)
        {
            if (((int)this.challengesInGame[i].getTypeChallenge()==0) || ((int)this.challengesInGame[i].getTypeChallenge() == 2))
            {
                DestructionChallenge Chlg = (DestructionChallenge)this.challengesInGame[i];
                if ((int)Chlg.getTypeOfObject() == (int)ObjectDestroyed.getModel())
                {
                    Chlg.increasesRemainedObj();
                    //IF ALL THAT KIND OF OBJ ARE DESTROYED, OF COURSE THE CHALLENGE BECOMES COMPLETED!
                    if (Chlg.getRemainedObj() == Chlg.getNumOfObj())
                    {
                        Chlg.setCompleted();
                    }
                    //IF THE CHALLENGE WAS A TIME DESTRUCTION, THEN THE TIME WILL BE GROUNDED TO ZERO
                    if ((int)Chlg.getTypeChallenge() == 2)
                    {
                        Chlg.setTime(0);
                    }
                    //refresh the challenges' list
                    this.challengesInGame[i] = Chlg;
                }
            }
        }
    }

    //METHOD TO REFRESH DEFENSE CHALLENGE
    public void refreshDefense(LiveObject menaceToCheck)
    {
        for (int i=0;i<this.challengesInGame.Count;i++)
        {
            if (((int)this.challengesInGame[i].getTypeChallenge() == 1) || ((int)this.challengesInGame[i].getTypeChallenge() == 3)) {
                DefenseChallenge Chlg = (DefenseChallenge)this.challengesInGame[i];
                //IF THE MENACE CHECKED IS EQUAL TO THESE CHALLENGES, THEN THEY BECOME COMPLETED
                if ( (Chlg.getTypeOfMenace().Equals(menaceToCheck.GetType().Equals(typeof(Human)))) || (Chlg.getTypeOfMenace().Equals(menaceToCheck.GetType().Equals(typeof(Frog)))) || (Chlg.getTypeOfMenace().Equals(menaceToCheck.GetType().Equals(typeof(Wizard)))) )
                {
                    Chlg.setCompleted();
                }
                //SAME WAY AS DESTRUCTION IF TIMED
                if ((int)Chlg.getTypeChallenge() == 3)
                {
                    Chlg.setTime(0);
                }
                //refresh the challenges' list
                this.challengesInGame[i] = Chlg;
            }

        }
    }
}
