using System;
using System.Collections.Generic;

// Mark this class as serialisable so Unity can turn it into JSON
[Serializable]
public class DataObject
{
    public string playerName = "Player One";
    public int level = 1;
    public float health = 100f;

    // Example array – e.g. IDs of collected items
    public int[] collectedItemIDs = new int[] { 1, 5, 9 };

    // Example list – e.g. unlocked abilities or skills
    public List<string> unlockedAbilities = new List<string>()
    {
        "Double Jump",
        "Dash",
        "Fireball"
    };
}