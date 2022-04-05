using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to adjust the scale of the HoleHolder object so that the moles can be placed in the correct positions
public class HoleHolder : MonoBehaviour
{
    [SerializeField] private GameObject table; // The table object

    // When the Gizmos are drawn, set the scale of this object to the inverse of the table's scale
    void OnDrawGizmos()
    {
        float newX = 1f / table.transform.localScale.x;
        float newY = 1f / table.transform.localScale.y;
        float newZ = 1f / table.transform.localScale.z;

        transform.localScale = new Vector3(newX, newY, newZ);
    }
}
