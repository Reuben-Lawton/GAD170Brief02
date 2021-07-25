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





    //[HideInInspector]
   // public AnimationController animController; // reference to our animation controller on our character
    [HideInInspector]
    public SFXHandler sfxHandler; // reference to our sfx Handler in our scene
    [HideInInspector]
    public ParticleHandler particleHandler; // a refernce to our particle system that is played when we level up.  
    public UIManager uIManager; // a reference to the UI Manager in our scene.
    public StatsUI statsUI; // a referecence to our stats ui for this character.



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
    /// 

    private void ShowLevelUpEffects()
    {
        // plays the level up sound effect.
        sfxHandler.LevelUp();
        // emits a particle effect to show we have levelled up
        particleHandler.Emit();
        // Displays a UI Message to the player we have levelled up
        uIManager.ShowLevelUI();
    }

    public void GeneratePhysicalStatsStats()
    {

        int Min = 1; // int minimum
        int agilityMin = 2; // agility minimum set at 2 so that when we use the agility multiplier we dont get a value of 0.5
        int Max = 10; // int max

        agility = Random.Range(agilityMin, Max);

        strength = Random.Range(Min, Max);

        intelligence = Random.Range(Min, Max);
        Debug.LogWarning("Generate Physical Stats has been called");

        {
            Debug.Log("Physical stats have been randomly generated. " + " Agility: " + agility + " Intelligience: " + intelligence + " Strength: " + strength);
        }

        Debug.LogWarning("Physical Stats randomly Generated");

        // Let's set up agility, intelligence and strength to some default Random values.
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
        const int r = 100;

        float maxLevel = (float)(maxStyle + maxLuck + maxRhythm); // used to calculate a max level to compare to player level
        float playerLevel = (float)(style + luck + rhythm); // players current level that we'll use 
                                                            
        normalisedValue = (playerLevel / maxLevel); // should give us a normalised value, if it doesn't then I need to rethink this
        {
            Debug.Log("Player normalised value between 0.0 and 1.0 is :" + normalisedValue);
        }

        perecentageChanceToWin = (int)(normalisedValue * r); // multiply the normalised value by 100 to give us a percent chance to win
        {
            string dMessage = ("Max Level: " + maxLevel + "Player is currently at: " + playerLevel + ". Their percent chance to win is:  " + " % " + perecentageChanceToWin);
            Debug.Log(dMessage);
            
            
        }

        Debug.LogWarning("SetPercentageValue has been called normalised value has been converted to a percentage");
    }

    /// <summary>
    /// We probably want to use this to remove some hp (mojo) from our character.....
    /// Then we probably want to check to see if they are dead or not from that damage and return true or false.
    /// </summary>
    public void DealDamage(float amount)
    {
        
        
        
        /*
        else if (danceTeam.activeDancers == mojoRemaining <= 0)
        {
            RemoveDancerFromActive();

        }
        */
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

        DealDamage(0.1f);

        LevelUp();
        Debug.LogWarning("This character needs some xp to be given, the xpGained from the fight was: " + xpGained);
        // we probably want to do something with the xpGained.

        //We probably want to display the xp we just gained, by default it is 0

        // We probably also want to check to see if the player can level up and if so do something....what should we be checking?
    }

    /// <summary>
    /// A function used to handle actions associated with levelling up.
    /// </summary>

    /// <summary>
    /// Shows the level up effects whenever the character has levelled up
    /// </summary>
 


    private void LevelUp()
    {
        float ThresholdIncrement = 1.6f; // amount the Threshold increases after each levelling up

        if (currentXp < xpThreshold) // if Current Xp is less then Threshold do nothing and check the next if statement
        {
            Debug.Log("Current Xp is not enough to level up, current XP is : " + currentXp + " , Xp increases at the next threshold: " + xpThreshold);
        }
        else if (currentXp >= xpThreshold && currentXp <= (xpThreshold) * ThresholdIncrement) // if current Xp is greater then Threshold and less then Threshold plus Increment then increase level by 1
        {
            level = (level + 1);
            Debug.Log("Current Xp is :" + currentXp + " You have Leveled up !, your current Level is : " + level + " , Congratulations!");
            xpThreshold = (int)Mathf.Round((float)xpThreshold * ThresholdIncrement);
            ShowLevelUpEffects(); // displays some fancy particle effects.
        }
        else if (currentXp > ((xpThreshold) + ThresholdIncrement) && currentXp <= ((xpThreshold + ThresholdIncrement) + ThresholdIncrement)) // if current xp is greater then xp threshold + 1 increment and less or then threshold * 2 increments then level up by 2
        {
            level = (level + 2); // level up 2 times
            Debug.Log("Current Xp is :" + currentXp + " You have Leveled up !, your current Level is : " + level + " , Congratulations!");
            xpThreshold = (int)(Mathf.Round((float)xpThreshold * ThresholdIncrement) * ThresholdIncrement);
            ShowLevelUpEffects(); // displays some fancy particle effects.
        }
        else if (currentXp > ((xpThreshold * ThresholdIncrement) * ThresholdIncrement) && currentXp <= (((xpThreshold * ThresholdIncrement) * ThresholdIncrement) * ThresholdIncrement)) // if current xp is more then threshold * 2 increments and less then threshold * 3 increment then level up by 3
        {
            level = (level + 3); // level up 3 times
            Debug.Log("Current Xp is :" + currentXp + " You have Leveled up !, your current Level is : " + level + " , Congratulations!");
            xpThreshold = (int)Mathf.Round((float)xpThreshold * ThresholdIncrement * ThresholdIncrement * ThresholdIncrement);
            ShowLevelUpEffects(); // displays some fancy particle effects.
        }
        else if (currentXp >= xpThreshold * (ThresholdIncrement * 20)) // if player has leveled up 20 times then  ???
        {
            level = (9000); // set beyond reasonable doubt
            Debug.Log("Current Xp is :" + currentXp + " You have Leveled up !, your at Max Level, : " + level + " , Congratulations! Go find another hobby");
            xpThreshold *= 9000;
        }
        Debug.LogWarning("Level up has been called");
        // we probs want to increase our level....
        // As well as probably want to increase our threshold for when we should level up...based on our current new level
        // Last thing we probably want to do is increase our physical stats...if only we had a function to do that for us.       
    }

    /// <summary>
    /// Get's all the script references required for this charactert
    /// </summary>
    private void SetUpReferences()
    {
        animController = GetComponent<AnimationController>(); // just getting a reference to our animation component on our dancer...this is behind the scenes for the dancing to occur.
        sfxHandler = FindObjectOfType<SFXHandler>(); // Finds a reference to our sfxHandler script that is in our scene.
        particleHandler = GetComponentInChildren<ParticleHandler>(); // searching through the child objects of this object to find the particle system.
    }

    /// <summary>
    /// If our statsUI field is not null, then we pass in a reference to ourself and update the stats.
    /// </summary>
    public void UpdateStatsUI()
    {
        // this just updates our UI for our character to show new stats.
        if (statsUI != null)
        {
            statsUI.UpdateStatsUI(this); // pass in a reference to our own stat script.
        }
    }

  
    /// <summary>
    /// A function used to assign a random amount of points ot each of our skills.
    /// </summary>
    public void DistributePhysicalStatsOnLevelUp(int PointsPool)
    {
        Debug.LogWarning("DistributePhysicalStatsOnLevelUp has been called " + PointsPool);
        // let's share these points somewhat evenly or based on some forumal to increase our current physical stats
        // then let's recalculate our dancing stats again to process and update the new values.
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
