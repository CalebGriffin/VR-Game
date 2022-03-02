using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private GameObject[] moles;

    [SerializeField] private float moleHeight = 1f;
    
    //private int molesSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMole()
    {
        int moleIndex = Random.Range(0,2);
        GameObject prefab = GameObject.Instantiate(moles[moleIndex], transform.position + Vector3.up * moleHeight, transform.rotation);
        prefab.transform.parent = this.gameObject.transform;
    }

    public bool HasMole()
    {
        return this.gameObject.transform.childCount > 6;
    }
}
