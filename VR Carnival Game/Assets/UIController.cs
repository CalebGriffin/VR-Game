using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] private TextMeshProUGUI musicTitleText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string musicTitle = musicSource.clip.ToString();
        string[] actualMusicTitle = musicTitle.Split(' ');
        musicTitleText.text = "Music Title: " + actualMusicTitle[0];
    }
}
