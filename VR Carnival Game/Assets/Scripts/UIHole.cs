using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIHole : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    [SerializeField] private GameObject[] moles;

    [SerializeField] private float moleHeight = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void AnimateIn()
    {
        transform.localScale = Vector3.zero;
        LeanTween.cancel(this.gameObject);
        LeanTween.scale(this.gameObject, new Vector3(0.8f, 0.8f, 0.8f), 1f);
        SpawnMole();
    }

    private void AnimateOut()
    {
        LeanTween.cancel(this.gameObject);
        LeanTween.scale(this.gameObject, Vector3.zero, 1f).setOnComplete(HideParent);
        DestroyMoles();
    }

    private void HideParent()
    {
        transform.parent.gameObject.SetActive(false);
    }


    public void SpawnMole()
    {
        int moleIndex = Random.Range(0,2);
        moles[moleIndex].SetActive(true);
    }

    public void DestroyMoles()
    {
        foreach (GameObject mole in moles)
        {
            mole.SetActive(false);
        }
    }

    public void MoleKilled()
    {
        action.Invoke();
    }
}
