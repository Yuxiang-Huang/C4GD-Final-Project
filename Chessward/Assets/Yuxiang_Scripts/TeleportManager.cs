using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeleportManager : MonoBehaviour
{
    public GameObject player;
    public int xPos;
    public int yPos;
    public float roomLength = 100;
    public string pieceName;
    public TextMeshProUGUI cdText;

    public Button[] Rank1 = new Button[8];
    public Button[] Rank2 = new Button[8];
    public Button[] Rank3 = new Button[8];
    public Button[] Rank4 = new Button[8];
    public Button[] Rank5 = new Button[8];
    public Button[] Rank6 = new Button[8];
    public Button[] Rank7 = new Button[8];
    public Button[] Rank8 = new Button[8];

    public Button[][] allButtons;

    public bool[][] enemySquare = new bool[8][];

    public bool isPowerActive;

    public float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        allButtons = new Button[][] { Rank1, Rank2, Rank3, Rank4, Rank5, Rank6, Rank7, Rank8 };

        HideAllButton();

        for (int i = 0; i < enemySquare.Length; i ++)
        {
            enemySquare[i] = new bool[8];
        }

        cdText.text = "CD: " + coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        int xPosNow = (int)(player.transform.position.x / roomLength);
        int yPosNow = (int)(player.transform.position.z / roomLength);

        if (xPosNow != xPos || yPosNow != yPos)
        {
            HideAllButton();
            isPowerActive = false;
            xPos = xPosNow;
            yPos = yPosNow;
        }

        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
            coolDown = Mathf.Max(coolDown, 0);
            cdText.text = "CD: " + coolDown;
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (isPowerActive)
                {
                    HideAllButton();
                    isPowerActive = false;
                }
                else
                {
                    isPowerActive = true;

                    switch (pieceName)
                    {
                        case "Rook":
                            FindSquareForRook();
                            break;
                        case "Knight":
                            FindSquareForKnight();
                            break;
                        case "Bishop":
                            FindSquareForBishop();
                            break;
                        case "Queen":
                            FindSquareForQueen();
                            break;
                        case "Pawn":
                            //FindSquareForPawn();
                            break;
                    }             
                }
            }
        }
    }

    void FindSquareForKnight()
    {
        for (int row = -1; row <= 1; row += 2)
        {
            for (int col = -1; col <= 1; col += 2)
            {
                if (inBound(xPos + row * 2, yPos + col))
                {
                    allButtons[yPos + col][xPos + row * 2].gameObject.SetActive(true);
                }

                if (inBound(xPos + row, yPos + col * 2))
                {
                    allButtons[yPos + col * 2][xPos + row].gameObject.SetActive(true);
                }
            }
        }
    }

    void FindSquareForRook()
    {
        FindSquareHelper(xPos, yPos, 0, 1);
        FindSquareHelper(xPos, yPos, 0, -1);
        FindSquareHelper(xPos, yPos, 1, 0);
        FindSquareHelper(xPos, yPos, -1, 0);
    }

    void FindSquareHelper(int x, int y, int xChange, int yChange)
    {
        x += xChange;
        y += yChange;

        while (inBound(x, y))
        {
            allButtons[y][x].gameObject.SetActive(true);
            if (enemySquare[x][y])
            {
                break;
            }
            x += xChange;
            y += yChange;
        }
    }

    void FindSquareForBishop()
    {
        FindSquareHelper(xPos, yPos, 1, 1);
        FindSquareHelper(xPos, yPos, 1, -1);
        FindSquareHelper(xPos, yPos, -1, 1);
        FindSquareHelper(xPos, yPos, -1, -1);
    }

    void FindSquareForQueen()
    {
        FindSquareForBishop();
        FindSquareForRook();
    }


    bool inBound(int x, int y)
    {
        return x >= 0 && x < 8 && y >= 0 && y < 8;
    }

    void HideAllButton()
    {
        foreach (Button[] rank in allButtons)
        {
            foreach (Button button in rank)
            {
                button.gameObject.SetActive(false);
            }
        }
    }

    public void startCoolDown()
    {
        switch (pieceName)
        {
            case "Rook":
                coolDown = 5;
                break;
            case "Knight":
                coolDown = 3;
                break;
            case "Bishop":
                coolDown = 3;
                break;
            case "Queen":
                coolDown = 9;
                break;
            case "Pawn":
                coolDown = 1;
                break;
        }
    }
}
