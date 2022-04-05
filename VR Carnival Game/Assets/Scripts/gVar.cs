using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to store global variables
public class gVar
{
    public static List<GameObject> holes = new List<GameObject>(); // List of hole objects
    public static int currentCombo; // The current value of the combo bar (1-5)
    public static float timePerLevel = 60f; // The amount of time per level
    public static int score; // The player's current score
    public static int molesHitCorrectly; // The number of moles hit correctly
    public static int molesHitIncorrectly; // The number of moles hit incorrectly
    public static int molesMissed; // The number of moles missed
}
