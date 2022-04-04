using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Get references to all of the Canvas objects
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject optionsCanvas;
    [SerializeField] private GameObject helpCanvas;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject gameOverCanvas;

    // Get references to all of the parent objects for each set of holes
    [SerializeField] private GameObject mainMenuHoles;
    [SerializeField] private GameObject optionsHoles;
    [SerializeField] private GameObject helpHoles;
    [SerializeField] private GameObject gameHoles;
    [SerializeField] private GameObject gameOverHoles;

    // Image that is used to create the transition between menus
    [SerializeField] private Image transitionImage;

    // Function that will be called by other objects in the scene, calls the coroutine to transition to the menu provided
    public void TransitionScene(string name)
    {
        // Debug.Log for testing
        //Debug.Log("Transitioning to Scene: " + name);

        StartCoroutine("TransitionSceneDelay", name);
    }

    // Coroutine which changes the menu and holes based on the parameters that are passed
    public IEnumerator TransitionSceneDelay(string name)
    {
        GameObject nextCanvas = null;
        GameObject nextHoles = null;

        // Set the nextCanvas and nextHoles variables based on the passed parameter
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
        
        // Transition to the next scene by calling a number of functions and waiting for the transition to carry out
        HideAllHoles();
        TransitionAnimationRight();
        yield return new WaitForSeconds(1f);
        HideAllCanvases();
        ShowNext(nextCanvas, nextHoles);
        TransitionAnimationLeft();
    }

    // Use LeanTween to animate the image wiping to the right
    private void TransitionAnimationRight()
    {
        LeanTween.value(gameObject, 0, 1, 1)
            .setOnUpdate( (value) => { transitionImage.fillAmount = value; });
    }

    // Use LeanTween to animate the image wiping to the left
    private void TransitionAnimationLeft()
    {
        LeanTween.value(gameObject, 1, 0, 1).setOnUpdate( (value) => { transitionImage.fillAmount = value; });
    }

    // Hides all of the canvas objects

    private void HideAllCanvases()
    {
        mainMenuCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        helpCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    // Tells all of the hole objects to animate out
    private void HideAllHoles()
    {
        mainMenuHoles.BroadcastMessage("AnimateOut");
        optionsHoles.BroadcastMessage("AnimateOut");
        helpHoles.BroadcastMessage("AnimateOut");
        gameHoles.BroadcastMessage("AnimateOut");
        gameOverHoles.BroadcastMessage("AnimateOut");
    }

    // Activates the relevant Canvas and holes for the next menu
    private void ShowNext(GameObject nextCanvas, GameObject nextHoles)
    {
        nextCanvas.SetActive(true);
        nextHoles.SetActive(true);
    }
}
