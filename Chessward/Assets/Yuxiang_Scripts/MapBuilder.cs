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
        Vector3 center = new Vector3(x + roomLength / 2, 0, z + roomLength / 2);

        //floor
        Instantiate(WhiteFloor, center, WhiteFloor.transform.rotation);

        //front
        GameObject front = Instantiate(WhiteWall,
            new Vector3(center.x, roomLength / 2, center.z + roomLength / 2),
            WhiteFloor.transform.rotation);
        front.transform.Rotate(-90, 0, 0);

        ////back
        GameObject back = Instantiate(WhiteWall,
            new Vector3(center.x, roomLength / 2, center.z - roomLength / 2),
            WhiteFloor.transform.rotation);
        back.transform.Rotate(90, 0, 0);

        ////left
        GameObject left = Instantiate(WhiteWall,
            new Vector3(center.x - roomLength / 2, roomLength / 2, center.z),
            WhiteFloor.transform.rotation);
        left.transform.Rotate(0, 0, -90);

        ////right
        GameObject right = Instantiate(WhiteWall,
            new Vector3(center.x + roomLength / 2, roomLength / 2, center.z),
            WhiteFloor.transform.rotation);
        right.transform.Rotate(0, 0, 90);

    }
}
