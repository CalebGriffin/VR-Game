using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] AudioSource musicSource; // The music source that plays the music while the game is playing
    [SerializeField] private TextMeshProUGUI musicTitleText; // Text object that displays the name of the current soundtrack

    // Update is called once per frame
    void Update()
    {
        // Get the name of the currently playing music clip and set the UI text to its name
        string musicTitle = musicSource.clip.ToString();
        string[] actualMusicTitle = musicTitle.Split(' ');
        musicTitleText.text = "Music Title: " + actualMusicTitle[0];
    }
}
