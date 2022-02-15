using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR.InteractionSystem.Sample;

public class Boomerang : MonoBehaviour
{
    private VelocityEstimator velocityEstimator;
    private LockToPoint lockToPoint;

    private float startSnapTime;

    // Start is called before the first frame update
    void Start()
    {
        velocityEstimator = GetComponent<VelocityEstimator>();
        lockToPoint = GetComponent<LockToPoint>();
        startSnapTime = lockToPoint.snapTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoomerangThrown()
    {
        Vector3 currentVelocity = velocityEstimator.GetVelocityEstimate();
        lockToPoint.snapTime = (startSnapTime * currentVelocity.magnitude) / 7f;

    }
}
