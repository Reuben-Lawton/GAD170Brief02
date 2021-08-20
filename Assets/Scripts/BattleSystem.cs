using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions to complete:
/// - Do Round
/// - Fight Over
/// </summary>
public class BattleSystem : MonoBehaviour
{
    public DanceTeam teamA,teamB; //References to TeamA and TeamB
    public FightManager fightManager; // References to our FightManager.
    public Character CharName;  // Reference to our Character Script.

    public float battlePrepTime = 2;  // the amount of time we need to wait before a battle starts
    public float fightCompletedWaitTime = 2; // the amount of time we need to wait till a fight/round is completed.
    
    /// <summary>
    /// This occurs every round or every X number of seconds, is the core battle logic/game loop.
    /// </summary>
    /// <returns></returns>
    IEnumerator DoRound()
    {     
        // waits for a float number of seconds....
        yield return new WaitForSeconds(battlePrepTime);

        //checking for no dancers on either team
        if(teamA.allDancers.Count == 0 && teamB.allDancers.Count == 0)
        {                      
            Debug.LogWarning("DoRound called, but there are no dancers on either team. DanceTeamInit needs to be completed");
            // This will be called if there are 0 dancers on both teams.
        }
        else if (teamA.activeDancers.Count > 0 && teamB.activeDancers.Count > 0)
        {            
            Debug.LogWarning("DoRound called, selected a random dancer from each team to dance off and put in the FightEventData below");
           
            Character charA = teamA.activeDancers[Random.Range(0, teamA.activeDancers.Count)]; // picks a random dancer from teamA for the round
            Character charB = teamB.activeDancers[Random.Range(0, teamB.activeDancers.Count)]; // picks a random dancer from TeamB for the round
            fightManager.Fight(charA, charB);
        }
        else
        {
            DanceTeam winner = null;
            
            if (teamA.activeDancers.Count == 0)
            {
                winner = teamB; // if TeamA has 0 remaining active dancers then TeamB is the winner
            }
            else if (teamB.activeDancers.Count == 0)
            {
                winner = teamA; // if TeamB has 0 remaining active dancers then TeamA is the winner
            }                              
           

            //Enables the win effects, and logs it out to the console.
            winner.EnableWinEffects();
            BattleLog.Log(winner.danceTeamName.ToString(), winner.teamColor);

            Debug.Log("DoRound called, but we have a winner so Game Over");
          
        }
    }

    // This is where we can handle what happens when we win or lose.
    public void FightOver(Character winner, Character defeated, float outcome)
    {
        Debug.LogWarning("FightOver called, may need to check for winners and/or notify teams of zero mojo dancers");
        // assign damage...or if you want to restore health if they want that's up to you....might involve the character script.

        CharName.DealDamage(outcome);

        /* defeated.mojoRemaining -= outcome;
        Debug.Log("The outcome from the round is removed from the defeated characters mojo");
        if(defeated.mojoRemaining <= 0)
        {
            
        }
        */

        //calling the coroutine so we can put waits in for anims to play
        StartCoroutine(HandleFightOver());
    }

    /// <summary>
    /// Used to Request A round.
    /// </summary>
    public void RequestRound()
    {
        //calling the coroutine so we can put waits in for anims to play
        StartCoroutine(DoRound());
    }

    /// <summary>
    /// Handles the end of a fight and waits to start the next round.
    /// </summary>
    /// <returns></returns>
    IEnumerator HandleFightOver()
    {
        yield return new WaitForSeconds(fightCompletedWaitTime);
        teamA.DisableWinEffects();
        teamB.DisableWinEffects();
        Debug.LogWarning("HandleFightOver called, may need to prepare or clean dancers or teams and checks before doing GameEvents.RequestFighters()");
        RequestRound();
    }
}
