using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleHolder : MonoBehaviour
{
    [SerializeField] private GameObject table;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        float newX = 1f / table.transform.localScale.x;
        float newY = 1f / table.transform.localScale.y;
        float newZ = 1f / table.transform.localScale.z;

        transform.localScale = new Vector3(newX, newY, newZ);
    }
}
