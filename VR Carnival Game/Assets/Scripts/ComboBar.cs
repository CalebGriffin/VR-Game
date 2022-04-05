using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComboBar : MonoBehaviour
{
    private static ComboBar instance; // The singleton instance of this class

    // The public property to get the singleton instance of this class
    public static ComboBar Instance
    {
        get
        {
            return instance;
        }
    }

    private float value = 0f; // The current value of the combo bar (1-100)

    private float decreaseAmount = 15f; // The amount the combo bar decreases by each second

    private bool justHit = false; // Whether or not a mole was just hit (used to prevent the combo bar from increasing too quickly)

    [SerializeField] private TextMeshProUGUI comboBarText; // The text that displays the current value of the combo bar
    [SerializeField] private Slider comboBarSlider; // The slider that displays the current value of the combo bar

    // Awake is called one frame before Start
    void Awake()
    {
        // If the singleton instance of this class is already set, destroy this object, else, set the singleton instance of this class to this object
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Set the value of this combo bar but don't let it go below 0 or above 100
        value = Mathf.Clamp(value - (decreaseAmount * Time.deltaTime), 0, 100);

        // Set the value of the combo bar slider to the value of this combo bar
        comboBarSlider.value = value;

        // Set the global variable currentCombo to the value of this combo bar divided by 20 but don't let it go below 1 or above 5
        gVar.currentCombo = (int)Mathf.Clamp((value / 20) + 1, 1, 5);

        // Set the text of the combo bar to the value of this combo bar
        comboBarText.text = "x" + gVar.currentCombo.ToString();
    }

    // This method is called whene a mole is hit
    public void IncreaseCombo()
    {
        // If the mole hasn't just been hit, increase the value of this combo bar by 12
        if (!justHit)
        {
            value = Mathf.Clamp(value + 12f, 0, 100);
        }

        justHit = true;

        // Call the coroutine to reset the justHit bool
        StartCoroutine(HitDelay());
    }

    // Resets the justHit bool to false after a short delay to prevent the combo bar from increasing too quickly
    private IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(0.15f);
        
        justHit = false;
    }

    // This method is called when a mole is hit incorrectly and resets the value of this combo bar to 0
    public void ResetCombo()
    {
        value = 0;
    }
}
