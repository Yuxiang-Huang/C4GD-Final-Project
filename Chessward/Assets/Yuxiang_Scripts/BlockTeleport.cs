using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTeleport : MonoBehaviour
{
    public TeleportManager teleportManager;
    public int xPos;
    public int yPos;
    public float roomLength = 100;
    public string pieceName;

    // Start is called before the first frame update
    void Start()
    {
        teleportManager = GameObject.Find("Teleport Manager").GetComponent<TeleportManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int xPosNow = (int)(transform.position.x / roomLength);
        int yPosNow = (int)(transform.position.z / roomLength);

        if (xPosNow != xPos || yPosNow != yPos)
        {
            teleportManager.enemySquare[xPos][yPos] = false;
            xPos = xPosNow;
            yPos = yPosNow;
            teleportManager.enemySquare[xPos][yPos] = true;
        }


    }
}
