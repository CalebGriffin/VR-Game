using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private GameObject[] moles;

    [SerializeField] private float moleHeight = 1f;

    private bool canSpawnMole = true;

    private Vector3 startPos;

    private bool holeAnimating;

    private int animationPower = 9;
    
    //private int molesSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (holeAnimating)
        {
            float randX = Random.Range(startPos.x - (0.001f * animationPower), startPos.x + ((0.001f * animationPower) + 0.0001f));
            float randZ = Random.Range(startPos.z - (0.001f * animationPower), startPos.z + ((0.001f * animationPower) + 0.0001f));

            transform.localPosition = new Vector3(randX, transform.localPosition.y, randZ);
        }
        else
        {
            transform.localPosition = startPos;
        }
    }

    public void SpawnMole()
    {
        holeAnimating = true;
        StartCoroutine(SpawnMoleDelay());
    }

    public IEnumerator SpawnMoleDelay()
    {
        yield return new WaitForSeconds(0.5f);

        holeAnimating = false;

        int moleIndex = Random.Range(0,2);
        GameObject prefab = GameObject.Instantiate(moles[moleIndex], transform.position + transform.up * moleHeight, transform.rotation);
        prefab.transform.parent = this.gameObject.transform;
        prefab.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
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
        yield return new WaitForSeconds(3f);

        mole.SendMessage("Despawn");
    }
}
