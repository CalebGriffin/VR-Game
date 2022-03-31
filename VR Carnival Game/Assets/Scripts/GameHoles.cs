using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHoles : MonoBehaviour
{
    void OnEnable()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
