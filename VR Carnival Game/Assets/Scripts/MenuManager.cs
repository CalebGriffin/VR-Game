using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject optionsCanvas;
    [SerializeField] private GameObject helpCanvas;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject gameOverCanvas;

    [SerializeField] private GameObject mainMenuHoles;
    [SerializeField] private GameObject optionsHoles;
    [SerializeField] private GameObject helpHoles;
    [SerializeField] private GameObject gameHoles;
    [SerializeField] private GameObject gameOverHoles;

    [SerializeField] private Image transitionImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionScene(string name)
    {
        Debug.Log("Transitioning to Scene: " + name);
        StartCoroutine("TransitionSceneDelay", name);
    }

    public IEnumerator TransitionSceneDelay(string name)
    {
        GameObject nextCanvas = null;
        GameObject nextHoles = null;

        switch (name)
        {
            case "MainMenu":
                nextCanvas = mainMenuCanvas;
                nextHoles = mainMenuHoles;
                break;

            case "Options":
                nextCanvas = optionsCanvas;
                nextHoles = optionsHoles;
                break;
                
            case "Help":
                nextCanvas = helpCanvas;
                nextHoles = helpHoles;
                break;

            case "GameOver":
                nextCanvas = gameOverCanvas;
                nextHoles = gameOverHoles;
                break;

            case "Game":
                nextCanvas = gameCanvas;
                nextHoles = gameHoles;
                break;

            default:
                break;
        }
        
        HideAllHoles();
        TransitionAnimationRight();
        yield return new WaitForSeconds(1f);
        HideAllCanvases();
        ShowNext(nextCanvas, nextHoles);
        TransitionAnimationLeft();
    }

    private void TransitionAnimationRight()
    {
        LeanTween.value(gameObject, 0, 1, 1)
            .setOnUpdate( (value) => { transitionImage.fillAmount = value; });
    }

    private void TransitionAnimationLeft()
    {
        LeanTween.value(gameObject, 1, 0, 1).setOnUpdate( (value) => { transitionImage.fillAmount = value; });
    }


    private void HideAllCanvases()
    {
        mainMenuCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        helpCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    private void HideAllHoles()
    {
        mainMenuHoles.BroadcastMessage("AnimateOut");
        optionsHoles.BroadcastMessage("AnimateOut");
        helpHoles.BroadcastMessage("AnimateOut");
        gameHoles.BroadcastMessage("AnimateOut");
        gameOverHoles.BroadcastMessage("AnimateOut");
    }

    private void ShowNext(GameObject nextCanvas, GameObject nextHoles)
    {
        nextCanvas.SetActive(true);
        nextHoles.SetActive(true);
    }
}
