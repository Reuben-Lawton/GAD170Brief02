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
    private List<string> firstNames = new List<string> () ; // These appear in the inspector, you should be assigning names to these in the inspector.
    [Header("Possible last names")]
    private List<string> lastNames = new List<string>();
    [Header("Possible nicknames")]
    private List<string> nicknames = new List<string>();
    [Header("Possible adjectives to describe the character")]
    private List<string> descriptors = new List<string>();

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
        if (descriptors.Count <= 0)
        {
            descriptors.Add("Stealthy");
            descriptors.Add("Stylin");
            descriptors.Add("Mr Wiggles");
            descriptors.Add("Crazy Legs");
            descriptors.Add("Wild Style");
            descriptors.Add("Fearless");
            

            Debug.Log("Added some descriptors to the list, here is a random Descriptor: " + randomDescriptor);
        }
        if (firstNames.Count <=0)
        {
            firstNames.Add("Norris");
            firstNames.Add("Kenny");
            firstNames.Add("Toni");
            firstNames.Add("Ash");
            firstNames.Add("Marlon");
            firstNames.Add("Chucky");

                       Debug.Log("Added some First Names to the list, here is a random First Name: " + randomFirstName);
        }
        if (nicknames.Count <= 0)
        {
            nicknames.Add("Swoosh");
            nicknames.Add("Footwork");
            nicknames.Add("Banjo");
            nicknames.Add("One Up");
            nicknames.Add("Number 11");
            nicknames.Add("Budda Stretch");


            Debug.Log("Added some Nick Names to the list, here is a random Nick Name: " + randomNickName);

        }
       if (lastNames.Count <= 0)
        {
            lastNames.Add("Jackson");
            lastNames.Add("Campbell");
            lastNames.Add("Hoffman");
            lastNames.Add("Robson");
            lastNames.Add("Klapow");
            lastNames.Add("Ortega");

            Debug.Log("Added some Last Names to the list, here is a random Last Name: " + randomLastName);
        }


            Debug.LogWarning("Create Names Called");
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

            emptyName.descriptor = descriptors[Random.Range(0, descriptors.Count)]; 
            emptyName.firstName = firstNames[Random.Range(0, firstNames.Count)];
            emptyName.nickname = nicknames[Random.Range(0, nicknames.Count)];
            emptyName.lastName = lastNames[Random.Range(0, lastNames.Count)];
            names[i] = emptyName;
        }

        //Returns an array of names that we just created.
        return names;
    }
}