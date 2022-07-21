using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public GameObject player;
    public TeleportManager teleportManager;
    public SpawnEnemy spawnEnemyScript;

    public GameObject playerImage;

    public GameObject BlackPawnImage;
    public GameObject BlackKnightImage;
    public GameObject BlackBishopImage;
    public GameObject BlackRookImage;
    public GameObject BlackQueenImage;
    public GameObject BlackKingImage;

    RectTransform size;

    public float xSpace;
    public float xStart;
    public float ySpace;
    public float yStart;

    public int xPos;
    public int yPos;

    public float roomLength = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        size = gameObject.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        xPos = (int)(player.transform.position.x / roomLength);
        yPos = (int)(player.transform.position.z / roomLength);

        xStart = (float)( - size.rect.width * 3.5 / 8);
        yStart = (float)( - size.rect.height * 3.5 / 8);

        xSpace = size.rect.width / 8;
        ySpace = size.rect.height / 8;

        playerImage.transform.localPosition = new Vector3(xStart + xPos * xSpace, yStart + yPos * ySpace, 0);
        playerImage.transform.rotation = Quaternion.AngleAxis(-player.transform.eulerAngles.y, Vector3.forward);

        foreach (EnemyDummyIntro now in spawnEnemyScript.enemies)
        {
            switch (now.pieceName)
            {
                case "Pawn":
                    BlackPawnImage.transform.localPosition
                        = new Vector3(xStart + now.xPos * xSpace, yStart + now.yPos * ySpace, 0);
                    break;
                case "Knight":
                    BlackKnightImage.transform.localPosition
                        = new Vector3(xStart + now.xPos * xSpace, yStart + now.yPos * ySpace, 0);
                    break;
                case "Bishop":
                    BlackBishopImage.transform.localPosition
                        = new Vector3(xStart + now.xPos * xSpace, yStart + now.yPos * ySpace, 0);
                    break;
                case "Rook":
                    BlackRookImage.transform.localPosition
                        = new Vector3(xStart + now.xPos * xSpace, yStart + now.yPos * ySpace, 0);
                    break;
                case "Queen":
                    BlackQueenImage.transform.localPosition
                        = new Vector3(xStart + now.xPos * xSpace, yStart + now.yPos * ySpace, 0);
                    break;
                case "King":
                    BlackKingImage.transform.localPosition
                        = new Vector3(xStart + now.xPos * xSpace, yStart + now.yPos * ySpace, 0);
                    break;
            }
        }

    }
}
