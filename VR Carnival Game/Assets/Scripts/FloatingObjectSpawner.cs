using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] floatingObjects; // Array of GameObjects to be spawned

    [SerializeField] private GameObject innerSphere; // The collider where the GameObjects shouldn't be spawned

    // Start is called before the first frame update
    void Start()
    {
        // Choose a random number of GameObjects to be spawned and spawn them
        int randomAmount = Random.Range(10, 20);
        for (int i = 0; i < randomAmount; i++)
        {
            SpawnObject();
        }
    }

    // Spawn a floating object at a random position that isn't inside the innerSphere
    private void SpawnObject()
    {
        int randomIndex = Random.Range(0, floatingObjects.Length);

        GameObject prefab = GameObject.Instantiate(floatingObjects[randomIndex], RandomPosition(), Quaternion.identity);

        // Debug.Log for testing
        //Debug.Log("Spawning an Object @ " + new Vector3(randomX, randomY, randomZ));
    }

    // Return a random position that is on the surface of a sphere
    private Vector3 RandomPosition()
    {
        return Random.onUnitSphere * 15f;
    }
}
