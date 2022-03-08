using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] holes;

    // Start is called before the first frame update
    void Start()
    {
        holes = GameObject.FindGameObjectsWithTag("Hole");
        StartCoroutine(SpawnMoles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnMoles()
    {
        // Generate a random amount of time between 2 and 5 seconds
        //int waitTime = Random.Range(2,6);

        // Wait for that amount of time
        //yield return new WaitForSeconds(waitTime);

        yield return new WaitForSeconds(0.5f);

        // Generate a random number of moles to spawn based on the size of the holes array
        //int noOfMolesToSpawn = Random.Range(holes.Length / 2, holes.Length / 5);

        int noOfMolesToSpawn = Random.Range(1,3);
        
        for (int i = 0; i < noOfMolesToSpawn; i++)
        {
            bool moleSpawned = false;
            int loopCount = 0;
            while(!moleSpawned)
            {
                loopCount++;
                int holeIndex = Random.Range(0, holes.Length);
                if (holes[holeIndex].GetComponent<Hole>().CanAMoleSpawn() == true)
                {
                    //holes[holeIndex].SendMessage("SpawnMole");
                    holes[holeIndex].GetComponent<Hole>().SpawnMole();
                    moleSpawned = true;
                }
                
                if (loopCount >= holes.Length)
                {
                    Debug.Log("No Hole Found");
                    break;
                }
            }
        }

        StartCoroutine(SpawnMoles());
    }
}
