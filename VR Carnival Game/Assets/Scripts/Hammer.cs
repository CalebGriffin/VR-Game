using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    // When the Hammer collides with a Mole, call the Hit method on the Mole object and pass in this object's name
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Mole"))
        {
            collider.gameObject.SendMessage("Hit", this.gameObject.name);
        }
    }
}
