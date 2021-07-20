using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions to complete:
/// - Initial Stats
/// - Return Battle Points
/// - Deal Damage
/// </summary>
public class Character : MonoBehaviour
{
    public DanceTeam danceTeam; // Call a reference to the DanceTeam script
    public CharacterName charName; // This is a reference to an instance of the characters name script.
    public FightManager fightDoDamage; // reference to fightManager script

    [Range(0.0f,1.0f)]
    public float mojoRemaining = 1; // This is the characters hp this is a float 0-100 but is normalised to 0.0 - 1.0;

    [Header("Stats")]
    /// <summary>
    /// Our current level.
    /// </summary>
    public int level;

    /// <summary>
    /// The current amount of xp we have accumulated.
    /// </summary>
    public int currentXp;

    /// <summary>
    /// The amount of xp required to level up.
    /// </summary>
    public int xpThreshold = 10;

    /// <summary>
    ///  The amount of XP to distribute to the stats.
    /// </summary>
    public int xpToDistribute = 0;

    /// <summary>
    /// Our variables used to determine our fighting power.
    /// </summary>
    public int style;
    public int luck;
    public int rhythm;

    /// <summary>
    ///  Our variable for max style, luck and rhythm.
    /// </summary>
    public int maxStyle = 5; // max style that can be generated
    public int maxLuck = 10; // max luck that can be generated 
    public int maxRhythm = 20; // max rhythm that can be generated

    /// <summary>
    /// Our physical stats that determine our dancing stats.
    /// </summary>
    public int agility;
    public int intelligence;
    public int strength;

    /// <summary>
    /// Used to determine the conversion of 1 physical stat, to 1 dancing stat.
    /// </summary>
    public float agilityMultiplier = 0.5f;
    public float strengthMultiplier = 1f;
    public float intelligenceMultiplier = 2f;

    /// <summary>
    /// A float used to display what the chance of winning the current fight is.
    /// </summary>
    public float perecentageChanceToWin;


    [Header("Related objects")]
    public DanceTeam myTeam; // This holds a reference to the characters current dance team instance they are assigned to.

    public bool isSelected; // This is used for determining if this character is selected in a battle.

    [SerializeField]
    protected TMPro.TextMeshPro nickText; // This is just a piece of text in Unity,  to display the characters name.
 
    public AnimationController animController; // A reference to the animationController, is used to switch dancing states.

    // This is called once, this then calls Initial Stats function
    void Awake()
    {
        animController = GetComponent<AnimationController>();
        GeneratePhysicalStatsStats(); // we want to generate some physical stats.
        CalculateDancingStats();// using those physical stats we want to generate some dancing stats.
    }

    /// <summary>
    /// This function should set our starting stats of Agility, Strength and Intelligence
    /// to some default RANDOM values.
    /// </summary>
    public void GeneratePhysicalStatsStats()
    {
        int Min = 1; // int minimum
        int agilityMin = 2; // agility minimum set at 2 so that when we use the agility multiplier we dont get a value of 0.5
        int Max = 10; // int max

        agility = Random.Range(agilityMin, Max);

        strength = Random.Range(Min, Max);

        intelligence = Random.Range(Min, Max);

        {
            Debug.Log("Physical stats have been randomly generated. " + " Agility: " + agility + " Intelligience: " + intelligence + " Strength: " + strength);
        }

            Debug.LogWarning("Physical Stats randomly Generated");
        
    }

    /// <summary>
    /// This function should set our style, luck and ryhtmn to values
    /// based on our currrent agility,intelligence and strength.
    /// </summary>
    public void CalculateDancingStats()
    {
        style = (int)((float)(agility) * (float)agilityMultiplier);  // style set by multiply agility by the muliplier, both as a float then returned as an int
        luck = (int)((float)(strength) * (float)strengthMultiplier); // luck set by multiply strength by the multiplier
        rhythm = (int)((float)(intelligence) * (float)intelligenceMultiplier); // rhythm set by multiply intelligence by the multiplier
        {
            Debug.Log("Dance stats have been set, Style: " + style + " Luck: " + luck + " Rhythm: " + rhythm);
        }


        Debug.LogWarning("Generate Calculate Dancing Stats has been called");
      
    }


    /// <summary>
    /// This is takes in a normalised value i.e. 0.0f - 1.0f, and is used to display our % chance to win.
    /// </summary>
    /// <param name="normalisedValue"></param>
    public void SetPercentageValue(float normalisedValue)
    {

        // Essentially we want to set our percentage to win, to be a percentage using our normalised value (decimal value of a fraction)
        // How can we convert out normalised value into a whole number?
              
        const int r = 100;

        float maxLevel = (float)(maxStyle + maxLuck + maxRhythm); // used to calculate a max level to compare to player level
        float playerLevel = (float)(style + luck + rhythm); // players current level that we'll use 
                                                            // float opponentLevel = (opponentStyle + opponentLuck + opponentRhythm);

        normalisedValue = (playerLevel / maxLevel); // should give us a normalised value, if it doesn't then I need to rethink this
        {
            Debug.Log("Player normalised value between 0.0 and 1.0 is :" + normalisedValue);
        }

        perecentageChanceToWin = (int)(normalisedValue * r); // multiply the normalised value by 100 to give us a percent chance to win
        {
            Debug.Log("Max Level: " + maxLevel + "Player is currently at: " + playerLevel + ". Their percent chance to win is:  " + " % " + perecentageChanceToWin);
        }

        Debug.LogWarning("SetPercentageValue has been called normalised value has been converted to a percentage");
    }

    /// <summary>
    /// We probably want to use this to remove some hp (mojo) from our character.....
    /// Then we probably want to check to see if they are dead or not from that damage and return true or false.
    /// </summary>
    public void DealDamage(float amount)
    {
        
        //if(DanceTeam script calls for a removal of character do something about it here)
        // we probably want to do a check in here to see if the character is dead or not...
        // if they are we probably want to remove them from their team's active dancer list...sure wish there was a function in their dance team  script we could use for this.
    }

    /// <summary>
    /// Used to generate a number of battle points that is used in combat.
    /// </summary>
    /// <returns></returns>
    public int ReturnDancePowerLevel()
    {
        // We want to design some algorithm that will generate a number of points based off of our luck,style and rythm, we probably want to add some randomness in our calculation too
        // to ensure that there is not always a draw, by default it just returns 0. 
        // If you right click this function and find all references you can see where it is called.
        // Let's also throw in a little randomness in here, so it's not a garunteed win


        int currentRandomStyle = (style * (Random.Range(1, 3))), currentRandomLuck = (luck * (Random.Range(1, 3))), currentRandomRhythm = (rhythm * (Random.Range(1, 2)));
        int MaxStyleMultiplier = 3, MaxLuckMultiplier = 3, MaxRhythmMultiplier = 2; // 

        int maxRandomStyle = (maxStyle * MaxStyleMultiplier), maxRandomLuck = (maxLuck * MaxLuckMultiplier), maxRandomRhythm = (maxRhythm * MaxRhythmMultiplier);
        float maxRandomPower = (maxRandomStyle + maxRandomLuck + maxRandomRhythm);

        float danceRandomPower = (currentRandomStyle + currentRandomLuck + currentRandomRhythm);

        int returnRandomDancingPower = (int)((danceRandomPower / maxRandomPower) * 100);

        string myDebugMessage = "Generating a random power level of : " + danceRandomPower + ". Compare to Max Power: " + maxRandomPower + ". Generates a power level of: " + (returnRandomDancingPower);

        Debug.Log(myDebugMessage);

        Debug.LogWarning("ReturnDancePowerLevel has been called, generated a random power level to use for battle points based on our stats");

        return (returnRandomDancingPower);
    }

    /// <summary>
    /// A function called when the battle is completed and some xp is to be awarded.
    /// The amount of xp gained is coming into this function
    /// </summary>
    public void AddXP(int xpGained)
    {
        int minXp = 1;
        int maxXp = 85;
        if (xpGained == 0) // if no XP gained go to next if statement
        {
            Debug.Log("No XP achieved, try harder!");
        }
        else if (xpGained >= minXp && xpGained <= maxXp) // if Xp is gained between minimum of 1 and maximum of 85 then add xp to current xp, then check to see if we can level up
        {
            currentXp += (xpGained);
            Debug.Log("XP gained is : " + xpGained + " so your current XP is  : " + currentXp);
        }

        xpToDistribute = xpGained; // using xp to distribute taken from the xp gained in battle


        LevelUp();



        Debug.LogWarning("This character needs some xp to be given, the xpGained from the fight was: " + xpGained);
        // we probably want to do something with the xpGained.

        //We probably want to display the xp we just gained, by default it is 0

        // We probably also want to check to see if the player can level up and if so do something....what should we be checking?
    }

    /// <summary>
    /// A function used to handle actions associated with levelling up.
    /// </summary>
    private void LevelUp()
    {
        


        Debug.LogWarning("Level up has been called");
        // we probs want to increase our level....
        // As well as probably want to increase our threshold for when we should level up...based on our current new level
        // Last thing we probably want to do is increase our physical stats...if only we had a function to do that for us.       
    }

    /// <summary>
    /// A function used to assign a random amount of points ot each of our skills.
    /// </summary>

    /*
     * If you want a very simple code to use, I would go like this:

    int numberOfPointsToDistribute = 150;
    int numberOfAttributes = 3;
    int pointsLeft = numberOfPointsToDistribute;
    for(int i = 0; i < numberOfAttributes; i++)
    {
     int randomPoints = Random.Range(0, pointsLeft);
     attributes[i] = randomPoints;
     pointsLeft -= randomPoints;
    }
    One flaw of this script is that the distribution is not evenly made for each attributes: the very first one have higher chance of having the maximum number (since random would pick from [0] to [150]) than the last one (since random would pick from [0 + attribute_1 + attribute_2 + ... + attribute_n-1] to [150]).

    If you want a more even way of doing it, I would go like that:

    Get the average value for each attributes (in our case, 150 / 3 = 50)

    For each attribute, give X points, where X = Mathf.Clamp(0, 150, average + Random.Range(-average, average))
    */





    public void DistributePhysicalStatsOnLevelUp(int PointsPool)
    {




        Debug.LogWarning("DistributePhysicalStatsOnLevelUp has been called " + PointsPool);
        // let's share these points somewhat evenly or based on some forumla to increase our current physical stats
        // then let's recalculate our dancing stats again to process and update the new values.

        CalculateDancingStats();
    }



    /// <summary>
    /// Is called inside of our DanceTeam.cs is used to set the characters name!
    /// </summary>
    /// <param name="characterName"></param>
    public void AssignName(CharacterName characterName)
{
    charName = characterName;
    if(nickText != null)
    {
        nickText.text = charName.nickname;
        nickText.transform.LookAt(Camera.main.transform.position);
        //text faces the wrong way so
        nickText.transform.Rotate(0, 180, 0);
    }
}
}
