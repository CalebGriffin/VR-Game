using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private GameObject[] moles;

    [SerializeField] private float moleHeight = 1f;

    private bool canSpawnMole = true;
    
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
        StartCoroutine(MoleTimeout(prefab));
    }

    public bool CanAMoleSpawn()
    {
        if (canSpawnMole)
        {
            return !HasMole();
        }
        else
        {
            return canSpawnMole;
        }
    }

    public bool HasMole()
    {
        return this.gameObject.transform.childCount > 5;
    }

    public void MoleKilled()
    {
        canSpawnMole = false;
        StartCoroutine(MoleReset());
    }

    private IEnumerator MoleReset()
    {
        yield return new WaitForSeconds(2f);

        canSpawnMole = true;
    }

    private IEnumerator MoleTimeout(GameObject mole)
    {
        yield return new WaitForSeconds(5f);

        mole.SendMessage("Despawn");
    }
}
