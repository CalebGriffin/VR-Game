using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RedMole : Mole
{
    public override void Hit(string hammerName)
    {
        if (hammerName == "Red Hammer")
        {
            //transform.parent.gameObject.SendMessage("MoleKilled");
            transform.parent.gameObject.GetComponent<Hole>().MoleKilled();
            // Vibrate the Controller
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 0.5f, 100, 1);
            ComboBar.Instance.IncreaseCombo();
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