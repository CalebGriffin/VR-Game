using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameOver gameOver; // Used to access the GameOver script when the timer runs out

    private float timeRemaining; // Tracks the amount of time remaining in the level

    // Text and Slider UI elements that can be dynamically changed
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider timerSlider;

    private bool calledLevelEnd = false; // Boolean to check if the level ended method has already been called

    // When the script is enabled, set the time remaining and set the bool to false
    void OnEnable()
    {
        timeRemaining = gVar.timePerLevel;
        calledLevelEnd = false;
    }

    // When the script is disabled, set the time remaining and set the bool to false
    void OnDisable()
    {
        timeRemaining = gVar.timePerLevel;
        calledLevelEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Decrement the time remaining by the amount of time that has passed since the previous frame
        timeRemaining -= Time.deltaTime;

        // Call the method to update the UI elements
        UIUpdate();

        // If the timer has run out and the method hasn't been called, call the method and set the bool to true
        if (timeRemaining <= 0f && !calledLevelEnd)
        {
            // Call the LevelEnded method on the GameOver script
            gameOver.LevelEnded();

            calledLevelEnd = true;
        }
    }

    private void UIUpdate()
    {
        // Round the time remaining to an integer and change the UI text value to the time remaining
        int timeRemainingInt = Mathf.CeilToInt(timeRemaining);
        timerText.text = timeRemainingInt.ToString();

        // Set the value of the timer slider to the amount of time remaining
        timerSlider.value = timeRemaining;

        // Update the text that displays the current score
        scoreText.text = gVar.score.ToString();
    }
}
