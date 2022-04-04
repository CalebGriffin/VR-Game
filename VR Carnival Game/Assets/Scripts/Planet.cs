using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private GameObject planetCollider; // This controls where the planets cannot spawn

    private int distance = 150; // The distance away from the player that the planets can spawn

    // Start is called before the first frame update
    void Start()
    {
        // Give the planet a random scale, position and rotation
        SetRandomScale();
        SetRandomPosition();
        SetRandomRotation();
    }

    // Set the scale of the object to a random number between .5 and 2
    private void SetRandomScale()
    {
        float randScale = Random.Range(0.5f, 2.1f);
        transform.localScale = new Vector3(randScale, randScale, randScale);
    }

    // Set the rotation of the planet to be a random rotation
    private void SetRandomRotation()
    {
        float randomX = Random.Range(-360f, 360.1f);
        float randomZ = Random.Range(-360f, 360.1f);
        float randomY = Random.Range(-360f, 360.1f);

        transform.rotation = Quaternion.Euler(randomX, randomY, randomZ);
    }

    // Give the planet a random position
    private void SetRandomPosition()
    {
        // Generate a random position
        float randomX = Random.Range(-distance, distance);
        float randomY = Random.Range(0, distance);
        float randomZ = Random.Range(-distance, distance);
        Vector3 randomVector3 = new Vector3(randomX, randomY, randomZ);

        // If the random position is inside the collider then find a different position and repeat
        while (planetCollider.GetComponent<BoxCollider>().bounds.Contains(randomVector3))
        {
            randomX = Random.Range(-distance, distance);
            randomY = Random.Range(0, distance);
            randomZ = Random.Range(-distance, distance);
            randomVector3 = new Vector3(randomX, randomY, randomZ);
        }

        // Set the position of the planet to the random position
        transform.position = randomVector3;
    }
}
