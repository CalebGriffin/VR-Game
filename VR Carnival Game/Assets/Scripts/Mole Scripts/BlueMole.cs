using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMole : Mole
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Hit(string hammerName)
    {
        if (hammerName == "Blue Hammer")
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Take points from the player
        }
    }
}