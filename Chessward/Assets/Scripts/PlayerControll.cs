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
    private float rSpeed = 700.0f;
    private bool touchingWall;
    public int health;
    private int damage;
    private AudioSource PlayerAudio;
    public bool gameOver;
    public AudioClip jumpSound;
    public AudioClip landSound;
    public TeleportManager teleportManager;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        health = 100;
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
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
            PlayerAudio.PlayOneShot(jumpSound, 1.0f);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (!teleportManager.isPowerActive)
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rSpeed);
        }
            

        if (health <= 0)
        {
            gameOver = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (isOnGround == false)
            {
                PlayerAudio.PlayOneShot(landSound, 1.0f);
            }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletBad"))
        {
            health = health - damage;
        }
    }
}
