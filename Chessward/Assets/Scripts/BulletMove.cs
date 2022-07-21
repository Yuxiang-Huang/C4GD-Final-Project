using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float bSpeed = 80.0f;
    Rigidbody rb;
    public float gravity = -9.8f; 

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(90, 0, 0));
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * bSpeed);
        rb.AddForce(new Vector3(0, gravity, 0), ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
