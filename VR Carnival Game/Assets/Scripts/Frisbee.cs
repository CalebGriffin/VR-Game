using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR.InteractionSystem.Sample;

public class Frisbee : MonoBehaviour
{
    private VelocityEstimator velocityEstimator;
    private LockToPoint lockToPoint;
    private Rigidbody rb;
    [SerializeField] private GameObject trailRenderer;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform rightHandPos;

    private float startSnapTime;

    private bool hasBeenThrown;

    // Start is called before the first frame update
    void Start()
    {
        // Get the references to the components
        velocityEstimator = GetComponent<VelocityEstimator>();
        lockToPoint = GetComponent<LockToPoint>();
        rb = GetComponent<Rigidbody>();

        // Set the start snap time of the object
        startSnapTime = lockToPoint.snapTime;

        // Disable the LockToPoint component
        lockToPoint.enabled = false;

        // Disable the Trail
        DisableTrail();

        // Disable gravity for the frisbee
        //rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude <= 0.1f && hasBeenThrown)
        {
            ReturnToSender();
        }
    }

    public void FrisbeeThrown()
    {
        hasBeenThrown = true;
        rb.useGravity = true;
        EnableTrail();
        //Vector3 currentVelocity = velocityEstimator.GetVelocityEstimate();
        //lockToPoint.snapTime = (startSnapTime * currentVelocity.magnitude) / 7f;
    }

    public void FrisbeeCaught()
    {
        hasBeenThrown = false;
        rb.useGravity = false;
        DisableTrail();
    }

    private void ReturnToSender()
    {
        // Remap distance from player to a number between 0 and 5
        // Set the snap time to that number
        DisableTrail();
        lockToPoint.enabled = true;
    }

    private void EnableTrail()
    {
        trailRenderer.SetActive(true);
    }

    private void DisableTrail()
    {
        trailRenderer.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Frisbee Trigger" && hasBeenThrown)
        {
            //lockToPoint.snapTime = 100f;
            lockToPoint.enabled = false;
            StartCoroutine(DropFrisbee());
        }
    }

    private IEnumerator DropFrisbee()
    {
        yield return new WaitForSeconds(5f);

        lockToPoint.enabled = true;
        lockToPoint.snapTo = startPos;
        lockToPoint.snapTime = 2f;

        StartCoroutine(ResetFrisbee());
    }

    private IEnumerator ResetFrisbee()
    {
        yield return new WaitForSeconds(2f);

        lockToPoint.enabled = false;
        hasBeenThrown = false;
        lockToPoint.snapTo = rightHandPos;
        lockToPoint.snapTime = startSnapTime;
    }
}
