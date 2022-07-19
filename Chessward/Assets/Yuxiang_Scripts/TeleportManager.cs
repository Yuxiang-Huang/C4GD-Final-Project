using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportManager : MonoBehaviour
{
    private PlayerControll player;
    public int xPos;
    public int yPos;

    public Button[] Rank1 = new Button[8];
    public Button[] Rank2 = new Button[8];
    public Button[] Rank3 = new Button[8];

    public Button[][] allButtons;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControll>();
        xPos = player.xPos;
        yPos = player.yPos;

       allButtons = new Button[][] {Rank1, Rank2, Rank3};

        foreach (Button[] rank in allButtons)
        {
            foreach (Button button in rank)
            {
                button.gameObject.SetActive(false);
            }
        }

        FindSquareForKnight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FindSquareForKnight()
    {
        for (int row = -1; row <= 1; row += 2)
        {
            for (int col = -1; col <= 1; col += 2)
            {
                if (inBound(xPos + row * 2, yPos + col))
                {
                    allButtons[xPos + row * 2][yPos + col].gameObject.SetActive(true);
                }

                if (inBound(xPos + row, yPos + col * 2))
                {
                    allButtons[xPos + row][yPos + col * 2].gameObject.SetActive(true);
                }
            }
        }
    }

    bool inBound(int x, int y)
    {
        return x >= 0 && x < 8 && y >= 0 && y < 8;
    }
}
