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

    public string randomDescriptor;
    public string randomFirstName;
    public string randomNickName;
    public string randomLastName;

    /// <summary>
    /// Creates a list of names for all our characters to potentiall use.
    /// This get's called in the battle stater, before both teams call initTeams().
    /// </summary>
    public void CreateNames()
    {
        if (descriptors != null)
        {
            descriptors.Add("Stealthy");
            descriptors.Add("Stylin");
            descriptors.Add("Mr Wiggles");
            descriptors.Add("Crazy Legs");
            descriptors.Add("Wild Style");
            descriptors.Add("Fearless");
            randomDescriptor = descriptors[Random.Range(0, descriptors.Count)];

            Debug.Log("Added some descriptors to the list, here is a random Descriptor: " + randomDescriptor);
        }
        if (firstNames != null)
        {
            firstNames.Add("Norris");
            firstNames.Add("Kenny");
            firstNames.Add("Toni");
            firstNames.Add("Ash");
            firstNames.Add("Marlon");
            firstNames.Add("Chucky");

            randomFirstName = firstNames[Random.Range(0, firstNames.Count)];

            Debug.Log("Added some First Names to the list, here is a random First Name: " + randomFirstName);
        }
        if (nicknames != null)
        {
            nicknames.Add("Swoosh");
            nicknames.Add("Footwork");
            nicknames.Add("Banjo");
            nicknames.Add("One Up");
            nicknames.Add("Number 11");
            nicknames.Add("Budda Stretch");

            randomNickName = nicknames[Random.Range(0, nicknames.Count)];

            Debug.Log("Added some Nick Names to the list, here is a random Nick Name: " + randomNickName);

        }
        if (lastNames != null)
        {
            lastNames.Add("Jackson");
            lastNames.Add("Campbell");
            lastNames.Add("Hoffman");
            lastNames.Add("Robson");
            lastNames.Add("Klapow");
            lastNames.Add("Ortega");

            randomLastName = lastNames[Random.Range(0, lastNames.Count)];
            Debug.Log("Added some Last Names to the list, here is a random Last Name: " + randomLastName);
        }


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

            emptyName.descriptor = randomDescriptor;
            emptyName.firstName = randomFirstName;
            emptyName.nickname = randomNickName;
            emptyName.lastName = randomLastName;
            names[i] = emptyName;
        }

        //Returns an array of names that we just created.
        return names;
    }
}