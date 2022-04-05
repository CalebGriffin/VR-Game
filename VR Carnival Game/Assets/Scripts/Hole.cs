using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private GameObject[] moles; // An array of the moles in this hole

    private bool canSpawnMole = true; // A bool to check if the moles can spawn in this hole

    private Vector3 startPos; // The starting position of the hole used to animate the hole opening

    private bool holeAnimating; // A bool to check if the hole is currently animating

    private int animationPower = 9; // The amount that the hole will move when animating

    private bool hasMole = false; // A bool to check if the hole has a mole in it
    
    // Start is called before the first frame update
    void Start()
    {
        // Set the start position of the hole
        startPos = transform.localPosition;

        // Add this hole to the global list of holes
        gVar.holes.Add(this.gameObject);
    }

    // This method is called when this object is enabled
    void OnEnable()
    {
        // Set up the boolean variables
        holeAnimating = false;
        hasMole = false;
        canSpawnMole = true;

        // Add this hole to the global list of holes
        gVar.holes.Add(this.gameObject);

        // Call the method to animate the hole opening
        AnimateIn();
    }

    // When the object is disabled, remove this hole from the global list of holes and set the parent object to inactive
    void OnDisable()
    {
        gVar.holes.Remove(this.gameObject);
        transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If the hole is animating, set the hole to a random position
        if (holeAnimating)
        {
            float randX = Random.Range(startPos.x - (0.001f * animationPower), startPos.x + ((0.001f * animationPower) + 0.0001f));
            float randZ = Random.Range(startPos.z - (0.001f * animationPower), startPos.z + ((0.001f * animationPower) + 0.0001f));

            transform.localPosition = new Vector3(randX, transform.localPosition.y, randZ);
        }
        // Else, if the hole is not animating, set the hole to the start position
        else
        {
            transform.localPosition = startPos;
        }
    }

    // Set the objects scale to 0 and start the opening animation
    private void AnimateIn()
    {
        transform.localScale = Vector3.zero;
        LeanTween.cancel(this.gameObject);
        LeanTween.scale(this.gameObject, new Vector3(0.8f, 0.8f, 0.8f), 1f);
    }

    // Set this GameObject to inactive
    void DisableHole()
    {
        this.gameObject.SetActive(false);
    }

    // Removes the mole from the hole and animates the hole closing
    private void AnimateOut()
    {
        DestroyMoles();
        LeanTween.cancel(this.gameObject);
        LeanTween.scale(this.gameObject, Vector3.zero, 1f).setOnComplete(DisableHole);
    }

    // Destroys the moles in this hole
    private void DestroyMoles()
    {
        foreach(GameObject mole in moles)
        {
            mole.SetActive(false);
        }
    }

    // Spawns a mole in this hole if it can spawn a mole
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

    // Coroutine to delay the spawning of a mole to fit with the beat of the music
    public IEnumerator SpawnMoleDelay()
    {
        yield return new WaitForSeconds(0.5f);

        // Stop the animation
        holeAnimating = false;

        // Pick a random mole to spawn
        int moleIndex = Random.Range(0,2);
        moles[moleIndex].SetActive(true);
        hasMole = true;

        // Start the coroutine to destroy the mole if it is not hit
        StartCoroutine(MoleTimeout(moles[moleIndex]));
    }

    // This method is called when the mole is hit by the player
    // It will remove the hole from the global list of holes and start the coroutine to reset the hole to spawn another mole
    public void MoleKilled()
    {
        canSpawnMole = false;
        hasMole = false;
        gVar.holes.Remove(this.gameObject);
        StartCoroutine(MoleReset());
    }

    // Wait for 2 seconds before resetting the hole to spawn another mole
    private IEnumerator MoleReset()
    {
        yield return new WaitForSeconds(2f);

        canSpawnMole = true;
        hasMole = false;
        gVar.holes.Add(this.gameObject);
    }

    // Wait for 4 seconds before destroying the mole
    private IEnumerator MoleTimeout(GameObject mole)
    {
        yield return new WaitForSeconds(4f);

        // Using try catch to prevent the game from crashing if the mole is destroyed before the coroutine is finished
        try
        {
            mole.SendMessage("Despawn");
            gVar.molesMissed++;
        }
        catch (MissingReferenceException)
        {
            // Mole was hit before timeout
        }
    }
}
