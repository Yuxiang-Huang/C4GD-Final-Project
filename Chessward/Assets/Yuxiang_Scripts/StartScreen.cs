using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject levelScreen;
    public GameObject PieceScreen;
    public GameObject tutorialCanvas;
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
    public GameObject WhiteKingImage;

    public GameObject Scar;
    public GameObject scarAmmoText;
    public GameObject shotGun;
    public GameObject shotGunAmmoText;
    public GameObject sniperGun;
    public GameObject sniperAmmoText;
    public GameObject revolver;
    public GameObject revolverText;
    public GameObject SMG;
    public GameObject SMGText;

    public bool GameStarted;

    public string difficulty;

    public bool isTutorial;

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
        tutorialCanvas.SetActive(false);
    }

    void Update()
    {
        if (playerControllScript.gameOver)
        {
            displayLoseEndScreen();
        }
    }

    public void displayLevelScreen()
    {
        startCanvas.SetActive(false);
        levelScreen.SetActive(true);
    }

    public void displayPieceScreen()
    {
        levelScreen.SetActive(false);
        PieceScreen.SetActive(true);    
    }

    void displayLoseEndScreen()
    {
        player.SetActive(false);
        gun.SetActive(false);
        miniMapScreen.SetActive(false);
        endScreen.SetActive(true);
        statScreen.SetActive(false);
        won.SetActive(false);
        lose.SetActive(true);
    }

    public void displayWinEndScreen()
    {
        player.SetActive(false);
        gun.SetActive(false);
        miniMapScreen.SetActive(false);
        endScreen.SetActive(true);
        statScreen.SetActive(false);
        won.SetActive(true);
        lose.SetActive(false);
    }

    public void startTutorial()
    {
        gun = Scar;
        scarAmmoText.SetActive(true);

        tutorialCanvas.SetActive(true);
        startCanvas.SetActive(false);
        player.SetActive(true);
        gun.SetActive(true);
        mapBuilder.StartBuild(false);
        statScreen.SetActive(true);
        GameStarted = true;
        isTutorial = true;
        spawnEnemyScript.startGame("tutorial");
    }

    public void startKnightGame()
    {
        gun = Scar;
        scarAmmoText.SetActive(true);

        notTutorial();

        teleportManager.pieceName = "Knight";
        WhiteKnightImage.SetActive(true);
        minimapScript.playerImage = WhiteKnightImage;
    }

    public void startRookGame()
    {
        gun = sniperGun;
        sniperAmmoText.SetActive(true);

        notTutorial();

        teleportManager.pieceName = "Rook";
        WhiteRookImage.SetActive(true);
        minimapScript.playerImage = WhiteRookImage;
    }

    public void startBishopGame()
    {
        gun = SMG;
        SMGText.SetActive(true);

        notTutorial();

        teleportManager.pieceName = "Bishop";
        WhiteBishopImage.SetActive(true);
        minimapScript.playerImage = WhiteBishopImage;
    }

    public void startQueenGame()
    {
        gun = revolver;
        revolverText.SetActive(true);

        notTutorial();

        teleportManager.pieceName = "Queen";
        WhiteQueenImage.SetActive(true);
        minimapScript.playerImage = WhiteQueenImage;
    }

    public void startPawnGame()
    {
        gun = shotGun;
        shotGunAmmoText.SetActive(true);

        notTutorial();

        teleportManager.pieceName = "Pawn";
        WhitePawnImage.SetActive(true);
        minimapScript.playerImage = WhitePawnImage;
    }

    public void startKingGame()
    {
        notTutorial();

        teleportManager.pieceName = "King";
        WhiteKingImage.SetActive(true);
        minimapScript.playerImage = WhiteKingImage;
    }

    void notTutorial()
    {
        PieceScreen.SetActive(false);
        player.SetActive(true);
        gun.SetActive(true);
        mapBuilder.StartBuild(true);
        miniMapScreen.SetActive(true);
        statScreen.SetActive(true);
        spawnEnemyScript.startGame(difficulty);
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

    public void setDifficultyEasy()
    {
        difficulty = "easy";
    }

    public void setDifficultyMedium()
    {
        difficulty = "medium";
    }

    public void setDifficultyHard()
    {
        difficulty = "hard";
    }
}
