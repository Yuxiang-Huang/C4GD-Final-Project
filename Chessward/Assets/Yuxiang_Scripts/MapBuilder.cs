using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    //looking from 0, 0, 0

    public GameObject WhiteFloor;
    public GameObject WhiteWall;
    public GameObject WhiteWallWDoor;

    private float roomLength = 100;

    // Start is called before the first frame update
    void Start()
    {
        CreateWhiteRoom(0, 0);
    }

    void CreateWhiteRoom(float x, float z)
    {
        //floor
        Instantiate(WhiteFloor, new Vector3(x + roomLength / 2, 0, z + roomLength / 2),
            WhiteFloor.transform.rotation);

        //front
        GameObject front = Instantiate(WhiteWall,
            new Vector3(x + roomLength / 2, roomLength / 2, z + roomLength),
            WhiteFloor.transform.rotation);
        front.transform.Rotate(-90, 0, 0);

        //left
        GameObject left = Instantiate(WhiteWall,
            new Vector3(x + roomLength / 2, roomLength / 2, z + roomLength),
            WhiteFloor.transform.rotation);
        left.transform.Rotate(0, 0, 90);

    }
}
