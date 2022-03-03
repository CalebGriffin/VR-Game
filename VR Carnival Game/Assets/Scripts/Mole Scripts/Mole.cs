using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    // Start is called before the first frame update
    virtual public void Start()
    {
        
    }

    // Update is called once per frame
    virtual public void Update()
    {
        
    }

    virtual public void Hit(string hammerName)
    {

    }

    virtual public void Despawn()
    {
        transform.parent.gameObject.SendMessage("MoleKilled");
        Destroy(this.gameObject);
    }
}
