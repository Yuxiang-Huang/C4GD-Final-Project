using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : MonoBehaviour
{
    private float bSpeed = 80.0f;
    private float rotateRange = 13;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(90 + Random.Range(-rotateRange, rotateRange), Random.Range(-rotateRange, rotateRange), 0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * bSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}