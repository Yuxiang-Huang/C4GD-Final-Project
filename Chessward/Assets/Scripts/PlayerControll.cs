using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float jumpForce = 10.0f;
    private Rigidbody playerRb;
    public bool isOnGround = true;
    public float gravityModifier;
    private float speed = 20.0f;
    private float rSpeed = 1000.0f;
    private bool touchingWall;
    public int xPos;
    public int yPos;
    public float roomLength;
    public MapBuilder mapBuilder;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        mapBuilder = GameObject.Find("MapBuilder").GetComponent<MapBuilder>();
        roomLength = mapBuilder.roomLength;
    }

    // Update is called once per frame
    void Update()
    {
        xPos = (int)(transform.position.x / roomLength);
        yPos = (int)(transform.position.y / roomLength);
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (!touchingWall)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }
        else
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * speed * forwardInput);
            transform.Translate(-Vector3.right * Time.deltaTime * speed * horizontalInput);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Wall")){
            touchingWall = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            touchingWall = false;
        }
    }
}
