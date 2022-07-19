using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset = new Vector3(0, 17f, 0);
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
        transform.rotation = Player.transform.rotation;
    }
}
