using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    // Variables for the start and end rotation of the object
    private Quaternion targetRotation;
    private Quaternion startingRotation;

    // Variables for the start and end position of the object
    private Vector3 targetPosition;
    private Vector3 startingPosition;

    private float timePerSlerp = 10f; // Amount of time that it takes to rotate the object

    private float timePerLerp = 30f; // Amount of time that it takes to move the object

    private float slerpTimeElapsed = 0f; // Amount of time since the object started rotating

    private float lerpTimeElapsed = 0f; // Amount of time since the object started moving

    private float floatingSpeed = 10f; // The speed at which the object moves

    private int spawnArea = 12; // The size of the area in which the object can spawn

    // Start is called before the first frame update
    void Start()
    {
        // Set the target rotation to a random rotation and set the starting rotation to the current rotation
        targetRotation = RandomRotation();
        startingRotation = transform.rotation;

        // Set the target position to a random position and set the starting position to the current position
        targetPosition = RandomPosition();
        startingPosition = transform.position;

        // Start the coroutine to play the sound represented by the animal
        StartCoroutine(PlaySound());
    }

    // Update is called once per frame
    void Update()
    {
        // If it has reached the target rotation, set the target rotation to a random rotation and reset the slerp time elapsed
        if (transform.rotation == targetRotation)
        {
            targetRotation = RandomRotation();
            slerpTimeElapsed = 0f;
            startingRotation = transform.rotation;
        }
        // Else, rotate the object towards the target rotation
        else
        {
            transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, slerpTimeElapsed / timePerSlerp);
        }

        // If it has reached the target position, set the target position to a random position and reset the lerp time elapsed
        if (transform.position == targetPosition)
        {
            targetPosition = RandomPosition();
            lerpTimeElapsed = 0f;
            startingPosition = transform.position;
        }
        // Else, move the object towards the target position
        else
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, lerpTimeElapsed / timePerLerp);
        }

        // Increase the slerp time elapsed and the lerp time elapsed by the amount of time that has passed since the last frame
        slerpTimeElapsed += Time.deltaTime;
        lerpTimeElapsed += Time.deltaTime;
    }

    // Returns a random rotation
    private Quaternion RandomRotation()
    {
        float randomX = Random.Range(-360f, 360.1f);
        float randomZ = Random.Range(-360f, 360.1f);
        float randomY = Random.Range(-360f, 360.1f);

        return Quaternion.Euler(randomX, randomY, randomZ);
    }

    // Returns a random position
    private Vector3 RandomPosition()
    {
        Vector3 returnValue = Random.onUnitSphere * 15f;
        RaycastHit hit;
        while (Physics.Raycast(transform.position, returnValue - transform.position, out hit) && hit.collider.gameObject.CompareTag("InnerSphere"))
        {
            returnValue = Random.onUnitSphere * 15f;
        }
        return returnValue;
    }

    // Waits for a random amount of time and then plays the sound represented by the animal, then calls itself continuously
    private IEnumerator PlaySound()
    {
        float randomTime = Random.Range(10f, 30f);
        yield return new WaitForSeconds(randomTime);
        this.gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(PlaySound());
    }
}
