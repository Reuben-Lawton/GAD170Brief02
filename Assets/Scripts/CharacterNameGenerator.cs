using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions to complete:
/// Create Names
/// - Generate Names
/// </summary>
public class CharacterNameGenerator : MonoBehaviour
{
     [Header("Possible first names")]
    private List<string> firstNames = new List<string>(){"Thomas","Billy","Dick","Charlie","Frankie","Milson"}; 
    // These appear in the inspector, you should be assigning names to these in the inspector.

    [Header("Possible last names")]
    private List<string> lastNames = new List<string>() { "Williamson", "Davidson", "Frankston", "McGregor", "Davis", "McKraken"};

    [Header("Possible nicknames")]
    private List<string> nicknames = new List<string>() { "The Tank", "The Fixer", "The Kid", "Rough & Tumble", "Rogue Mania", "The Dominator" };

    [Header("Possible adjectives to describe the character")]
    private List<string> descriptors = new List<string>() { "Loose", "Running Man", "Flippin", "Lucky", "Stampin", "Freestylin"};


    /// <summary>
    /// Creates a list of names for all our characters to potentiall use.
    /// This get's called in the battle starter, before both teams call initTeams().
    /// </summary>
    public void CreateNames()
    {
        string characterFullNameTest;

        characterFullNameTest = ("The player is " + descriptors[Random.Range(0, descriptors.Count)] + firstNames[Random.Range(0, firstNames.Count)] + nicknames[Random.Range(0, nicknames.Count)] + lastNames[Random.Range(0, lastNames.Count)]);
                Debug.Log("test to see if names work " + nicknames[Random.Range(0, nicknames.Count)]);

        Debug.Log("test to see if names work " + characterFullNameTest);


        Debug.Log("test to see if names work " + nicknames[Random.Range(0, nicknames.Count)]);  

        Debug.LogWarning("Create Names Called");
        // we probably want to set our 4 lists to some default values
    }

    /// <summary>
    /// Returns an Array of Character Names based on the number of namesNeeded.
    /// </summary>
    /// <param name="namesNeeded"></param>
    /// <returns></returns>
    public CharacterName[] ReturnTeamCharacterNames(int namesNeeded)
    {
        Debug.LogWarning("CharacterNameGenerator called, it needs to fill out the names array with unique randomly constructed character names");
        CharacterName[] names = new CharacterName[namesNeeded]; 
        CharacterName emptyName = new CharacterName(string.Empty, string.Empty, string.Empty, string.Empty);

        for (int i = 0; i < names.Length; i++)
        {
            //For every name we need to generate, we need to assign a random first name, last name, nickname and descriptor to each.
            //Below is an example of setting the first name of the emptyName variable to the string "Blank".
            emptyName.firstName = firstNames[Random.Range(0, firstNames.Count)];
            emptyName.lastName = lastNames[Random.Range(0, lastNames.Count)];
            emptyName.nickname = nicknames[Random.Range(0, nicknames.Count)];
            emptyName.descriptor = descriptors[Random.Range(0, descriptors.Count)];
            names[i] = emptyName;
                        

        }

        //Returns an array of names that we just created.
        return names;
    }
}