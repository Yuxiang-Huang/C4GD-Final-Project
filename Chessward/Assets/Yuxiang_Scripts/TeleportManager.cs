using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public GameObject player;
    private float roomLength;
    private MapBuilder mapBuilder;

    // Start is called before the first frame update
    void Start()
    {
        mapBuilder = GameObject.Find("MapBuilder").GetComponent<MapBuilder>();
        roomLength = mapBuilder.roomLength;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void teleport(int x, int z)
    {
        player.transform.position = new Vector3(player.transform.position.x % roomLength + x * roomLength,
        player.transform.position.y, player.transform.position.z % roomLength + z * roomLength);
    }
}
