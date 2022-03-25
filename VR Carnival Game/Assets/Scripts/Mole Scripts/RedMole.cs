using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RedMole : Mole
{
    [SerializeField] private Material redMat;

    public override void OnEnable()
    {
        base.GetDressed(redMat);
        base.OnEnable();
    }

    public override void Hit(string hammerName)
    {
        if (hammerName == "Red Hammer")
        {
            // Vibrate the Controller
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 0.15f, 300, 1);

            base.CorrectHit();
        }
        else if (hammerName == "Blue Hammer")
        {
            // Vibrate the Controller
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.RightHand].Execute(0, 0.5f, 100, 1);

            base.IncorrectHit();
        }
    }

    public override void Despawn()
    {
        base.Despawn();
    }
}