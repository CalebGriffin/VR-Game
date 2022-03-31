using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReset : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject menuMusicSource;
    [SerializeField] private GameObject gameMusicSource;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Game Reset");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        Stuff2();
    }

    [ContextMenu("Stuff2")]
    void Stuff2()
    {
        Debug.Log("Stuff2");
        gameManager.GetComponent<Timer>().enabled = false;
        gameManager.GetComponent<HoleManager>().enabled = false;
        menuMusicSource.GetComponent<AudioSource>().Stop();
        gameMusicSource.GetComponent<AudioSource>().Stop();
        menuMusicSource.SetActive(true);
        gameMusicSource.SetActive(false);
    }
}
