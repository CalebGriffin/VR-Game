using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHoles : MonoBehaviour
{
    // When the GameObject is enabled, set all of the children GameObjects to be active
    void OnEnable()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
