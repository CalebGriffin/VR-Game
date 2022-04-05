using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReset : MonoBehaviour
{
    [SerializeField] private GameObject gameManager; // Used to disable the Timer and HoleManager scripts
    [SerializeField] private GameObject menuMusicSource; // Used to stop and start the menu music
    [SerializeField] private GameObject gameMusicSource; // Used to stop and start the game music

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log for testing
        //Debug.Log("Start Game Reset");
    }

    // When the object is enabled, call the method to disable the game scripts and start the menu music
    void OnEnable()
    {
        Reset();
    }

    // Using ContextMenu to be able to call the method from the editor
    [ContextMenu("Reset")]
    // Method to disable the game scripts and music and start the menu music
    void Reset()
    {
        // Debug.Log for testing
        //Debug.Log("GameReset");
        gameManager.GetComponent<Timer>().enabled = false;
        gameManager.GetComponent<HoleManager>().enabled = false;
        menuMusicSource.GetComponent<AudioSource>().Stop();
        gameMusicSource.GetComponent<AudioSource>().Stop();
        menuMusicSource.SetActive(true);
        gameMusicSource.SetActive(false);
    }
}
