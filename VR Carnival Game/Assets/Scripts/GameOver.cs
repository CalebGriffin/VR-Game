using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;

    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI rightMolesHitText;
    [SerializeField] private TextMeshProUGUI wrongMolesHitText;
    [SerializeField] private TextMeshProUGUI molesMissedText;
    [SerializeField] private TextMeshProUGUI rankText;

    [SerializeField] private Image starImage;

    private float starValue = 0f;
    private int animationID = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelEnded()
    {
        GameOverUI();

        menuManager.TransitionScene("GameOver");
    }

    private void GameOverUI()
    {
        // Update all of the UI on the GameOver screen
        finalScoreText.text = gVar.score.ToString();

        rightMolesHitText.text = "No. of Moles hit right: " + gVar.molesHitCorrectly.ToString();
        wrongMolesHitText.text = "No. of Moles hit wrong: " + gVar.molesHitIncorrectly.ToString();
        molesMissedText.text = "No. of Moles missed: " + gVar.molesMissed.ToString();

        starValue = CalculateStarValue();

        rankText.text = CalculateRank();

        StartCoroutine(StarAnimation());
    }

    private float CalculateStarValue()
    {
        float temp = gVar.score / 20000f;
        return Mathf.Round(temp * 10f) / 0.1f;
    }

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

    private IEnumerator StarAnimation()
    {
        yield return new WaitForSeconds(3f);
        LeanTween.value(gameObject, 0, starValue, 5)
        .setOnUpdate( (value) => { starImage.fillAmount = value; });
    }
}
