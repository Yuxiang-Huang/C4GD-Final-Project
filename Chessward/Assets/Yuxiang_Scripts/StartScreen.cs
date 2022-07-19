using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject player;
    public GameObject gun;
    public GameObject miniMap;
    public GameObject statScreen;

    public TeleportManager teleportManager;

    public MapBuilder mapBuilder;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);
        player.SetActive(false);
        gun.SetActive(false);
        miniMap.SetActive(false);
        statScreen.SetActive(false);
    }

    public void startTutorial()
    {
        startCanvas.SetActive(false);
        player.SetActive(true);
        gun.SetActive(true);
        mapBuilder.StartBuild(false);
        statScreen.SetActive(true);
    }

    public void startKnightGame()
    {
        notTutorial();

        teleportManager.pieceName = "Knight";
    }

    public void startRookGame()
    {
        notTutorial();

        teleportManager.pieceName = "Rook";
    }

    void notTutorial()
    {
        startCanvas.SetActive(false);
        player.SetActive(true);
        gun.SetActive(true);
        mapBuilder.StartBuild(true);
        miniMap.SetActive(true);
        statScreen.SetActive(true);
    }
}
