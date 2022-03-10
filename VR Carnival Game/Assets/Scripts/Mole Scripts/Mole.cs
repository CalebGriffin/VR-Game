using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

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
}
