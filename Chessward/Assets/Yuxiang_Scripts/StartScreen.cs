using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject player;
    public GameObject gun;
    public GameObject miniMapScreen;
    public GameObject statScreen;

    public TeleportManager teleportManager;
    public MiniMap minimapScript;
    public MapBuilder mapBuilder;

    public GameObject WhitePawnImage;
    public GameObject WhiteKnightImage;
    public GameObject WhiteBishopImage;
    public GameObject WhiteRookImage;
    public GameObject WhiteQueenImage;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas.SetActive(true);
        player.SetActive(false);
        gun.SetActive(false);
        miniMapScreen.SetActive(false);
        statScreen.SetActive(false);
        teleportManager.promotionScreen.SetActive(false);
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
        minimapScript.playerImage = WhiteKnightImage;
    }

    public void startRookGame()
    {
        notTutorial();

        teleportManager.pieceName = "Rook";
        minimapScript.playerImage = WhiteRookImage;
    }

    public void startBishopGame()
    {
        notTutorial();

        teleportManager.pieceName = "Bishop";
        minimapScript.playerImage = WhiteBishopImage;
    }

    public void startQueenGame()
    {
        notTutorial();

        teleportManager.pieceName = "Queen";
        minimapScript.playerImage = WhiteQueenImage;
    }

    public void startPawnGame()
    {
        notTutorial();

        teleportManager.pieceName = "Pawn";
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
    }

    public void tagKnight()
    {
        teleportManager.pieceName = "Knight";
        teleportManager.promotionScreen.SetActive(false);
        minimapScript.playerImage = WhiteKnightImage;
    }

    public void tagBishop()
    {
        teleportManager.pieceName = "Bishop";
        teleportManager.promotionScreen.SetActive(false);
        minimapScript.playerImage = WhiteBishopImage;
    }

    public void tagRook()
    {
        teleportManager.pieceName = "Rook";
        teleportManager.promotionScreen.SetActive(false);
        minimapScript.playerImage = WhiteRookImage;
    }

    public void tagQueen()
    {
        teleportManager.pieceName = "Queen";
        teleportManager.promotionScreen.SetActive(false);
        minimapScript.playerImage = WhiteQueenImage;
    }
}
