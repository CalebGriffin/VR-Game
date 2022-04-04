using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RedMole : Mole
{
    [SerializeField] private Material redMat; // Reference to the red material to change the colour of the items of clothing

    // When the mole is enabled, call the GetDressed method with the red material and call the OnEnable method on the base class
    public override void OnEnable()
    {
        base.GetDressed(redMat);
        base.OnEnable();
    }

    // This method will be called by the hammer when it collides with this mole
    public override void Hit(string hammerName)
    {
        // If the hammer is the red hammer then vibrate the controller and register a correct hit
        if (hammerName == "Red Hammer")
        {
            // Vibrate the Controller
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 0.15f, 300, 1);

            base.CorrectHit();
        }
        // If the hammer is the blue hammer then vibrate the controller and register an incorrect hit
        else if (hammerName == "Blue Hammer")
        {
            // Vibrate the Controller
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.RightHand].Execute(0, 0.5f, 100, 1);

            base.IncorrectHit();
        }
    }
}