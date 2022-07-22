using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject Enemy;
    private Vector3 offset = new Vector3(0, 4, 0);
    public GameObject projectilePrefab;
    private float shootTime;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        shootTime = shootTime + Time.deltaTime;
        transform.position = Enemy.transform.position + offset;
        transform.rotation = Enemy.transform.rotation;
        transform.position += transform.right * 2.5f;
        transform.position += transform.forward * 1.5f;
        if (shootTime > 1)
        {
            Vector3 offset2 = transform.up * 0.5f + transform.forward * 8f;
            shootTime = 0;
            Instantiate(projectilePrefab, transform.position + offset2, transform.rotation);
        }
        transform.Rotate(0, 180, 0);
    }
}
