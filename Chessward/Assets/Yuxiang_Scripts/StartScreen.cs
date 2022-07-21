using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject player;
    public GameObject gun;
    public GameObject miniMapScreen;
    public GameObject statScreen;
    public GameObject endScreen;
    public GameObject won;
    public GameObject lose;

    public TeleportManager teleportManager;
    public MiniMap minimapScript;
    public MapBuilder mapBuilder;
    public PlayerControll playerControllScript;
    public SpawnEnemy spawnEnemyScript;

    public GameObject WhitePawnImage;
    public GameObject WhiteKnightImage;
    public GameObject WhiteBishopImage;
    public GameObject WhiteRookImage;
    public GameObject WhiteQueenImage;

    public bool GameStarted;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);
        player.SetActive(false);
        gun.SetActive(false);
        miniMapScreen.SetActive(false);
        statScreen.SetActive(false);
        teleportManager.promotionScreen.SetActive(false);
        endScreen.SetActive(false);
        GameStarted = false;
    }

    void Update()
    {
        if (playerControllScript.gameOver)
        {
            displayLoseEndScreen();
        }
    }

    void displayLoseEndScreen()
    {
        player.SetActive(false);
        gun.SetActive(false);
        miniMapScreen.SetActive(false);
        endScreen.SetActive(true);
        won.SetActive(false);
        lose.SetActive(true);
    }

    public void displayWinEndScreen()
    {
        player.SetActive(false);
        gun.SetActive(false);
        miniMapScreen.SetActive(false);
        endScreen.SetActive(true);
        won.SetActive(true);
        lose.SetActive(false);
    }

    public void startTutorial()
    {
        startCanvas.SetActive(false);
        player.SetActive(true);
        gun.SetActive(true);
        mapBuilder.StartBuild(false);
        statScreen.SetActive(true);
        GameStarted = true;
        spawnEnemyScript.startGame("tutorial");
    }

    public void startKnightGame()
    {
        notTutorial();

        teleportManager.pieceName = "Knight";
        WhiteKnightImage.SetActive(true);
        minimapScript.playerImage = WhiteKnightImage;
    }

    public void startRookGame()
    {
        notTutorial();

        teleportManager.pieceName = "Rook";
        WhiteRookImage.SetActive(true);
        minimapScript.playerImage = WhiteRookImage;
    }

    public void startBishopGame()
    {
        notTutorial();

        teleportManager.pieceName = "Bishop";
        WhiteBishopImage.SetActive(true);
        minimapScript.playerImage = WhiteBishopImage;
    }

    public void startQueenGame()
    {
        notTutorial();

        teleportManager.pieceName = "Queen";
        WhiteQueenImage.SetActive(true);
        minimapScript.playerImage = WhiteQueenImage;
    }

    public void startPawnGame()
    {
        notTutorial();

        teleportManager.pieceName = "Pawn";
        WhitePawnImage.SetActive(true);
        minimapScript.playerImage = WhitePawnImage;
    }

    void notTutorial()
    {
        startCanvas.SetActive(false);
        player.SetActive(true);
        gun.SetActive(true);
        mapBuilder.StartBuild(true);
        miniMapScreen.SetActive(true);
        statScreen.SetActive(true);
        spawnEnemyScript.startGame("full");
        GameStarted = true;
    }

    public void tagKnight()
    {
        WhitePawnImage.SetActive(false);
        teleportManager.pieceName = "Knight";
        teleportManager.promotionScreen.SetActive(false);
        WhiteKnightImage.SetActive(true);
        minimapScript.playerImage = WhiteKnightImage;
    }

    public void tagBishop()
    {
        WhitePawnImage.SetActive(false);
        teleportManager.pieceName = "Bishop";
        teleportManager.promotionScreen.SetActive(false);
        WhiteBishopImage.SetActive(true);
        minimapScript.playerImage = WhiteBishopImage;
    }

    public void tagRook()
    {
        WhitePawnImage.SetActive(false);
        teleportManager.pieceName = "Rook";
        teleportManager.promotionScreen.SetActive(false);
        WhiteRookImage.SetActive(true);
        minimapScript.playerImage = WhiteRookImage;
    }

    public void tagQueen()
    {
        WhitePawnImage.SetActive(false);
        teleportManager.pieceName = "Queen";
        teleportManager.promotionScreen.SetActive(false);
        WhiteQueenImage.SetActive(true);
        minimapScript.playerImage = WhiteQueenImage;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}
