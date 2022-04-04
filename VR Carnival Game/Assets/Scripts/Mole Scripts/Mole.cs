using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Mole : MonoBehaviour
{
    // GameObject arrays to store all of the items of clothing
    [SerializeField] protected GameObject[] hats;
    [SerializeField] protected GameObject[] glasses;
    [SerializeField] protected GameObject[] neckAccessories;
    [SerializeField] protected GameObject[] moustaches;

    // GameObject so that the moles can face towards the player when they spawn
    [SerializeField] private GameObject playerHead;

    // When this script is enabled, get a reference to the players head and call the method to look towards the player
    virtual public void OnEnable()
    {
        playerHead = GameObject.FindGameObjectWithTag("PlayerHead");
        FaceThePlayer();
    }

    // When this script is disabled, call the method to disable all of the items of clothing
    virtual public void OnDisable()
    {
        GetUndressed();
    }

    virtual public void Hit(string hammerName)
    {
        // This will be overridden by the inherited classes
    }

    // This method will be called when the correct hammer hits this mole
    protected void CorrectHit()
    {
        // Send a message to the hole object to say that the mole has been hit
        transform.parent.gameObject.SendMessage("MoleKilled");

        // Update the global score variable
        gVar.score = (int)Mathf.Clamp(gVar.score + (100 * gVar.currentCombo), 0, Mathf.Infinity);
        
        // Increase the global variable that tracks how many moles have been hit correctly
        gVar.molesHitCorrectly++;

        // Call the method to increase the Combo bar
        ComboBar.Instance.IncreaseCombo();

        // Set this GameObject to inactive to hide the mole
        this.gameObject.SetActive(false);
    }

    // This method will be called when the incorrect hammer hits this mole
    protected void IncorrectHit()
    {
        // Update the global score variable
        gVar.score = (int)Mathf.Clamp(gVar.score - 100, 0, Mathf.Infinity);

        // Increase the global variable that tracks how many moles have been hit incorrectly
        gVar.molesHitIncorrectly++;

        // Call the method to increase the Combo bar
        ComboBar.Instance.ResetCombo();

        // Call the despawn method to disable the mole
        Despawn();
    }

    // Send a message to the hole object to say that the mole has been hit and then disable this mole
    virtual public void Despawn()
    {
        transform.parent.gameObject.SendMessage("MoleKilled");
        this.gameObject.SetActive(false);
    }

    // Randomly choose from all the items of clothing and enable them
    virtual public void GetDressed(Material colouredMat)
    {
        ItemPicker(hats, true, colouredMat);
        ItemPicker(glasses, false, colouredMat);
        ItemPicker(neckAccessories, false, colouredMat);
        ItemPicker(moustaches, false, colouredMat);
    }

    // Disable all of the items of clothing
    virtual public void GetUndressed()
    {
        ItemHider(hats);
        ItemHider(glasses);
        ItemHider(neckAccessories);
        ItemHider(moustaches);
    }

    // Takes a parameter of a GameObject array and disables all of the objects in that array
    virtual protected void ItemHider(GameObject[] accessoryArray)
    {
        foreach (GameObject go in accessoryArray)
        {
            go.SetActive(false);
        }
    }

    // Randomly picks from the GameObject array parameter and enables one of the items of clothing and sets it to the correct colour
    // If the GameObject array is hats then one of the objects must be chosen otherwise, there is a possibility that none of the items will be chosen
    virtual protected void ItemPicker(GameObject[] accessoryArray, bool isHats, Material colouredMat)
    {
        int randomIndex = -1;

        if (isHats)
        {
            randomIndex = Random.Range(0, accessoryArray.Length);
        }
        else
        {
            randomIndex = Random.Range(-1, accessoryArray.Length);
        }

        if (randomIndex != -1)
        {
            accessoryArray[randomIndex].SetActive(true);
            accessoryArray[randomIndex].SendMessage("ColourPicker", colouredMat);
        }
    }

    // Gets the position of the player's head and then rotates to face them only on the y-axis
    private void FaceThePlayer()
    {
        Vector3 lookPos = playerHead.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
    }
}
