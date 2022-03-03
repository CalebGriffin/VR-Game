using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMole : Mole
{
    public override void Hit(string hammerName)
    {
        if (hammerName == "Blue Hammer")
        {
            transform.parent.gameObject.SendMessage("MoleKilled");
            Destroy(this.gameObject);
        }
        else
        {
            // Take points from the player
        }
    }

    public override void Despawn()
    {
        base.Despawn();
    }
}
