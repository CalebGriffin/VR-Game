using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    private Quaternion targetRotation;

    private Quaternion startingRotation;

    private Vector3 targetPosition;

    private Vector3 startingPosition;

    private Rigidbody rb;

    private GameObject innerSphere;

    private float timePerSlerp = 10f;

    private float timePerLerp = 30f;

    private float slerpTimeElapsed = 0f;

    private float lerpTimeElapsed = 0f;

    private float floatingSpeed = 10f;

    private int spawnArea = 12;

    //private bool waited = false;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.AddRelativeForce(RandomForce());

        innerSphere = GameObject.FindGameObjectWithTag("InnerSphere");
        //innerSphere = GameObject.Find("Inner Sphere");
        Debug.Log(innerSphere);

        targetRotation = RandomRotation();
        startingRotation = transform.rotation;

        targetPosition = RandomPosition2();
        startingPosition = transform.position;

        StartCoroutine(PlaySound());


        //StartCoroutine(Waited());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation == targetRotation)
        {
            targetRotation = RandomRotation();
            slerpTimeElapsed = 0f;
            startingRotation = transform.rotation;
        }
        else
        {
            transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, slerpTimeElapsed / timePerSlerp);
        }

        if (transform.position == targetPosition)
        {
            targetPosition = RandomPosition2();
            lerpTimeElapsed = 0f;
            startingPosition = transform.position;
        }
        else
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, lerpTimeElapsed / timePerLerp);
        }

        //if (rb.velocity.magnitude <= 0.05f && waited)
        //{
            //rb.AddRelativeForce(RandomForce());
            //waited = false;
            //StartCoroutine(Waited());
        //}

        slerpTimeElapsed += Time.deltaTime;
        lerpTimeElapsed += Time.deltaTime;
    }

    //private IEnumerator Waited()
    //{
        //yield return new WaitForSeconds(2f);

        //waited = true;
    //}

    private Quaternion RandomRotation()
    {
        float randomX = Random.Range(-360f, 360.1f);
        float randomZ = Random.Range(-360f, 360.1f);
        float randomY = Random.Range(-360f, 360.1f);

        return Quaternion.Euler(randomX, randomY, randomZ);
    }

    //private Vector3 RandomForce()
    //{
        //float randomX = Random.Range(-10f, 10.1f);
        //float randomY = Random.Range(-10f, 10.1f);
        //float randomZ = Random.Range(-10f, 10.1f);

        //return new Vector3(randomX, randomY, randomZ) * floatingSpeed;
    //}

    private Vector3 RandomPosition()
    {
        float randomX = Random.Range(-spawnArea, spawnArea + 0.1f);
        float randomY = Random.Range(-spawnArea, spawnArea + 0.1f);
        float randomZ = Random.Range(-spawnArea, spawnArea + 0.1f);
        Vector3 randomVector3 = new Vector3(randomX, randomY, randomZ);

        while (innerSphere.GetComponent<SphereCollider>().bounds.Contains(randomVector3))
        {
            randomX = Random.Range(-spawnArea, spawnArea + 0.1f);
            randomY = Random.Range(-spawnArea, spawnArea + 0.1f);
            randomZ = Random.Range(-spawnArea, spawnArea + 0.1f);
            randomVector3 = new Vector3(randomX, randomY, randomZ);
        }

        return randomVector3;
    }

    private Vector3 RandomPosition2()
    {
        Vector3 returnValue = Random.onUnitSphere * 15f;
        RaycastHit hit;
        while (Physics.Raycast(transform.position, returnValue - transform.position, out hit) && hit.collider.gameObject.CompareTag("InnerSphere"))
        {
            returnValue = Random.onUnitSphere * 15f;
        }
        return returnValue;
    }

    private IEnumerator PlaySound()
    {
        float randomTime = Random.Range(10f, 30f);
        yield return new WaitForSeconds(randomTime);
        this.gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(PlaySound());
    }

    void OnCollisionEnter(Collision other)
    {
        //rb.velocity = rb.velocity * 1.1f;
        //rb.AddRelativeForce(RandomForce());
    }
}
