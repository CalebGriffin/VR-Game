using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboBar : MonoBehaviour
{
    private static ComboBar instance;

    public static ComboBar Instance
    {
        get
        {
            return instance;
        }
    }

    private float value = 0f;

    private float decreaseAmount = 5f;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        value = Mathf.Clamp(value - (decreaseAmount * Time.deltaTime), 0, 100);
    }

    public void IncreaseCombo()
    {
        value = Mathf.Clamp(value + 20, 0, 100);
    }
}
