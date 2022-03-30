using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class UIMole : MonoBehaviour
{
    [SerializeField] protected GameObject[] hats;
    [SerializeField] protected GameObject[] glasses;
    [SerializeField] protected GameObject[] neckAccessories;
    [SerializeField] protected GameObject[] moustaches;

    [SerializeField] private GameObject playerHead;

    //[SerializeField] protected GameObject deathParticles;

    // Start is called before the first frame update
    virtual public void Start()
    {
        
    }

    // Update is called once per frame
    virtual public void Update()
    {
        
    }

    virtual public void OnEnable()
    {
        playerHead = GameObject.FindGameObjectWithTag("PlayerHead");
        FaceThePlayer();
        //DeathParticles();
    }

    virtual public void OnDisable()
    {
        GetUndressed();
    }

    virtual public void Hit(string hammerName)
    {
        // This will be overridden by the inherited classes
    }

    protected void CorrectHit()
    {
        transform.parent.gameObject.SendMessage("MoleKilled");
    }

    protected void IncorrectHit()
    {
    }

    //virtual public void DeathParticles()
    //{
        //GameObject prefab = GameObject.Instantiate(deathParticles, transform.position, Quaternion.identity);
        //prefab.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
    //}

    virtual public void GetDressed(Material colouredMat)
    {
        ItemPicker(hats, true, colouredMat);
        ItemPicker(glasses, false, colouredMat);
        ItemPicker(neckAccessories, false, colouredMat);
        ItemPicker(moustaches, false, colouredMat);
    }

    virtual public void GetUndressed()
    {
        ItemHider(hats);
        ItemHider(glasses);
        ItemHider(neckAccessories);
        ItemHider(moustaches);
    }

    virtual protected void ItemHider(GameObject[] accessoryArray)
    {
        foreach (GameObject go in accessoryArray)
        {
            go.SetActive(false);
        }
    }

    virtual protected void ItemPicker(GameObject[] accessoryArray, bool isHats, Material colouredMat)
    {
        int randomIndex = -1;

        if (isHats)
        {
            randomIndex = Random.Range(0, accessoryArray.Length);
        }
        else
        {
            randomIndex = Random.Range(-1, accessoryArray.Length);
        }

        if (randomIndex != -1)
        {
            accessoryArray[randomIndex].SetActive(true);
            accessoryArray[randomIndex].SendMessage("ColourPicker", colouredMat);
        }
    }

    private void FaceThePlayer()
    {
        Vector3 lookPos = playerHead.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
    }
}
