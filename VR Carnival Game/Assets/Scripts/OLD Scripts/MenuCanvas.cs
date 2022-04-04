using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    private Camera eventCam;

    // Start is called before the first frame update
    void Start()
    {
        eventCam = GetComponent<Canvas>().worldCamera;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(eventCam.transform);
        transform.rotation = Quaternion.Euler(transform.rotation.x, -transform.rotation.y, transform.rotation.z);
        
    }
}
