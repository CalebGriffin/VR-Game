using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager; // The MenuManager script

    // All of the UI elements that are part of the GameOver screen
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI rightMolesHitText;
    [SerializeField] private TextMeshProUGUI wrongMolesHitText;
    [SerializeField] private TextMeshProUGUI molesMissedText;
    [SerializeField] private TextMeshProUGUI rankText;

    // The Image that is behind the star images to show how many stars the player has achieved
    [SerializeField] private Image starImage;

    private float starValue = 0f; // The value of the starImage
    private int animationID = 1; // UNUSED

    // Sets up all of the GameOver UI and then calls the MenuManager to show the GameOver screen
    public void LevelEnded()
    {
        GameOverUI();

        menuManager.TransitionScene("GameOver");
    }

    // Sets up all of the GameOver UI
    private void GameOverUI()
    {
        // Update all of the UI on the GameOver screen
        finalScoreText.text = gVar.score.ToString();

        // Set the text based on the gVar values
        rightMolesHitText.text = "No. of Moles hit right: " + gVar.molesHitCorrectly.ToString();
        wrongMolesHitText.text = "No. of Moles hit wrong: " + gVar.molesHitIncorrectly.ToString();
        molesMissedText.text = "No. of Moles missed: " + gVar.molesMissed.ToString();

        // Calls the function to calculate the number of stars the player has achieved
        starValue = CalculateStarValue();

        // Calls the function to set the rank that the player has achieved
        rankText.text = CalculateRank();

        // Starts the coroutine to animate the starImage
        StartCoroutine(StarAnimation());
    }

    // Returns the number of stars that the player has achieved
    private float CalculateStarValue()
    {
        float temp = gVar.score / 30000f;
        float returnValue = Mathf.Round(temp * 10f) / 10f;
        // Debug.Log for testing
        //Debug.Log("Star Value is: " + returnValue.ToString());
        return returnValue;
    }

    // Returns the rank that the player has achieved as a string
    private string CalculateRank()
    {
        string returnValue = null;

        switch (starValue)
        {
            case float x when (x <= 0.2f):
                returnValue = "beginner";
                break;

            case float x when (x <= 0.4f):
                returnValue = "amateur";
                break;

            case float x when (x <= 0.6f):
                returnValue = "intermidiate";
                break;

            case float x when (x <= 0.8f):
                returnValue = "professional";
                break;

            default:
                returnValue = "expert";
                break;
        }

        return returnValue;
    }

    // Uses LeanTween to animate the starImage to show how many stars the player has achieved
    private IEnumerator StarAnimation()
    {
        starImage.fillAmount = 0f;
        yield return new WaitForSeconds(3f);
        LeanTween.value(gameObject, 0, starValue, 5 * starValue)
        .setOnUpdate( (float value) => { starImage.fillAmount = value; });
    }
}
