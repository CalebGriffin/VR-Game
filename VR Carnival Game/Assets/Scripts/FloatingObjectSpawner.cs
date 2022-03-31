using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] floatingObjects;

    [SerializeField] private GameObject innerSphere;

    // Start is called before the first frame update
    void Start()
    {
        int randomAmount = Random.Range(10, 20);
        for (int i = 0; i < randomAmount; i++)
        {
            SpawnObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator DelayedSpawn()
    {
        Debug.Log("Delayed Spawn Started");

        yield return new WaitForSeconds(30f);

        Debug.Log("Delayed Spawn Waited");

        SpawnObject();

        StartCoroutine(DelayedSpawn());
    }

    private void SpawnObject()
    {
        int randomIndex = Random.Range(0, floatingObjects.Length);
        float randomX = Random.Range(-13f, 13.1f);
        float randomY = Random.Range(-13f, 13.1f);
        float randomZ = Random.Range(-13f, 13.1f);
        while (innerSphere.GetComponent<SphereCollider>().bounds.Contains(new Vector3(randomX, randomY, randomZ)))
        {
            randomX = Random.Range(-13f, 13.1f);
            randomY = Random.Range(-13f, 13.1f);
            randomZ = Random.Range(-13f, 13.1f);
        }


        GameObject prefab = GameObject.Instantiate(floatingObjects[randomIndex], RandomPosition(), Quaternion.identity);

        //Debug.Log("Spawning an Object @ " + new Vector3(randomX, randomY, randomZ));
    }

    private Vector3 RandomPosition()
    {
        return Random.onUnitSphere * 15f;
    }

    private IEnumerator DestroyObject(GameObject prefab)
    {
        yield return new WaitForSeconds(30f);

        Destroy(prefab);
        SpawnObject();
    }
}
