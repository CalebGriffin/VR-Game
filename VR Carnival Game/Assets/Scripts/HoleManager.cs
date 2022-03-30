using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    private int prevHoleIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToSpawnMoles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitToSpawnMoles()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(SpawnMoles());
    }

    public IEnumerator SpawnMoles()
    {
        yield return new WaitForSeconds(0.5f);

        //foreach (GameObject obj in gVar.holes)
        //{
            //Debug.Log(obj.name);
        //}

        int noOfMolesToSpawn = Random.Range(1,3);
        
        for (int i = 0; i < noOfMolesToSpawn; i++)
        {
            yield return new WaitForSeconds(0.01f);
            if (gVar.holes.Count > 0)
            {
                int holeIndex = Random.Range(0, gVar.holes.Count);
                //Debug.Log(gVar.holes.Count + " " + holeIndex);
                if (holeIndex != prevHoleIndex)
                {
                    gVar.holes[holeIndex].SendMessage("SpawnMole");
                }
                prevHoleIndex = holeIndex;
            }
        }

        StartCoroutine(SpawnMoles());
    }
}
