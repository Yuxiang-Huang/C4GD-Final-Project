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

        for (int row = 1; row < 7; row++)
        {
            if (row % 2 == 1)
            {
                CreateWhiteRoomWith3Doors(0, row * roomLength, "left");
                CreateBlackRoomWith3Doors(7 * roomLength, row * roomLength, "right");
            }
            else
            {
                CreateWhiteRoomWith3Doors(7 * roomLength, row * roomLength, "right");
                CreateBlackRoomWith3Doors(0, row * roomLength, "left");
            }
        }

        for (int col = 1; col < 7; col++)
        {
            if (col % 2 == 1)
            {
                CreateWhiteRoomWith3Doors(col * roomLength, 0, "back");
                CreateBlackRoomWith3Doors(col * roomLength, 7 * roomLength, "front");
            }
            else
            {
                CreateWhiteRoomWith3Doors(col * roomLength, 7 * roomLength, "front");
                CreateBlackRoomWith3Doors(col * roomLength, 0, "back");
            }
        }

        CreatFourCornerRooms();
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

        //front
        GameObject front = Instantiate(BlackWallWDoor,
            new Vector3(center.x, yForDoors, center.z + roomLength / 2) + offset,
            BlackFloor.transform.rotation);
        front.transform.Rotate(0, 90, 0);

        //back
        GameObject back = Instantiate(BlackWallWDoor,
            new Vector3(center.x, yForDoors, center.z - roomLength / 2) + offset,
            BlackFloor.transform.rotation);
        back.transform.Rotate(0, -90, 0);

        //left
        GameObject left = Instantiate(BlackWallWDoor,
            new Vector3(center.x - roomLength / 2, yForDoors, center.z) + offset,
            BlackFloor.transform.rotation);

        //right
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

    void CreateBlackRoomWith3Doors(float x, float z, string noDoorWall)
    {
        Vector3 center = new Vector3(x + roomLength / 2, 0, z + roomLength / 2);

        //floor
        GameObject floor = Instantiate(BlackFloor, center, BlackFloor.transform.rotation);

        //front
        if (noDoorWall == "front")
        {
            GameObject front = Instantiate(BlackWall,
            new Vector3(center.x, roomLength / 2, center.z + roomLength / 2),
            BlackFloor.transform.rotation);
            front.transform.Rotate(-90, 0, 0);
        }
        else
        {
            GameObject front = Instantiate(BlackWallWDoor,
            new Vector3(center.x, yForDoors, center.z + roomLength / 2) + offset,
            BlackFloor.transform.rotation);
            front.transform.Rotate(0, 90, 0);
        }

        //back
        if (noDoorWall == "back")
        {
            GameObject back = Instantiate(BlackWall,
            new Vector3(center.x, roomLength / 2, center.z - roomLength / 2),
            BlackFloor.transform.rotation);
            back.transform.Rotate(90, 0, 0);
        }
        else
        {
            GameObject back = Instantiate(BlackWallWDoor,
            new Vector3(center.x, yForDoors, center.z - roomLength / 2) + offset,
            BlackFloor.transform.rotation);
            back.transform.Rotate(0, -90, 0);
        }

        //left
        if (noDoorWall == "left")
        {
            GameObject left = Instantiate(BlackWall,
            new Vector3(center.x - roomLength / 2, roomLength / 2, center.z),
            BlackFloor.transform.rotation);
            left.transform.Rotate(0, 0, -90);
        }
        else
        {
            GameObject left = Instantiate(BlackWallWDoor,
            new Vector3(center.x - roomLength / 2, yForDoors, center.z) + offset,
            BlackFloor.transform.rotation);
        }

        //right
        if (noDoorWall == "right")
        {
            GameObject right = Instantiate(BlackWall,
                new Vector3(center.x + roomLength / 2, roomLength / 2, center.z),
                BlackFloor.transform.rotation);
            right.transform.Rotate(0, 0, 90);
        }
        else
        {
            GameObject right = Instantiate(BlackWallWDoor,
            new Vector3(center.x + roomLength / 2, yForDoors, center.z) + offset,
            BlackFloor.transform.rotation);
            right.transform.Rotate(0, 180, 0);
        }
    }

    void CreatFourCornerRooms()
    {
    //left bottom
        Vector3 center = new Vector3(0 + roomLength / 2, 0, 0 + roomLength / 2);

        //floor
        GameObject floor = Instantiate(BlackFloor, center, BlackFloor.transform.rotation);

        //front
        GameObject front = Instantiate(BlackWallWDoor,
        new Vector3(center.x, yForDoors, center.z + roomLength / 2) + offset,
        BlackFloor.transform.rotation);
        front.transform.Rotate(0, 90, 0);

        //back
        GameObject back = Instantiate(BlackWall,
        new Vector3(center.x, roomLength / 2, center.z - roomLength / 2),
        BlackFloor.transform.rotation);
        back.transform.Rotate(90, 0, 0);
        

        //left
        GameObject left = Instantiate(BlackWall,
        new Vector3(center.x - roomLength / 2, roomLength / 2, center.z),
        BlackFloor.transform.rotation);
        left.transform.Rotate(0, 0, -90);

        //right
        GameObject right = Instantiate(BlackWallWDoor,
        new Vector3(center.x + roomLength / 2, yForDoors, center.z) + offset,
        BlackFloor.transform.rotation);
        right.transform.Rotate(0, 180, 0);


     //left upper
        Vector3 center2 = new Vector3(0 + roomLength / 2, 0, 7 * roomLength + roomLength / 2);

        //floor
        GameObject floor2 = Instantiate(WhiteFloor, center2, WhiteFloor.transform.rotation);

        //front
        
            GameObject front2 = Instantiate(WhiteWall,
            new Vector3(center2.x, roomLength / 2, center2.z + roomLength / 2),
            WhiteFloor.transform.rotation);
            front2.transform.Rotate(-90, 0, 0);
    

        //back
        
            GameObject back2 = Instantiate(WhiteWallWDoor,
            new Vector3(center2.x, yForDoors, center2.z - roomLength / 2),
            WhiteFloor.transform.rotation);
            back2.transform.Rotate(0, 180, 0);
        

        //left
        
            GameObject left2 = Instantiate(WhiteWall,
            new Vector3(center2.x - roomLength / 2, roomLength / 2, center2.z),
            WhiteFloor.transform.rotation);
            left2.transform.Rotate(0, 0, -90);
        

        //right
        
            GameObject right2 = Instantiate(WhiteWallWDoor,
            new Vector3(center2.x + roomLength / 2, yForDoors, center2.z),
            WhiteFloor.transform.rotation);
            right2.transform.Rotate(0, 90, 0);


     //right upper
        Vector3 center3 = new Vector3(7 * roomLength + roomLength / 2, 0, 7 * roomLength + roomLength / 2);

        //floor
        GameObject floor3 = Instantiate(BlackFloor, center3, BlackFloor.transform.rotation);

        //front
        GameObject front3 = Instantiate(BlackWall,
        new Vector3(center3.x, roomLength / 2, center3.z + roomLength / 2),
        BlackFloor.transform.rotation);
        front3.transform.Rotate(-90, 0, 0);

        //back
        GameObject back3 = Instantiate(BlackWallWDoor,
        new Vector3(center3.x, yForDoors, center3.z - roomLength / 2) + offset,
        BlackFloor.transform.rotation);
        back3.transform.Rotate(0, -90, 0);


        //left
        GameObject left3 = Instantiate(BlackWallWDoor,
        new Vector3(center3.x - roomLength / 2, yForDoors, center3.z) + offset,
        BlackFloor.transform.rotation);


        //right
        GameObject right3 = Instantiate(BlackWall,
            new Vector3(center3.x + roomLength / 2, roomLength / 2, center3.z),
            BlackFloor.transform.rotation);
        right3.transform.Rotate(0, 0, 90);


     //left upper
        Vector3 center4 = new Vector3(7 * roomLength + roomLength / 2, 0, 0 + roomLength / 2);

        //floor
        GameObject floor4 = Instantiate(WhiteFloor, center4, WhiteFloor.transform.rotation);

        //front

        GameObject front4 = Instantiate(WhiteWall,
        new Vector3(center4.x, roomLength / 2, center4.z + roomLength / 2),
        WhiteFloor.transform.rotation);
        front4.transform.Rotate(-90, 0, 0);


        //back

        GameObject back4 = Instantiate(WhiteWallWDoor,
        new Vector3(center4.x, yForDoors, center4.z - roomLength / 2),
        WhiteFloor.transform.rotation);
        back4.transform.Rotate(0, 180, 0);


        //left

        GameObject left4 = Instantiate(WhiteWall,
        new Vector3(center4.x - roomLength / 2, roomLength / 2, center4.z),
        WhiteFloor.transform.rotation);
        left4.transform.Rotate(0, 0, -90);


        //right

        GameObject right4 = Instantiate(WhiteWallWDoor,
        new Vector3(center4.x + roomLength / 2, yForDoors, center4.z),
        WhiteFloor.transform.rotation);
        right4.transform.Rotate(0, 90, 0);

    }
}
