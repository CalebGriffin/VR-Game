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
    [SerializeField] private Slider timerSlider;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = gVar.timePerLevel;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        UIUpdate();

        if (timeRemaining <= 0f)
        {
            // Call the GameOver method on the GameOver script
            gameOver.LevelEnded();
        }
    }

    private void UIUpdate()
    {
        int timeRemainingInt = Mathf.CeilToInt(timeRemaining);
        timerText.text = timeRemainingInt.ToString();
        timerSlider.value = timeRemaining;
    }
}
