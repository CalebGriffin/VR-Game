using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject gameManager; // Used to enable the Timer and HoleManager scripts
    [SerializeField] private GameObject menuMusicSource; // Used to stop and start the menu music
    [SerializeField] private GameObject gameMusicSource; // Used to stop and start the game music

    // When the object is enabled, call the method to enable the game scripts and start the game music
    void OnEnable()
    {
        Start();
    }

    // Using ContextMenu to be able to call the method from the editor
    [ContextMenu("Start")]
    // Method to enable the game scripts and music and stop the menu music
    void Start()
    {
        // Debug.Log for testing
        //Debug.Log("Start");
        gameManager.GetComponent<Timer>().enabled = true;
        gameManager.GetComponent<HoleManager>().enabled = true;
        menuMusicSource.GetComponent<AudioSource>().Stop();
        gameMusicSource.GetComponent<AudioSource>().Stop();
        menuMusicSource.SetActive(false);
        gameMusicSource.SetActive(true);
    }
}
