using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapBuilder : MonoBehaviour
{
    //looking from 0, 0, 0

    public GameObject WhiteFloor;
    public GameObject WhiteWall;
    public GameObject WhiteWallWDoor;
    public GameObject BlackFloor;
    public GameObject BlackWall;
    public GameObject BlackWallWDoor;
    public GameObject DoorForTutorial;

    public GameObject BoardFloor;

    public float roomLength = 100;

    private float yForDoors = 69.5f;
    private Vector3 offset = new Vector3(0, -0.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
   
    }

    public void StartBuild(bool fullGame)
    {
        if (fullGame)
        {
            BoardFloor.SetActive(true);

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

        else
        {
            BuildTutorialMap();
            
        }
    }

    void BuildTutorialMap()
    {
        Vector3 center = new Vector3(50, 0, 50);
        Instantiate(WhiteFloor, center, WhiteFloor.transform.rotation);
        Instantiate(DoorForTutorial,
            new Vector3(center.x, yForDoors, center.z + roomLength / 2),
            WhiteFloor.transform.rotation);
        CreateWhiteLeftWall(center);
        CreateWhiteRightWall(center);
        CreateWhiteBackWall(center);

        Vector3 center2 = new Vector3(50, 0, 150);
        Instantiate(BlackFloor, center2, BlackFloor.transform.rotation);
        CreateBlackFrontWall(center2);
        CreateBlackLeftWall(center2);
        CreateBlackRightWall(center2);
        CreateBlackBackWallWDoor(center2);
    }

    void CreateWhiteRoomWith4Doors(float x, float z)
    {
        Vector3 center = new Vector3(x + roomLength / 2, 0, z + roomLength / 2);

        //floor
        CreateWhiteFloor(center);

        //front
        CreateWhiteFrontWallWDoor(center);

        //back
        CreateWhiteBackWallWDoor(center);

        //left
        CreateWhiteLeftWallWDoor(center);

        //right
        CreateWhiteRightWallWDoor(center);
    }

    void CreateBlackRoomWith4Doors(float x, float z)
    {
        Vector3 center = new Vector3(x + roomLength / 2, 0, z + roomLength / 2);

        //floor
        CreateBlackFloor(center);

        //front
        CreateBlackFrontWallWDoor(center);

        //back
        CreateBlackBackWallWDoor(center);

        //left
        CreateBlackLeftWallWDoor(center);

        //right
        CreateBlackRightWallWDoor(center);
    }

    void CreateWhiteRoomWith3Doors(float x, float z, string noDoorWall) 
    {
        Vector3 center = new Vector3(x + roomLength / 2, 0, z + roomLength / 2);

        //floor
        CreateWhiteFloor(center);

        //front
        if (noDoorWall == "front")
        {
            CreateWhiteFrontWall(center);
        }
        else
        {
            CreateWhiteFrontWallWDoor(center);
        }

        //back
        if (noDoorWall == "back")
        {
            CreateWhiteBackWall(center);
        }
        else
        {
            CreateWhiteBackWallWDoor(center);
        }

        //left
        if (noDoorWall == "left")
        {
            CreateWhiteLeftWall(center);
        }
        else
        {
            CreateWhiteLeftWallWDoor(center);
        }

        //right
        if (noDoorWall == "right")
        {
            CreateWhiteRightWall(center);
        }
        else
        {
            CreateWhiteRightWallWDoor(center);
        }
    }

    void CreateBlackRoomWith3Doors(float x, float z, string noDoorWall)
    {
        Vector3 center = new Vector3(x + roomLength / 2, 0, z + roomLength / 2);

        //floor
        CreateBlackFloor(center);

        //front
        if (noDoorWall == "front")
        {
            CreateBlackFrontWall(center);
        }
        else
        {
            CreateBlackFrontWallWDoor(center);
        }

        //back
        if (noDoorWall == "back")
        {
            CreateBlackBackWall(center);
        }
        else
        {
            CreateBlackBackWallWDoor(center);
        }

        //left
        if (noDoorWall == "left")
        {
            CreateBlackLeftWall(center);
        }
        else
        {
            CreateBlackLeftWallWDoor(center);
        }

        //right
        if (noDoorWall == "right")
        {
            CreateBlackRightWall(center);
        }
        else
        {
            CreateBlackRightWallWDoor(center);
        }
    }

    void CreatFourCornerRooms()
    {
    //left bottom
        Vector3 center = new Vector3(0 + roomLength / 2, 0, 0 + roomLength / 2);

        //floor
        CreateBlackFloor(center);

        //front
        CreateBlackFrontWallWDoor(center);

        //back
        CreateBlackBackWall(center);

        //left
        CreateBlackLeftWall(center);

        //right
        CreateBlackRightWallWDoor(center);


     //left upper
        Vector3 center2 = new Vector3(0 + roomLength / 2, 0, 7 * roomLength + roomLength / 2);

        //floor
        CreateWhiteFloor(center2);

        //front
        CreateWhiteFrontWall(center2);

        //back
        CreateWhiteBackWallWDoor(center2);


        //left
        CreateWhiteLeftWall(center2);


        //right
        CreateWhiteRightWallWDoor(center2);


     //right upper
        Vector3 center3 = new Vector3(7 * roomLength + roomLength / 2, 0, 7 * roomLength + roomLength / 2);

        //floor
        CreateBlackFloor(center3);

        //front
        CreateBlackFrontWall(center3);

        //back
        CreateBlackBackWallWDoor(center3);


        //left
        CreateBlackLeftWallWDoor(center3);


        //right
        CreateBlackRightWall(center3);


     //Right Bottom
        Vector3 center4 = new Vector3(7 * roomLength + roomLength / 2, 0, 0 + roomLength / 2);

        //floor
        CreateWhiteFloor(center4);

        //front
        CreateWhiteFrontWallWDoor(center4);

        //back
        CreateWhiteBackWall(center4);

        //left
        CreateWhiteLeftWallWDoor(center4);

        //right
        CreateWhiteRightWall(center4);

    }

    void CreateWhiteFloor(Vector3 center)
    {
        //Instantiate(WhiteFloor, center, BlackFloor.transform.rotation);
    }

    void CreateWhiteFrontWall(Vector3 center)
    {
        GameObject front = Instantiate(WhiteWall,
        new Vector3(center.x, roomLength / 2, center.z + roomLength / 2),
        WhiteFloor.transform.rotation);
        front.transform.Rotate(-90, 0, 0);
    }

    void CreateWhiteBackWall(Vector3 center)
    {
        GameObject back = Instantiate(WhiteWall,
            new Vector3(center.x, roomLength / 2, center.z - roomLength / 2),
            WhiteFloor.transform.rotation);
        back.transform.Rotate(90, 0, 0);
    }

    void CreateWhiteLeftWall(Vector3 center)
    {
        GameObject left = Instantiate(WhiteWall,
            new Vector3(center.x - roomLength / 2, roomLength / 2, center.z),
            WhiteFloor.transform.rotation);
        left.transform.Rotate(0, 0, -90);
    }

    void CreateWhiteRightWall(Vector3 center)
    {
        GameObject right = Instantiate(WhiteWall,
            new Vector3(center.x + roomLength / 2, roomLength / 2, center.z),
            WhiteFloor.transform.rotation);
        right.transform.Rotate(0, 0, 90);
    }


    void CreateWhiteFrontWallWDoor(Vector3 center)
    {
        GameObject front = Instantiate(WhiteWallWDoor,
            new Vector3(center.x, yForDoors, center.z + roomLength / 2),
            WhiteFloor.transform.rotation);
    }

    void CreateWhiteBackWallWDoor(Vector3 center)
    {
        GameObject back = Instantiate(WhiteWallWDoor,
        new Vector3(center.x, yForDoors, center.z - roomLength / 2),
        WhiteFloor.transform.rotation);
        back.transform.Rotate(0, 180, 0);
    }

    void CreateWhiteLeftWallWDoor(Vector3 center)
    {
        GameObject left = Instantiate(WhiteWallWDoor,
            new Vector3(center.x - roomLength / 2, yForDoors, center.z),
            WhiteFloor.transform.rotation);
        left.transform.Rotate(0, -90, 0);
    }

    void CreateWhiteRightWallWDoor(Vector3 center)
    {
        GameObject right = Instantiate(WhiteWallWDoor,
            new Vector3(center.x + roomLength / 2, yForDoors, center.z),
            WhiteFloor.transform.rotation);
        right.transform.Rotate(0, 90, 0);
    }

    void CreateBlackFloor(Vector3 center)
    {
        //Instantiate(BlackFloor, center, BlackFloor.transform.rotation);
    }

    void CreateBlackFrontWall(Vector3 center)
    {
        GameObject front = Instantiate(BlackWall,
        new Vector3(center.x, roomLength / 2, center.z + roomLength / 2),
        BlackFloor.transform.rotation);
        front.transform.Rotate(-90, 0, 0);
    }

    void CreateBlackBackWall(Vector3 center)
    {
        GameObject back = Instantiate(BlackWall,
            new Vector3(center.x, roomLength / 2, center.z - roomLength / 2),
            BlackFloor.transform.rotation);
        back.transform.Rotate(90, 0, 0);
    }

    void CreateBlackLeftWall(Vector3 center)
    {
        GameObject left = Instantiate(BlackWall,
            new Vector3(center.x - roomLength / 2, roomLength / 2, center.z),
            BlackFloor.transform.rotation);
        left.transform.Rotate(0, 0, -90);
    }

    void CreateBlackRightWall(Vector3 center)
    {
        GameObject right = Instantiate(BlackWall,
            new Vector3(center.x + roomLength / 2, roomLength / 2, center.z),
            BlackFloor.transform.rotation);
        right.transform.Rotate(0, 0, 90);
    }


    void CreateBlackFrontWallWDoor(Vector3 center)
    {
        GameObject front = Instantiate(BlackWallWDoor,
            new Vector3(center.x, yForDoors, center.z + roomLength / 2) + offset,
            BlackFloor.transform.rotation);
        front.transform.Rotate(0, 90, 0);
    }

    void CreateBlackBackWallWDoor(Vector3 center)
    {
        GameObject back = Instantiate(BlackWallWDoor,
            new Vector3(center.x, yForDoors, center.z - roomLength / 2) + offset,
            BlackFloor.transform.rotation);
        back.transform.Rotate(0, -90, 0);
    }

    void CreateBlackLeftWallWDoor(Vector3 center)
    {
        GameObject left = Instantiate(BlackWallWDoor,
            new Vector3(center.x - roomLength / 2, yForDoors, center.z) + offset,
            BlackFloor.transform.rotation);
    }

    void CreateBlackRightWallWDoor(Vector3 center)
    {
        GameObject right = Instantiate(BlackWallWDoor,
       new Vector3(center.x + roomLength / 2, yForDoors, center.z) + offset,
       BlackFloor.transform.rotation);
        right.transform.Rotate(0, 180, 0);
    }
}
