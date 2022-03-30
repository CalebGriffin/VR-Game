using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : MonoBehaviour
{
    [SerializeField] private Material blankMat;

    private void ColourPicker(Material colouredMat)
    {
        //Debug.Log("Colour Picker Being Called");

        if (ColourGetter(this.gameObject) == false)
        {
            ColourSetter(this.gameObject, colouredMat);
        }

        foreach (Transform child in transform)
        {
            if (ColourGetter(child.gameObject) == false)
            {
                ColourSetter(child.gameObject, colouredMat);
            }
        }
    }

    private bool ColourGetter(GameObject go)
    {
        //Debug.Log("Colour Getter Being Called");

        return go.CompareTag("FixedMat");
    }

    private void ColourSetter(GameObject go, Material colouredMat)
    {
        //Debug.Log("Colour Setter Being Called");

        try
        {
            go.GetComponent<Renderer>().material = colouredMat;
        }
        catch (MissingComponentException)
        {
        }
    }
}
