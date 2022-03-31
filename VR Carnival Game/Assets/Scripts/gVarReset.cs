using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gVarReset : MonoBehaviour
{
    void OnEnable()
    {
        GVarStuff();
    }

    [ContextMenu("GVarStuff")]
    void GVarStuff()
    {
        Debug.Log("GVarStuff");
        gVar.score = 0;
        gVar.currentCombo = 0;
        gVar.holes.Clear();
        gVar.molesHitCorrectly = 0;
        gVar.molesHitIncorrectly = 0;
        gVar.molesMissed = 0;

    }
}
