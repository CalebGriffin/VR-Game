using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Mole : MonoBehaviour
{
    [SerializeField] protected GameObject[] hats;
    [SerializeField] protected GameObject[] glasses;
    [SerializeField] protected GameObject[] neckAccessories;
    [SerializeField] protected GameObject[] moustaches;

    [SerializeField] private GameObject playerHead;

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
    }

    virtual public void Hit(string hammerName)
    {
        // This will be overridden by the inherited classes
    }

    protected void CorrectHit()
    {
        transform.parent.gameObject.SendMessage("MoleKilled");
        gVar.score = (int)Mathf.Clamp(gVar.score + (100 * gVar.currentCombo), 0, Mathf.Infinity);
        ComboBar.Instance.ScoreTextUpdate();
        ComboBar.Instance.IncreaseCombo();
        Destroy(this.gameObject);
    }

    protected void IncorrectHit()
    {
        gVar.score = (int)Mathf.Clamp(gVar.score - 100, 0, Mathf.Infinity);
        ComboBar.Instance.ScoreTextUpdate();
        ComboBar.Instance.ResetCombo();
    }

    virtual public void Despawn()
    {
        transform.parent.gameObject.SendMessage("MoleKilled");
        Destroy(this.gameObject);
    }

    virtual public void GetDressed(Material colouredMat)
    {
        ItemPicker(hats, true, colouredMat);
        ItemPicker(glasses, false, colouredMat);
        ItemPicker(neckAccessories, false, colouredMat);
        ItemPicker(moustaches, false, colouredMat);
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
