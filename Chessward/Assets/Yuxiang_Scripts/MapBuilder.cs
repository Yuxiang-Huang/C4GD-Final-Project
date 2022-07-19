using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    //looking from 0, 0, 0

    public GameObject WhiteFloor;
    public GameObject WhiteWall;
    public GameObject WhiteWallWDoor;
    public GameObject BlackFloor;
    public GameObject BlackWall;
    public GameObject BlackWallWDoor;

    private float roomLength = 100;

    private float yForDoors = 69.5f;
    private Vector3 offset = new Vector3(0, -0.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        for (int row = 1; row < 7; row++)
        {
            for (int col = 1; col < 7; col++)
            {
                if (row % 2 == 0)
                {
                    if (col % 2 == 0)
                    {
                        CreateBlackRoomWith4Doors(row * roomLength, col * roomLength);
                    }
                    else
                    {
                        CreateWhiteRoomWith4Doors(row * roomLength, col * roomLength);
                    }
                }
                else
                {
                    if (col % 2 == 0)
                    {
                        CreateWhiteRoomWith4Doors(row * roomLength, col * roomLength);
                    }
                    else
                    {
                        CreateBlackRoomWith4Doors(row * roomLength, col * roomLength);
                    }
                }
            }
        }

        CreateWhiteRoomWith3Doors(0, 0, "front");
        CreateWhiteRoomWith3Doors(200, 0, "left");
        CreateWhiteRoomWith3Doors(400, 0, "back");
        CreateWhiteRoomWith3Doors(600, 0, "right");
    }

    void CreateWhiteRoomWith4Doors(float x, float z)
    {
        Vector3 center = new Vector3(x + roomLength / 2, 0, z + roomLength / 2);

        //floor
        Instantiate(WhiteFloor, center, WhiteFloor.transform.rotation);

        //front
        GameObject front = Instantiate(WhiteWallWDoor,
            new Vector3(center.x, yForDoors, center.z + roomLength / 2),
            WhiteFloor.transform.rotation);

        //back
        GameObject back = Instantiate(WhiteWallWDoor,
            new Vector3(center.x, yForDoors, center.z - roomLength / 2),
            WhiteFloor.transform.rotation);
        back.transform.Rotate(0, 180, 0);

        //left
        GameObject left = Instantiate(WhiteWallWDoor,
            new Vector3(center.x - roomLength / 2, yForDoors, center.z),
            WhiteFloor.transform.rotation);
        left.transform.Rotate(0, -90, 0);

        //right
        GameObject right = Instantiate(WhiteWallWDoor,
            new Vector3(center.x + roomLength / 2, yForDoors, center.z),
            WhiteFloor.transform.rotation);
        right.transform.Rotate(0, 90, 0);
    }

    void CreateBlackRoomWith4Doors(float x, float z)
    {
        Vector3 center = new Vector3(x + roomLength / 2, 0, z + roomLength / 2);

        //floor
        Instantiate(BlackFloor, center, BlackFloor.transform.rotation);

        ////front
        GameObject front = Instantiate(BlackWallWDoor,
            new Vector3(center.x, yForDoors, center.z + roomLength / 2) + offset,
            BlackFloor.transform.rotation);
        front.transform.Rotate(0, 90, 0);

        ////back
        GameObject back = Instantiate(BlackWallWDoor,
            new Vector3(center.x, yForDoors, center.z - roomLength / 2) + offset,
            BlackFloor.transform.rotation);
        back.transform.Rotate(0, -90, 0);

        ////left
        GameObject left = Instantiate(BlackWallWDoor,
            new Vector3(center.x - roomLength / 2, yForDoors, center.z) + offset,
            BlackFloor.transform.rotation);

        ////right
        GameObject right = Instantiate(BlackWallWDoor,
            new Vector3(center.x + roomLength / 2, yForDoors, center.z) + offset,
            BlackFloor.transform.rotation);
        right.transform.Rotate(0, 180, 0);
    }




    void CreateWhiteRoom(float x, float z)
    {
        Vector3 center = new Vector3(x + roomLength / 2, 0, z + roomLength / 2);

        //floor
        Instantiate(WhiteFloor, center, WhiteFloor.transform.rotation);

        //front
        GameObject front = Instantiate(WhiteWall,
            new Vector3(center.x, roomLength / 2, center.z + roomLength / 2),
            WhiteFloor.transform.rotation);
        front.transform.Rotate(-90, 0, 0);

        //back
        GameObject back = Instantiate(WhiteWall,
            new Vector3(center.x, roomLength / 2, center.z - roomLength / 2),
            WhiteFloor.transform.rotation);
        back.transform.Rotate(90, 0, 0);

        //left
        GameObject left = Instantiate(WhiteWall,
            new Vector3(center.x - roomLength / 2, roomLength / 2, center.z),
            WhiteFloor.transform.rotation);
        left.transform.Rotate(0, 0, -90);

        //right
        GameObject right = Instantiate(WhiteWall,
            new Vector3(center.x + roomLength / 2, roomLength / 2, center.z),
            WhiteFloor.transform.rotation);
        right.transform.Rotate(0, 0, 90);
    }

    void CreateBlackRoom(float x, float z)
    {
        Vector3 center = new Vector3(x + roomLength / 2, 0, z + roomLength / 2);

        //floor
        Instantiate(BlackFloor, center, BlackFloor.transform.rotation);

        //front
        GameObject front = Instantiate(BlackWall,
            new Vector3(center.x, roomLength / 2, center.z + roomLength / 2),
            BlackFloor.transform.rotation);
        front.transform.Rotate(-90, 0, 0);

        ////back
        GameObject back = Instantiate(BlackWall,
            new Vector3(center.x, roomLength / 2, center.z - roomLength / 2),
            BlackFloor.transform.rotation);
        back.transform.Rotate(90, 0, 0);

        ////left
        GameObject left = Instantiate(BlackWall,
            new Vector3(center.x - roomLength / 2, roomLength / 2, center.z),
            BlackFloor.transform.rotation);
        left.transform.Rotate(0, 0, -90);

        ////right
        GameObject right = Instantiate(BlackWall,
            new Vector3(center.x + roomLength / 2, roomLength / 2, center.z),
            BlackFloor.transform.rotation);
        right.transform.Rotate(0, 0, 90);
    }



    void CreateWhiteRoomWith3Doors(float x, float z, string noDoorWall) 
    {
        Vector3 center = new Vector3(x + roomLength / 2, 0, z + roomLength / 2);

        //floor
        GameObject floor = Instantiate(WhiteFloor, center, WhiteFloor.transform.rotation);

        //front
        if (noDoorWall == "front")
        {
            GameObject front = Instantiate(WhiteWall,
            new Vector3(center.x, roomLength / 2, center.z + roomLength / 2),
            WhiteFloor.transform.rotation);
            front.transform.Rotate(-90, 0, 0);
        }
        else
        {
            GameObject front = Instantiate(WhiteWallWDoor,
            new Vector3(center.x, yForDoors, center.z + roomLength / 2),
            WhiteFloor.transform.rotation);
        }

        //back
        if (noDoorWall == "back")
        {
            GameObject back = Instantiate(WhiteWall,
            new Vector3(center.x, roomLength / 2, center.z - roomLength / 2),
            WhiteFloor.transform.rotation);
            back.transform.Rotate(90, 0, 0);
        }
        else
        {
            GameObject back = Instantiate(WhiteWallWDoor,
            new Vector3(center.x, yForDoors, center.z - roomLength / 2),
            WhiteFloor.transform.rotation);
            back.transform.Rotate(0, 180, 0);
        }

        //left
        if (noDoorWall == "left")
        {
            GameObject left = Instantiate(WhiteWall,
            new Vector3(center.x - roomLength / 2, roomLength / 2, center.z),
            WhiteFloor.transform.rotation);
            left.transform.Rotate(0, 0, -90);
        }
        else
        {
            GameObject left = Instantiate(WhiteWallWDoor,
            new Vector3(center.x - roomLength / 2, yForDoors, center.z),
            WhiteFloor.transform.rotation);
            left.transform.Rotate(0, -90, 0);
        }

        //right
        if (noDoorWall == "right")
        {
            GameObject right = Instantiate(WhiteWall,
                new Vector3(center.x + roomLength / 2, roomLength / 2, center.z),
                WhiteFloor.transform.rotation);
            right.transform.Rotate(0, 0, 90);
        }
        else
        {
            GameObject right = Instantiate(WhiteWallWDoor,
            new Vector3(center.x + roomLength / 2, yForDoors, center.z),
            WhiteFloor.transform.rotation);
            right.transform.Rotate(0, 90, 0);
        }        
    }
}
