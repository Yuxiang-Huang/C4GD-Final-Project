using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject player;
    public GameObject gun;
    public GameObject miniMap;

    public MapBuilder mapBuilder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void startTutorial()
    {
        startCanvas.SetActive(false);
        player.SetActive(true);
        gun.SetActive(true);
        mapBuilder.Start(false);
    }

    public void startKnightGame()
    {
        startCanvas.SetActive(false);
        player.SetActive(true);
        gun.SetActive(true);
        mapBuilder.Start(true);
        miniMap.SetActive(true);
    }
}
