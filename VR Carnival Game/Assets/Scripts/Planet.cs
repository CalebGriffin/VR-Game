using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private GameObject planetCollider;

    private int distance = 150;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomScale();
        SetRandomRotation();
        SetRandomPosition();
    }

    private void SetRandomScale()
    {
        float randScale = Random.Range(0.5f, 2.1f);
        transform.localScale = new Vector3(randScale, randScale, randScale);
    }

    private void SetRandomRotation()
    {
        float randomX = Random.Range(-360f, 360.1f);
        float randomZ = Random.Range(-360f, 360.1f);
        float randomY = Random.Range(-360f, 360.1f);

        transform.rotation = Quaternion.Euler(randomX, randomY, randomZ);
    }

    private void SetRandomPosition()
    {
        float randomX = Random.Range(-distance, distance);
        float randomY = Random.Range(0, distance);
        float randomZ = Random.Range(-distance, distance);
        Vector3 randomVector3 = new Vector3(randomX, randomY, randomZ);

        while (planetCollider.GetComponent<BoxCollider>().bounds.Contains(randomVector3))
        {
            randomX = Random.Range(-distance, distance);
            randomY = Random.Range(0, distance);
            randomZ = Random.Range(-distance, distance);
            randomVector3 = new Vector3(randomX, randomY, randomZ);
        }

        transform.position = randomVector3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
