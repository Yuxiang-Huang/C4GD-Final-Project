using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject Enemy;
    private Vector3 offset = new Vector3(0, 4, 0);
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.Find("Enemy");

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Enemy.transform.position + offset;
        transform.rotation = Enemy.transform.rotation;
        transform.position += transform.right * 2.5f;
        transform.position += transform.forward * 1.5f;
    }
}
