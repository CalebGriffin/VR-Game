using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private float decreaseAmount = 15f;

    private bool justHit = false;

    [SerializeField] private TextMeshProUGUI comboBarText;
    [SerializeField] private Slider comboBarSlider;

    [SerializeField] private TextMeshProUGUI scoreText;

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
        comboBarSlider.value = value;
        gVar.currentCombo = (int)Mathf.Clamp((value / 20) + 1, 1, 5);

        comboBarText.text = "x" + gVar.currentCombo.ToString();
        //comboBarText.text = value.ToString();
    }

    public void IncreaseCombo()
    {
        if (!justHit)
        {
            value = Mathf.Clamp(value + 12f, 0, 100);
        }

        justHit = true;
        StartCoroutine(HitDelay());
    }

    private IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(0.15f);
        
        justHit = false;
    }

    public void ResetCombo()
    {
        value = 0;
    }

    public void ScoreTextUpdate()
    {
        scoreText.text = gVar.score.ToString();
    }
}
