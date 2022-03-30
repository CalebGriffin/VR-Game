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

    private bool hasMole = false;
    
    //private int molesSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        gVar.holes.Add(this.gameObject);
    }

    void OnEnable()
    {
        AnimateIn();
    }

    void OnDisable()
    {
        AnimateOut();
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

    private void AnimateIn()
    {
        transform.localScale = Vector3.zero;
        LeanTween.cancel(this.gameObject);
        LeanTween.scale(this.gameObject, new Vector3(0.8f, 0.8f, 0.8f), 1f);
    }

    private void AnimateOut()
    {
        LeanTween.cancel(this.gameObject);
        LeanTween.scale(this.gameObject, Vector3.zero, 1f);
    }


    public void SpawnMole()
    {
        if (!hasMole)
        {
            holeAnimating = true;
            hasMole = true;
            gVar.holes.Remove(this.gameObject);
            StartCoroutine(SpawnMoleDelay());
        }
    }

    public IEnumerator SpawnMoleDelay()
    {
        yield return new WaitForSeconds(0.5f);

        holeAnimating = false;

        int moleIndex = Random.Range(0,2);
        moles[moleIndex].SetActive(true);
        hasMole = true;
        //GameObject prefab = GameObject.Instantiate(moles[moleIndex], transform.position + transform.up * moleHeight, transform.rotation);
        //prefab.transform.parent = this.gameObject.transform;
        //prefab.transform.localScale = Vector3.one;
        //prefab.SendMessage("OnEnable");
        StartCoroutine(MoleTimeout(moles[moleIndex]));
    }

    public bool CanAMoleSpawn()
    {
        if (canSpawnMole)
        {
            return !hasMole;
        }
        else
        {
            return canSpawnMole;
        }
    }

    public void MoleKilled()
    {
        canSpawnMole = false;
        hasMole = false;
        gVar.holes.Remove(this.gameObject);
        StartCoroutine(MoleReset());
    }

    private IEnumerator MoleReset()
    {
        yield return new WaitForSeconds(2f);

        canSpawnMole = true;
        hasMole = false;
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
