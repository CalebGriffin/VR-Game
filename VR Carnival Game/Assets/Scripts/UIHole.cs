using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// This class is attached to the holes that aren't part of the main game
public class UIHole : MonoBehaviour
{
    [SerializeField] private UnityEvent action; // The action that will be triggered when the mole in this hole is hit
    [SerializeField] private GameObject[] moles; // Moles that are in this hole

    // When this script is enabled, call the method to animate the holes in
    void OnEnable()
    {
        AnimateIn();
    }

    // When this script is disabled, call the method to animate the holes out
    void OnDisable()
    {
        AnimateOut();
    }

    // Use LeanTween to animate the hole scaling in and then spawn a mole in this hole
    private void AnimateIn()
    {
        transform.localScale = Vector3.zero;
        LeanTween.cancel(this.gameObject);
        LeanTween.scale(this.gameObject, new Vector3(0.8f, 0.8f, 0.8f), 1f);
        SpawnMole();
    }

    // Use LeanTween to animate the hole scaling out and then destroy all of the moles in this hole
    private void AnimateOut()
    {
        LeanTween.cancel(this.gameObject);
        LeanTween.scale(this.gameObject, Vector3.zero, 1f).setOnComplete(HideParent);
        DestroyMoles();
    }

    // Hides the parent object of the GameObject that this script is attached to
    private void HideParent()
    {
        transform.parent.gameObject.SetActive(false);
    }

    // Picks a random mole from the array and spawns it into the hole
    public void SpawnMole()
    {
        int moleIndex = Random.Range(0,2);
        moles[moleIndex].SetActive(true);
    }

    // Disables all of the moles in the array
    public void DestroyMoles()
    {
        foreach (GameObject mole in moles)
        {
            mole.SetActive(false);
        }
    }

    // When the mole that is in this hole is hit then trigger the Unity Event that is connected to this hole
    public void MoleKilled()
    {
        // Debug.Log for testing
        //Debug.Log(this.gameObject.name + "'s action is being invoked");

        action.Invoke();
    }
}
