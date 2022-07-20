using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private GameObject player;
    public GameObject image;
    public TeleportManager teleportManager;
    public GameObject enemyImage;

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
        player = GameObject.Find("Player");

        size = gameObject.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {

        xPos = (int)(
            player.transform.position.x
            / roomLength);
        yPos = (int)(player.transform.position.z / roomLength);

        xStart = (float)( - size.rect.width * 3.5 / 8);
        yStart = (float)( - size.rect.height * 3.5 / 8);

        xSpace = size.rect.width / 8;
        ySpace = size.rect.height / 8;

        image.transform.localPosition = new Vector3(xStart + xPos * xSpace, yStart + yPos * ySpace, 0);

        //for (int row = 0; row < teleportManager.enemySquare.Length; row++)
        //{
        //    for (int col = 0; col < teleportManager.enemySquare[0].Length; col++)
        //    {
        //        if (teleportManager.enemySquare[row][col])
        //        {
        //            enemyImage.transform.localPosition = new Vector3(xStart + row * xSpace, yStart + col * ySpace, 0);
        //        }
        //    }
        //}
        
    }
}
