using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    private int prevHoleIndex = -1; // Used to track which hole was previously called

    // When the object is enabled, start the coroutines that spawns the moles
    void OnEnable()
    {
        StartCoroutine(WaitToSpawnMoles());
    }

    // Stop all coroutines when the object is disabled
    void OnDisable()
    {
        StopAllCoroutines();
    }

    // Waits for 3 seconds and then starts the looping coroutine that spawns the moles
    private IEnumerator WaitToSpawnMoles()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(SpawnMoles());
    }

    // Looping coroutine which tells the holes to spawn moles
    public IEnumerator SpawnMoles()
    {
        yield return new WaitForSeconds(0.5f);

        // Generates a random number between 1 and 3
        int noOfMolesToSpawn = Random.Range(1,3);
        
        for (int i = 0; i < noOfMolesToSpawn; i++)
        {
            // Wait for a small amount of time to prevent bugs
            yield return new WaitForSeconds(0.01f);

            // If the list of available holes isn't empty then choose a random hole and tell it to spawn a mole
            if (gVar.holes.Count > 0)
            {
                int holeIndex = Random.Range(0, gVar.holes.Count);

                if (holeIndex != prevHoleIndex)
                {
                    gVar.holes[holeIndex].SendMessage("SpawnMole");
                }

                // Set the previous hole to the current hole for the next iteration
                prevHoleIndex = holeIndex;
            }
        }

        // Call the coroutine again, making it a loop
        StartCoroutine(SpawnMoles());
    }
}
