using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private GameObject player;
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

    public float roomLength = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        size = gameObject.GetComponent<RectTransform>();
        scale = Canvas.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        xPos = (int)(player.transform.position.x / roomLength);
        yPos = (int)(player.transform.position.z / roomLength);

        xStart = (float)(transform.position.x - size.rect.width * 3.5 / 8 * scale.localScale.x);
        yStart = (float)(transform.position.y - size.rect.height * 3.5 / 8 * scale.localScale.y);

        xSpace = size.rect.width / 8 * scale.localScale.x;
        ySpace = size.rect.height / 8 * scale.localScale.y;

        image.transform.position = new Vector3(xStart + xPos * xSpace, yStart + yPos * ySpace, 0);
    }
}
