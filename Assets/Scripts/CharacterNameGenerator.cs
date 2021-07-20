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
    private List<string> firstNames; // These appear in the inspector, you should be assigning names to these in the inspector.

    [Header("Possible last names")]
    private List<string> lastNames;

    [Header("Possible nicknames")]
    private List<string> nicknames;

    [Header("Possible adjectives to describe the character")]
    private List<string> descriptors;


    /// <summary>
    /// Creates a list of names for all our characters to potentiall use.
    /// This get's called in the battle starter, before both teams call initTeams().
    /// </summary>
    public void CreateNames()
    {
        firstNames.Add("Thomas");
        firstNames.Add("Billy");
        firstNames.Add("Dick");
        firstNames.Add("Charlie");
        firstNames.Add("Frankie");
        firstNames.Add("Milson");

        lastNames.Add("Williamson");
        lastNames.Add("Davidson");
        lastNames.Add("Frankston");
        lastNames.Add("McGregor");
        lastNames.Add("Davis");
        lastNames.Add("McKraken");

        nicknames.Add("The Tank");
        nicknames.Add("The Fixer");
        nicknames.Add("The Kid");
        nicknames.Add("Rough & Tumble");
        nicknames.Add("Rogue Mania");
        nicknames.Add("The Dominator");

        descriptors.Add("Loose");
        descriptors.Add("Running Man");
        descriptors.Add("Flippin");
        descriptors.Add("Lucky");
        descriptors.Add("Stampin");
        descriptors.Add("Freestylin");


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
            emptyName.firstName = 
            names[i] = emptyName;

            [Random.Range(0, myFirstIntList.Count)]


        }

        //Returns an array of names that we just created.
        return names;
    }
}