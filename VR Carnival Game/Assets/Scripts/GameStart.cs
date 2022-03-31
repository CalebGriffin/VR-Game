using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject menuMusicSource;
    [SerializeField] private GameObject gameMusicSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        Stuff();
    }

    [ContextMenu("Stuff")]
    void Stuff()
    {
        Debug.Log("Stuff");
        gameManager.GetComponent<Timer>().enabled = true;
        gameManager.GetComponent<HoleManager>().enabled = true;
        menuMusicSource.GetComponent<AudioSource>().Stop();
        gameMusicSource.GetComponent<AudioSource>().Stop();
        menuMusicSource.SetActive(false);
        gameMusicSource.SetActive(true);
    }
}
