using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    private float bSpeed = 80.0f;
    //public GameObject Enemy;
    //private float maxDist = 80.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(90, 0, 0));
        //Enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * bSpeed);
        //float dist = (transform.position - Enemy.transform.position).magnitude;
        //if (dist > maxDist)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}