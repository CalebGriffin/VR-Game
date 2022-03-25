using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private GameObject[] moles;

    [SerializeField] private float moleHeight = 0.01f;

    private bool canSpawnMole = true;

    private Vector3 startPos;

    private bool holeAnimating;

    private int animationPower = 9;
    
    //private int molesSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        gVar.holes.Add(this.gameObject);
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

        if (this.gameObject.transform.childCount > 6)
        {
            Destroy(this.gameObject.transform.GetChild(7).gameObject);
        }
    }

    public void SpawnMole()
    {
        if (this.gameObject.transform.childCount == 5)
        {
            holeAnimating = true;
            gVar.holes.Remove(this.gameObject);
            StartCoroutine(SpawnMoleDelay());
        }
    }

    public IEnumerator SpawnMoleDelay()
    {
        yield return new WaitForSeconds(0.5f);

        holeAnimating = false;

        int moleIndex = Random.Range(0,2);
        GameObject prefab = GameObject.Instantiate(moles[moleIndex], transform.position + transform.up * moleHeight, transform.rotation);
        prefab.transform.parent = this.gameObject.transform;
        prefab.transform.localScale = Vector3.one;
        //prefab.SendMessage("OnEnable");
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
        gVar.holes.Remove(this.gameObject);
        StartCoroutine(MoleReset());
    }

    private IEnumerator MoleReset()
    {
        yield return new WaitForSeconds(2f);

        canSpawnMole = true;
        gVar.holes.Add(this.gameObject);
    }

    private IEnumerator MoleTimeout(GameObject mole)
    {
        yield return new WaitForSeconds(4f);

        try
        {
            mole.SendMessage("Despawn");
        }
        catch (MissingReferenceException)
        {
            // Mole was hit before timeout
        }
    }
}
