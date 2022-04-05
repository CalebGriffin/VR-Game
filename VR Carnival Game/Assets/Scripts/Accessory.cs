using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : MonoBehaviour
{

    // If this GameObject isn't tagged "FixedMat", set the material to be the passed in material
    private void ColourPicker(Material colouredMat)
    {
        // Debug.Log for testing
        //Debug.Log("Colour Picker Being Called");

        if (ColourGetter(this.gameObject) == false)
        {
            ColourSetter(this.gameObject, colouredMat);
        }

        // Set the material for all of the children GameObjects if they aren't tagged "FixedMat"
        foreach (Transform child in transform)
        {
            if (ColourGetter(child.gameObject) == false)
            {
                ColourSetter(child.gameObject, colouredMat);
            }
        }
    }

    // Returns the boolean value of whether the GameObject is tagged "FixedMat"
    private bool ColourGetter(GameObject go)
    {
        // Debug.Log for testing
        //Debug.Log("Colour Getter Being Called");

        return go.CompareTag("FixedMat");
    }

    // Sets the material of the passed in GameObject to be the passed in material
    private void ColourSetter(GameObject go, Material colouredMat)
    {
        // Debug.Log for testing
        //Debug.Log("Colour Setter Being Called");

        // Using try catch to prevent errors if the GameObject doesn't have a Renderer
        try
        {
            go.GetComponent<Renderer>().material = colouredMat;
        }
        catch (MissingComponentException)
        {
        }
    }
}
