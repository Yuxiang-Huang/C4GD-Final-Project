using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportButton : MonoBehaviour
{
    public int x;
    public int z;
    public GameObject player;
    public float roomLength;
    private MapBuilder mapBuilder;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        mapBuilder = GameObject.Find("MapBuilder").GetComponent<MapBuilder>();
        roomLength = mapBuilder.roomLength;

        button.onClick.AddListener(delegate { teleport(x, z); });
    }

    void teleport(int x, int z)
    {
        player.transform.position = new Vector3(player.transform.position.x % roomLength + x * roomLength,
        player.transform.position.y, player.transform.position.z % roomLength + z * roomLength);
    }
}
