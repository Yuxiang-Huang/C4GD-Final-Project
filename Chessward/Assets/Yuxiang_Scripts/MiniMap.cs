using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private PlayerControll player;
    public GameObject image;
    RectTransform size;

    public float xSpace;
    public float xStart;
    public float ySpace;
    public float yStart;

    public GameObject Canvas;
    private MapBuilder mapBuilder;
    private RectTransform scale;

    public int xPos;
    public int yPos;

    public float roomLength;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControll>();

        mapBuilder = GameObject.Find("MapBuilder").GetComponent<MapBuilder>();
        roomLength = mapBuilder.roomLength;

        size = gameObject.GetComponent<RectTransform>();
        scale = Canvas.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        xPos = player.xPos;
        yPos = player.yPos;

        xStart = (float)(transform.position.x - size.rect.width * 3.5 / 8 * scale.localScale.x);
        yStart = (float)(transform.position.y - size.rect.height * 3.5 / 8 * scale.localScale.y);

        xSpace = size.rect.width / 8 * scale.localScale.x;
        ySpace = size.rect.height / 8 * scale.localScale.y;

        image.transform.position = new Vector3(xStart + xPos * xSpace, yStart + yPos * ySpace, 0);
    }
}
