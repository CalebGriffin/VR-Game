using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RedMole : Mole
{
    public override void Hit(string hammerName)
    {
        if (hammerName == "Red Hammer")
        {
            transform.parent.gameObject.SendMessage("MoleKilled");
            // Vibrate the Controller
            //SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 1, 10, 1);
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