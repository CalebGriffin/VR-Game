using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    private Quaternion targetRotation;

    private Quaternion startingRotation;

    private Rigidbody rb;

    private float timePerSlerp = 15f;

    private float timeElapsed = 0f;

    private float floatingSpeed = 10f;

    private bool waited = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(RandomForce());

        targetRotation = RandomRotation();
        startingRotation = transform.rotation;

        StartCoroutine(Waited());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation == targetRotation)
        {
            targetRotation = RandomRotation();
            timeElapsed = 0f;
            startingRotation = transform.rotation;
        }
        else
        {
            transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, timeElapsed / timePerSlerp);
        }

        if (rb.velocity.magnitude <= 0.05f && waited)
        {
            rb.AddRelativeForce(RandomForce());
            waited = false;
            StartCoroutine(Waited());
        }

        timeElapsed += Time.deltaTime;
    }

    private IEnumerator Waited()
    {
        yield return new WaitForSeconds(2f);

        waited = true;
    }

    private Quaternion RandomRotation()
    {
        float randomX = Random.Range(-360f, 360.1f);
        float randomZ = Random.Range(-360f, 360.1f);
        float randomY = Random.Range(-360f, 360.1f);

        return Quaternion.Euler(randomX, randomY, randomZ);
    }

    private Vector3 RandomForce()
    {
        float randomX = Random.Range(-10f, 10.1f);
        float randomY = Random.Range(-10f, 10.1f);
        float randomZ = Random.Range(-10f, 10.1f);

        return new Vector3(randomX, randomY, randomZ) * floatingSpeed;
    }

    void OnCollisionEnter(Collision other)
    {
        rb.velocity = rb.velocity * 1.1f;
        rb.AddRelativeForce(RandomForce());
    }
}
