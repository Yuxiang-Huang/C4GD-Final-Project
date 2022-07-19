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

    public int x;
    public int y;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        RectTransform size = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        x = (int) player.transform.position.x / 100;
        y = (int)player.transform.position.z / 100;
        xStart = (float)(transform.position.x - size.rect.width / 8 * 3.5);
        yStart = (float)(transform.position.y - size.rect.height / 8 * 3.5);
        xSpace = size.rect.width / 8;
        ySpace = size.rect.height / 8;
        image.transform.position = new Vector3(xStart + x * xSpace, yStart + y * ySpace, 0);
    }
}
