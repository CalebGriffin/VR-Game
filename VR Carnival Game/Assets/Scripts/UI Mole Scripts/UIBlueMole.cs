using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UIBlueMole : UIMole
{
    [SerializeField] private Material blueMat;

    public override void OnEnable()
    {
        base.GetDressed(blueMat);
        base.OnEnable();
    }

    public override void Hit(string hammerName)
    {
        if (hammerName == "Blue Hammer")
        {
            // Vibrate the Controller
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.RightHand].Execute(0, 0.15f, 300, 1);

            Debug.Log("Correct Hit called by: " + this.gameObject.name);
            base.CorrectHit();
        }
        else if (hammerName == "Red Hammer")
        {
            // Vibrate the Controller
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 0.5f, 100, 1);

            base.IncorrectHit();
        }
    }
}
