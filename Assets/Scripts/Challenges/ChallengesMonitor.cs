using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChallengesMonitor {

    private static List<GenericChallenge> challengesInGame = null;
    // ADDER/REMOVER FOR CHALLENGES
    /* 
            A T T E N T I O N: IF WILL BE ADDED A DEFENSE/TIME DEFENSE CHALLENGE, HERE WILL BE STARTED THE RELATIVE MENACE!!!!!
        */
    public static void addChallenge(GenericChallenge challengeToAdd)
    {
        challengesInGame.Add(challengeToAdd);

    }
    //GETTER/SETTER ACTIVE CHALLENGE
    public GenericChallenge getActiveChallenge()
    {
        int i = 0;
        while (!(challengesInGame[i].getActive()))
        {
            i++;
        }
        return challengesInGame[i];
    }
    public void setActiveChallenge(GenericChallenge challengetoActive)
    {
        challengesInGame[challengesInGame.IndexOf(challengetoActive)].setActive();
    }
    public static void activeDefenseChallenge(int id)
    {
        challengesInGame[id].setActive();
        //QUI VA SETTATA LA MINACCIA IL METODO RELATIVO È: SETMENACE NELLA CLASSE DEFENSECHALLENGE

    }
    public static void failDefenseChallenge(int id)
    {
        challengesInGame[id].setFailed();
        //QUI VA DISATTIVATA LA MINACCIA MANUALMENTE
    }
    public static void activeDestructionChallenge(int id)
    {
        challengesInGame[id].setActive();
    }
  
    //METHOD TO GET ALL THE CHALLENGES
    public static List<GenericChallenge> getChallenges()
    {
        return challengesInGame;
    }
    //METHOD TO GENERATE 20 CHALLENGES
    public static void generateChallenges()
    {
        Booster.Model boost = Booster.Model.IronDenture;
        challengesInGame = new List<GenericChallenge>();
        //creation of destruction challenges
        for (int i = 0; i < 5; i++)
        {
            DestructionChallenge chl = new DestructionChallenge();
            int TypeDestr =(int) Mathf.Round(Random.Range(0.0F, 2.0F));
            int TypeObj = (int)Mathf.Round(Random.Range(0.0F, 2.0F));
            chl.setDescription();
            chl.setDestruction(TypeDestr);
            chl.setObjectType(TypeObj);
            boost = Booster.Model.IronDenture;
            if ((int)chl.getTypeOfDestruction() > 0)
            {
                chl.setNumOfObj((int)Mathf.Round(Random.Range(2.0F, 5.0F)));
            }
            else
            {
                chl.setNumOfObj(1);
            }
            chl.setChallenge(i, 0, chl.getDescription(), boost , (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl.getTypeChallenge());
            challengesInGame.Add(chl);
        }
        //creation of time destruction
        for (int i = 0; i < 5; i++)
        {
            DestructionChallenge chl = new DestructionChallenge();
            int TypeDestr = (int)Mathf.Round(Random.Range(0.0F, 2.0F));
            int TypeObj = (int)Mathf.Round(Random.Range(0.0F, 2.0F));
            chl.setDescription();
            chl.setDestruction(TypeDestr);
            chl.setObjectType(TypeObj);
            boost = Booster.Model.GasEquipment;
            if ((int)chl.getTypeOfDestruction() > 0)
            {
                chl.setNumOfObj((int)Mathf.Round(Random.Range(2.0F, 5.0F)));
            }
            else
            {
                chl.setNumOfObj(1);
            }
            chl.setChallenge(i+5, (((int)chl.getNumOfObj()*2)*40), chl.getDescription(), boost, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl.getTypeChallenge());
            challengesInGame.Add(chl);
        }
        //creation of defense challenge
        //humans
        for (int i = 0; i < 1; i++)
        {
            DefenseChallenge chl = new DefenseChallenge();


             boost = Booster.Model.GasEquipment;

            chl.setDescription("DEFENSE A COLONY FROM ");//TO ADD MENACE
            chl.setChallenge(i+10, 0, chl.getDescription(), boost, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl.getTypeChallenge());
            challengesInGame.Add(chl);
        }
        //mage
        for (int i = 0; i < 1; i++)
        {
            DefenseChallenge chl = new DefenseChallenge();


            boost = Booster.Model.IronDenture;
            chl.setDescription("DEFENSE A COLONY FROM ");//TO ADD MENACE
            chl.setChallenge(i + 12, 0, chl.getDescription(), boost, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl.getTypeChallenge());
            challengesInGame.Add(chl);
        }
        //frog
        DefenseChallenge chl2 = new DefenseChallenge();


        Booster.Model boost2 = Booster.Model.IronDenture;

        chl2.setDescription("DEFENSE A COLONY FROM ");//TO ADD MENACE
        chl2.setChallenge(14, 0, chl2.getDescription(), boost2, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl2.getTypeChallenge());
        challengesInGame.Add(chl2);
        //TIMED CHALLENGE DEFENSE
        //humans
        for (int i = 0; i < 1; i++)
        {
            DefenseChallenge chl = new DefenseChallenge();


            boost = Booster.Model.GasEquipment;

            chl.setDescription("DEFENSE A COLONY FROM ");//TO ADD MENACE
            chl.setChallenge(i + 15, 180, chl.getDescription(), boost, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl.getTypeChallenge());
            challengesInGame.Add(chl);
        }
        //mage
        for (int i = 0; i < 1; i++)
        {
            DefenseChallenge chl = new DefenseChallenge();


             boost = Booster.Model.IronDenture;
            chl.setDescription("DEFENSE A COLONY FROM ");//TO ADD MENACE
            chl.setChallenge(i + 12, 360, chl.getDescription(), boost, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl.getTypeChallenge());
            challengesInGame.Add(chl);
        }
        //frog
        chl2 = new DefenseChallenge();


         boost = Booster.Model.GasEquipment;
        chl2.setDescription("DEFENSE A COLONY FROM ");//TO ADD MENACE
        chl2.setChallenge(14, 240, chl2.getDescription(), boost2, (int)Mathf.Round(Random.Range(100.0F, 1000.0F)), chl2.getTypeChallenge());
        challengesInGame.Add(chl2);
    }
    public static void removeChallenge(GenericChallenge challengeToRemove)
    {
        challengesInGame.Remove(challengeToRemove);
    }

    //check if all time challenges are still valid (this means not timed out), if not, will set them as failed!
    public static void checkTimeChallenges()
    {
        for (int i=0; i < challengesInGame.Count; i++)
        {
            if ( ( ((int)challengesInGame[i].getTypeChallenge())==2 ) || ((int)challengesInGame[i].getTypeChallenge()) == 3)
            {
                if (challengesInGame[i].getTime() == 0)
                {
                    challengesInGame[i].setFailed();
                }
            }
        }
    }
    //active a specific challenge in the game
    public void startChallenge(GenericChallenge ChallengeToStart)
    {
        challengesInGame[challengesInGame.IndexOf(ChallengeToStart)].setActive();
    }

    //remove a challenge and get all the boosters and score
    private Booster.Model boostersWon(GenericChallenge ChallengeCompleted) {
        
            return challengesInGame[challengesInGame.IndexOf(ChallengeCompleted)].getRewards();
        
       
    }
    private int scoreWon(GenericChallenge ChallengeCompleted)
    {
        return challengesInGame[challengesInGame.IndexOf(ChallengeCompleted)].getScore();
    }
    //TO GET BOOSTERS AND SCORE OF THE CHALLENGE COMPLETED, YOU HAVE TO CALL THIS METHOD!!!!!
    public void finishedChallenge(GenericChallenge ChallengeCompleted, Booster.Model boostersWon, int scoreWon)
    {   
        if (challengesInGame.IndexOf(ChallengeCompleted) == -1)
        {
            if (challengesInGame[challengesInGame.IndexOf(ChallengeCompleted)].getCompleted())
            {
                boostersWon = this.boostersWon(ChallengeCompleted);
                scoreWon = this.scoreWon(ChallengeCompleted);
                challengesInGame[challengesInGame.IndexOf(ChallengeCompleted)].setCompleted();
            }
        }
       
       
    }
    //METHODS TO REFRESH DESTRUCTION CHALLENGE
    public void refreshDestruction(GenericObject ObjectDestroyed)
    {
        for (int i=0; i < challengesInGame.Count; i++)
        {
            if (((int)challengesInGame[i].getTypeChallenge()==0) || ((int)challengesInGame[i].getTypeChallenge() == 2))
            {
                DestructionChallenge Chlg = (DestructionChallenge)challengesInGame[i];
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
                    challengesInGame[i] = Chlg;
                }
            }
        }
    }

    //METHOD TO REFRESH DEFENSE CHALLENGE
    public void refreshDefense(LiveObject menaceToCheck)
    {
        for (int i=0;i<challengesInGame.Count;i++)
        {
            if (((int)challengesInGame[i].getTypeChallenge() == 1) || ((int)challengesInGame[i].getTypeChallenge() == 3)) {
                DefenseChallenge Chlg = (DefenseChallenge)challengesInGame[i];
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
                challengesInGame[i] = Chlg;
            }

        }
    }
}
