using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameOver gameOver;

    private float timeRemaining;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider timerSlider;

    private bool calledLevelEnd = false;

    void OnEnable()
    {
        timeRemaining = gVar.timePerLevel;
        calledLevelEnd = false;
    }

    void OnDisable()
    {
        timeRemaining = gVar.timePerLevel;
        calledLevelEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        UIUpdate();

        if (timeRemaining <= 0f && !calledLevelEnd)
        {
            // Call the GameOver method on the GameOver script
            gameOver.LevelEnded();

            calledLevelEnd = true;
        }
    }

    private void UIUpdate()
    {
        int timeRemainingInt = Mathf.CeilToInt(timeRemaining);
        timerText.text = timeRemainingInt.ToString();
        timerSlider.value = timeRemaining;
        scoreText.text = gVar.score.ToString();
    }
}
