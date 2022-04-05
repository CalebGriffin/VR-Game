using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gVarReset : MonoBehaviour
{
    // When this object is enabled, call the method to reset the global variables
    void OnEnable()
    {
        GVarReset();
    }

    // Using ContextMenu to be able to call the method from the editor
    [ContextMenu("GVarReset")]
    // Method to reset the global variables
    void GVarReset()
    {
        // Debug.Log for testing
        //Debug.Log("GVarReset");
        gVar.score = 0;
        gVar.currentCombo = 0;
        gVar.holes.Clear();
        gVar.molesHitCorrectly = 0;
        gVar.molesHitIncorrectly = 0;
        gVar.molesMissed = 0;
    }
}
